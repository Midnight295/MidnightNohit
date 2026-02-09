using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using MidnightNohit.Content.UI.SingleElements;
using MidnightNohit.Core.ModPlayers;
using MidnightNohit.Core;
using MidnightNohit.Content.UI.Pages;
using MidnightNohit.Config;
using Terraria.Graphics.Renderers;
using MidnightNohit.Content.UI.MiscUI;

namespace MidnightNohit.Content.UI
{
    public static class TogglesUIManager
    {
        #region Enums/Structs
        public enum MenuState
        {
            Opening,
            Open,
            Closing,
            Closed
        }

        public static bool ShouldPlayHoverSound = false;
        #endregion

        #region Properties
        public static List<IToggleWheelElement> ToggleWheelElements
        {
            get;
            private set;
        } = null;

        private static IToggleWheelElement ActiveElement
        {
            get;
            set;
        } = null;

        public static MenuState State
        {
            get;
            set;
        } = MenuState.Closed;

        public static int ClickCooldownTimer
        {
            get;
            internal set;
        }

        public static bool UIOpen => State is MenuState.Open;

        public static bool UIOpenClosing => State is MenuState.Opening or MenuState.Closing;

        public static Vector2 ScreenCenter => new(Main.screenWidth * 0.5f, Main.screenHeight * 0.5f);
        #endregion

        #region Fields

        private static int OpeningTimer;

        #endregion

        #region Consts/Readonlys

        public const int OpenLength = 20;

        public const int ClickCooldownLength = 10;

        public static readonly Texture2D BloomTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Bloom", AssetRequestMode.ImmediateLoad).Value;

        public static readonly Texture2D Button = ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/Buttons/Button", AssetRequestMode.ImmediateLoad).Value;
        public static readonly Texture2D ButtonGlow = ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/Buttons/ButtonGlow", AssetRequestMode.ImmediateLoad).Value;
        #endregion

        #region Methods
        internal static void SortWheel()
        {
            ToggleWheelElements ??= new();

            ToggleWheelElements.AddRange(TogglesPage.UIManagers.Values.Where(page => !ToggleWheelElements.Contains(page) && page is IToggleWheelElement));
            ToggleWheelElements.AddRange(SingleActionElement.UISingleElements.Values.Where(element => !ToggleWheelElements.Contains(element) && element is IToggleWheelElement));

            ToggleWheelElements = ToggleWheelElements.OrderBy(x => x.Layer).ToList();
        }

        public static void OpenUI(bool sound = false)
        {
            if (State is MenuState.Closed)
            {
                State = MenuState.Opening;
                if (sound)
                    SoundEngine.PlaySound(SoundID.MenuOpen);
            }
        }

        public static void CloseUI(bool sound = false)
        {
            if (State is MenuState.Open)
            {
                State = MenuState.Closing;
                ActiveElement = null;
                if (sound)
                    SoundEngine.PlaySound(SoundID.MenuClose);
            }
        }

        public static void Update()
        {
            if (State is MenuState.Closed)
                return;

            if (Main.CreativeMenu.Enabled)
                CloseUI();

            if (!Main.playerInventory)
                CloseUI();

            if (State is MenuState.Open or MenuState.Opening)
            {
                Main.hidePlayerCraftingMenu = true;
            }

            UpdateOpenClosing();
        }

        private static void UpdateOpenClosing()
        {
            if (State is MenuState.Opening)
            {
                Main.CreativeMenu.CloseMenu();
                OpeningTimer++;
                if (OpeningTimer == OpenLength)
                    State = MenuState.Open;
            }
            else if (State is MenuState.Closing)
            {   
                OpeningTimer--;
                if (OpeningTimer == 0)
                    State = MenuState.Closed;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (State is not MenuState.Closed)
            {
                DrawElements(spriteBatch);
                ActiveElement?.Draw(spriteBatch);
            }
        }

        private static void DrawElements(SpriteBatch spriteBatch)
        {
            int elementCount = ToggleWheelElements.Count;
            float distance = 55f;
            float opacity = 1f;

            Main.NewText("hi");

            for (int i = 0; i < elementCount; i++)
            {
                IToggleWheelElement currentElement = ToggleWheelElements[i];

                float scale = 1;
                float angle = i * elementCount;

                if (UIOpenClosing)
                {
                    //float progress = NohitUtils.EaseInOutSine(Utils.GetLerpValue(10, (20 + (i * elementCount)), OpeningTimer, true));
                    float progress = NohitUtils.EaseInOutSine(Utils.GetLerpValue(0, OpenLength, OpeningTimer, true));
                    //distance *= progress;
                    opacity *= progress;
                    scale *= progress;
                }

                Vector2 drawPosition = new Vector2(Main.screenWidth * Main.UIScale - (NohitUIButton.HorizontalOffset - 19), ((i + elementCount) * distance) + 165);

                // Draw the bloom texture.
                spriteBatch.Draw(BloomTexture, drawPosition, null, new Color(59, 50, 77, 0) * 0.9f * opacity, 0f, BloomTexture.Size() * 0.5f, scale * 0.4f, SpriteEffects.None, 0f);

                // Check for hovering.
                Rectangle interactionArea = Utils.CenteredRectangle(drawPosition, Button.Size());
                bool isHovering = NohitUtils.MouseRectangle.Intersects(interactionArea) && State == MenuState.Open;

                // Draw the outer outline.
                if (isHovering)
                {
                    Main.blockMouse = Main.LocalPlayer.mouseInterface = true;
                    string LocalizedDescription = Language.GetTextValue(currentElement.Description);
                    Main.hoverItemName = LocalizedDescription;

                    // Handle clicking on the icon.
                    if (NohitUtils.CanAndHasClickedUIElement)
                    {
                        ClickCooldownTimer = NohitPlayer.UICooldownTimerLength;
                        SoundEngine.PlaySound(SoundID.MenuTick, Main.LocalPlayer.Center);


                        if (ActiveElement == currentElement)
                            ActiveElement = null;
                        else
                            ActiveElement = currentElement;
                        currentElement.OnClick?.Invoke();
                    }
                }
                    
                spriteBatch.Draw(Button, drawPosition, null, Color.White * opacity, 0f, Button.Size() * 0.5f, scale, SpriteEffects.None, 0f);
                spriteBatch.Draw(currentElement.IconTexture, drawPosition, null, Color.White * opacity, 0f, currentElement.IconTexture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
                if (isHovering)
                    spriteBatch.Draw(ButtonGlow, drawPosition, null, Color.White * opacity, 0f, Button.Size() * 0.5f, scale, SpriteEffects.None, 0f);
            }
        }
        #endregion
    }
}