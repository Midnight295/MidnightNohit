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

        public class QueuedMessage
        {
            public string Text;
            public Color Color;
            public int Timer;

            public QueuedMessage(string text, Color color)
            {
                Text = text;
                Color = color;
                Timer = 0;
            }
        }
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
        private static readonly Queue<QueuedMessage> QueuedMessages = new();

        private static QueuedMessage CurrentMessage = null;

        private static int OpeningTimer;

        private static int HoverTimer;

        private static int AnimationTimer;

        private static int CurrentFrame = 1;
        #endregion

        #region Consts/Readonlys
        public const int AnimationRate = 6;

        public const int FrameCount = 12;

        public const int MessageLength = 120;

        public const int OpenLength = 20;

        public const int ClickCooldownLength = 10;

        public readonly static Color OnColor = new(98, 255, 71);

        public readonly static Color OffColor = new(255, 48, 43);

        public static readonly Texture2D AnimationTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/animatedGlow", AssetRequestMode.ImmediateLoad).Value;

        public static readonly Texture2D OutlineTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/UIIconOutline", AssetRequestMode.ImmediateLoad).Value;

        public static readonly Texture2D BloomTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Bloom", AssetRequestMode.ImmediateLoad).Value;

        public static readonly Texture2D Button = ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/CheatRenderer/Button", AssetRequestMode.ImmediateLoad).Value;
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

            if (CurrentMessage is not null)
            {
                CurrentMessage.Timer++;

                if (CurrentMessage.Timer >= MessageLength)
                    CurrentMessage = null;
            }

            if (CurrentMessage is null && QueuedMessages.Any())
                CurrentMessage = QueuedMessages.Dequeue();
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
                DrawMessage(spriteBatch);
                ActiveElement?.Draw(spriteBatch);
            }
            else if (PotionUI.PotionUIManager.IsDrawing)
                ActiveElement?.Draw(spriteBatch);
        }

        private static void DrawElements(SpriteBatch spriteBatch)
        {
            int elementCount = ToggleWheelElements.Count;
            float distance = 55f;
            float opacity = 1f;

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

                Vector2 drawPosition = new Vector2(Main.screenWidth * Main.UIScale - 1878, ((i + elementCount) * distance) + 165);

                // Draw the bloom texture.
                spriteBatch.Draw(BloomTexture, drawPosition, null, new Color(59, 50, 77, 0) * 0.9f * opacity, 0f, BloomTexture.Size() * 0.5f, scale * 0.4f, SpriteEffects.None, 0f);

                // Check for hovering.
                Rectangle interactionArea = Utils.CenteredRectangle(drawPosition, Button.Size());
                bool isHovering = NohitUtils.MouseRectangle.Intersects(interactionArea) && State == MenuState.Open;

                // Draw the outer outline.
                if (isHovering)
                {
                    Main.blockMouse = Main.LocalPlayer.mouseInterface = true;
                    scale *= 1.1f;
                    string LocalizedDescription = Language.GetTextValue(currentElement.Description);
                    spriteBatch.Draw(OutlineTexture, drawPosition, null, Color.White * opacity, 0f, OutlineTexture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
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
                else
                {
                    HoverTimer--;
                }
                    
                // Draw the actual texture.
                spriteBatch.Draw(Button, drawPosition, null, Color.White * opacity, 0f, Button.Size() * 0.5f, scale, SpriteEffects.None, 0f);
                spriteBatch.Draw(currentElement.IconTexture, drawPosition, null, Color.White * opacity, 0f, currentElement.IconTexture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
            }
        }

        private static void DrawMessage(SpriteBatch spriteBatch)
        {
            if (CurrentMessage is not null)
            {
                Vector2 size = FontAssets.MouseText.Value.MeasureString(CurrentMessage.Text);
                Utils.DrawBorderStringFourWay(spriteBatch, FontAssets.MouseText.Value, CurrentMessage.Text, ScreenCenter.X - size.X / 2, ScreenCenter.Y - 45f,
                    CurrentMessage.Color, Color.Black, default);
            }
        }

        /// <summary>
        /// Queue a message to be displayed on the UI.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void QueueMessage(string text, Color color) => QueuedMessages.Enqueue(new QueuedMessage(text, color));
        #endregion
    }
}