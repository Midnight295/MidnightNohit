using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using MidnightNohit.Core;
using Terraria.DataStructures;
using MidnightNohit.Config;
using Microsoft.Xna.Framework.Design;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using ReLogic.Content;
using CalamityMod.Projectiles.Summon;

namespace MidnightNohit.Content.UI.MiscUI
{
    public class NohitUIButton
    {
        public static int HorizontalOffset
        {
            get;
            private set;
        } = 1577;

        public UIImageButton heartButton;

        private static Asset<Texture2D> heartTexture;
        private static Asset<Texture2D> heartTexture_glow;
        private static Asset<Texture2D> instantDeath;
        private static Asset<Texture2D> instantDeath_glow;

        public static void Load()
        {
            heartTexture = ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/Buttons/HeartIcon");
            instantDeath = ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/Buttons/HeartIconInstantDeath");
            heartTexture_glow = ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/Buttons/HeartIconGlow");
            instantDeath_glow = ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/Buttons/HeartIconInstantDeathGlow");
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            if (Main.LocalPlayer.chest != -1)
            {
                return;
            }

            Texture2D Icon;
            if (NohitConfig.Instance.InstantKill)
                Icon = instantDeath.Value;
            else
                Icon = heartTexture.Value;

            Texture2D HoverIcon = heartTexture_glow.Value;
            if (NohitConfig.Instance.InstantKill)
                HoverIcon = instantDeath_glow.Value;      

            Vector2 IconCenter = new Vector2(Main.screenWidth * Main.UIScale - (Main.GameModeInfo.IsJourneyMode ? HorizontalOffset - 47 : HorizontalOffset), 265f) + Icon.Size() * 0.5f;

            Rectangle iconRectangeArea = Utils.CenteredRectangle(IconCenter, Icon.Size());

            Rectangle mouseHitbox = new(Main.mouseX, Main.mouseY, 2, 2);
            bool isHovering = mouseHitbox.Intersects(iconRectangeArea);

            if (isHovering)
            {
                spriteBatch.Draw(HoverIcon, IconCenter, null, Color.White, 0f, Icon.Size() * 0.5f, 1f, 0, 0f);
                string State;
                State = TogglesUIManager.UIOpen ? "CloseUI" : "OpenUI";

                string IconHighlight;
                if (NohitConfig.Instance.InstantKill)
                    IconHighlight = Language.GetTextValue($"Mods.MidnightNohit.UI.UIButtons.PlayerCheat.InstantDeath");
                else
                    IconHighlight = Language.GetTextValue($"Mods.MidnightNohit.UI.UIButtons.PlayerCheat.None");

                Main.hoverItemName = Language.GetTextValue($"Mods.MidnightNohit.UI.UIButtons.{State}") + "\n" + IconHighlight;

                Main.blockMouse = Main.LocalPlayer.mouseInterface = true;
                if (NohitUtils.CanAndHasClickedUIElement)
                {
                    if (TogglesUIManager.UIOpen)
                        TogglesUIManager.CloseUI();
                    else
                        TogglesUIManager.OpenUI();
                    TogglesUIManager.ClickCooldownTimer = TogglesUIManager.ClickCooldownLength;
                    SoundEngine.PlaySound(SoundID.MenuTick, Main.LocalPlayer.Center);
                }
            }

            spriteBatch.Draw(Icon, IconCenter, null, Color.White, 0f, Icon.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
        }

    }
}