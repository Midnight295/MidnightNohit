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

namespace MidnightNohit.Content.UI.MiscUI
{
    public class CheatIndicatorUIRenderer
    {

        public static void Draw(SpriteBatch spriteBatch)
        {
            float scale = 1;
            Texture2D Icon;
            //if (NohitConfig.Instance.GodMode)
            //    Icon = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/cheatGodUIIcon").Value;
            if (NohitConfig.Instance.InstantKill)
                Icon = ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/CheatRenderer/HeartIconInstantDeath").Value;
            else
                Icon = ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/CheatRenderer/HeartIcon").Value;
            // The Textures of the icon, and when you hover over it.
            Texture2D HoverIcon = ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/CheatRenderer/HeartIconGlow").Value;
            if (NohitConfig.Instance.InstantKill)
            {
                HoverIcon = ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/CheatRenderer/HeartIconInstantDeathGlow").Value;
            }

            // These set the center of the icon, and the "hitbox" around it. Play around with the Vector floats to change position.
            // This does not scale properly
            // Vector2 IconCenter = new Vector2((float)Main.screen
            // Width - /*Main.UIScale*/ 285f, /*Main.UIScale*/ (float)Main.screenHeight - 5f) + Utils.Size(Icon) * 0.5f;
            // This stays in the same place, do it like this :)
            Vector2 IconCenter = new Vector2(Main.screenWidth * Main.UIScale - (Main.GameModeInfo.IsJourneyMode ? 1850 : 1897), 265f) + Icon.Size() * 0.5f;
            // Rectangle area of the icon to check for hovering.
            Rectangle iconRectangeArea = Utils.CenteredRectangle(IconCenter, Icon.Size());

            // This gets the "hitbox" of the mouse, and checks if its intersecting with the "hitbox" of our icon.
            Rectangle mouseHitbox = new(Main.mouseX, Main.mouseY, 2, 2);
            bool isHovering = mouseHitbox.Intersects(iconRectangeArea);

            // If we are hovering over it, change the Icon Texture to the Hover Icon Texture.
            if (isHovering)
            {
                scale = 1.15f;
                spriteBatch.Draw(HoverIcon, IconCenter, null, Color.Yellow, 0f, Icon.Size() * 0.5f, 1f * scale, 0, 0f);
                string State;
                State = TogglesUIManager.UIOpen ? "CloseUI" : "OpenUI";

                string IconHighlight;
                if (Toggles.GodmodeEnabled)
                    IconHighlight = Language.GetTextValue($"Mods.MidnightNohit.UI.UIButtons.PlayerCheat.Godmode");
                else if (Toggles.InfiniteFlightTime)
                    IconHighlight = Language.GetTextValue($"Mods.MidnightNohit.UI.UIButtons.PlayerCheat.InfiniteFlight");
                else if (Toggles.InfiniteMana)
                    IconHighlight = Language.GetTextValue($"Mods.MidnightNohit.UI.UIButtons.PlayerCheat.InfiniteMana");
                else if (NohitConfig.Instance.InstantKill)
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

            // Now, draw the icon in the correct place.
            spriteBatch.Draw(Icon, IconCenter, null, Color.White, 0f, Icon.Size() * 0.5f, 1f * scale, SpriteEffects.None, 0f);
        }

    }
}