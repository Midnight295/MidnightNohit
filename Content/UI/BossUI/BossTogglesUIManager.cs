using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using MidnightNohit.Core.Systems.TieringSystems;
using MidnightNohit.Core;
using Terraria.GameContent;

namespace MidnightNohit.Content.UI.BossUI
{
    public class BossTogglesUIManager
    {
        #region Fields/Properties
        internal static List<BossToggleElement> BossElements
        {
            get;
            private set;
        } = new();

        private static Vector2 ScrollbarOffset = new(83, 15);

        public const int HorizontalOffset = 70;

        public const int VerticalOffset = 50;
        #endregion

        #region Methods
        public static void InitializeBossElements()
        {
            new BossToggleElement(false, "Images/NPC_Head_Boss_7", Language.GetTextValue($"NPCName.KingSlime"),
                typeof(NPC).GetField("downedSlimeKing", NohitUtils.AllBindingFlags), Weights.PostKingSlime).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_0", Language.GetTextValue($"NPCName.EyeofCthulhu"),
                typeof(NPC).GetField("downedBoss1", NohitUtils.AllBindingFlags), Weights.PostEyeOfCthulhu).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_2", Language.GetTextValue($"NPCName.EaterofWorldsHead"),
                typeof(TieringSystem).GetField("_downedEater", NohitUtils.AllBindingFlags), Weights.PostEaterOfWorlds).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_23", Language.GetTextValue($"NPCName.BrainofCthulhu"),
                typeof(TieringSystem).GetField("_downedBrain", NohitUtils.AllBindingFlags), Weights.PostBrainOfCthulhu).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_14", Language.GetTextValue($"NPCName.QueenBee"),
                typeof(NPC).GetField("downedQueenBee", NohitUtils.AllBindingFlags), Weights.PostQueenBee).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_39", Language.GetTextValue($"NPCName.Deerclops"),
                typeof(NPC).GetField("downedDeerclops", NohitUtils.AllBindingFlags), Weights.PostDeerclops, 0.85f).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_19", Language.GetTextValue($"NPCName.SkeletronHead"),
                typeof(NPC).GetField("downedBoss3", NohitUtils.AllBindingFlags), Weights.PostSkeletron).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_22", Language.GetTextValue($"NPCName.WallofFlesh"),
                typeof(Main).GetField("hardMode", NohitUtils.AllBindingFlags), Weights.PostWallOfFlesh).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_38", Language.GetTextValue($"NPCName.QueenSlimeBoss"),
                typeof(NPC).GetField("downedQueenSlime", NohitUtils.AllBindingFlags), Weights.PostQueenSlime).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_16", Language.GetTextValue($"Enemies.TheTwins"),
                typeof(NPC).GetField("downedMechBoss2", NohitUtils.AllBindingFlags), Weights.PostTwins).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_25", Language.GetTextValue($"NPCName.TheDestroyer"),
                typeof(NPC).GetField("downedMechBoss1", NohitUtils.AllBindingFlags), Weights.PostDestroyer).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_18", Language.GetTextValue($"NPCName.SkeletronPrime"),
                typeof(NPC).GetField("downedMechBoss3", NohitUtils.AllBindingFlags), Weights.PostSkeletronPrime).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_11", Language.GetTextValue($"NPCName.Plantera"),
                typeof(NPC).GetField("downedPlantBoss", NohitUtils.AllBindingFlags), Weights.PostPlantera).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_5", Language.GetTextValue($"NPCName.Golem"),
                typeof(NPC).GetField("downedGolemBoss", NohitUtils.AllBindingFlags), Weights.PostGolem).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_37", Language.GetTextValue($"NPCName.HallowBoss"),
                typeof(NPC).GetField("downedEmpressOfLight", NohitUtils.AllBindingFlags), Weights.PostEmpressOfLight).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_4", Language.GetTextValue($"NPCName.DukeFishron"),
                typeof(NPC).GetField("downedFishron", NohitUtils.AllBindingFlags), Weights.PostDukeFishron).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_24", Language.GetTextValue($"NPCName.CultistBoss"),
                typeof(NPC).GetField("downedAncientCultist", NohitUtils.AllBindingFlags), Weights.PostLunaticCultist).Register();

            new BossToggleElement(false, "Images/NPC_Head_Boss_8", Language.GetTextValue($"Enemies.MoonLord"),
                typeof(NPC).GetField("downedMoonlord", NohitUtils.AllBindingFlags), Weights.PostMoonlord).Register();         
        }

        public static void AddBossElement(BossToggleElement element)
        {
            BossElements.Add(element);
            BossElements = BossElements.OrderBy(e => e.Weight).ToList();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            // Draw the background.
            Texture2D backgroundTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/BossUI/BossListBackground", (AssetRequestMode)2).Value;
            Texture2D glowTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/BossUI/BossListGlow", (AssetRequestMode)2).Value;

            Vector2 drawCenter;
            drawCenter.X = Main.screenWidth / 2;
            drawCenter.Y = Main.screenHeight / 2;
            // This spawn pos is very important. As it is affected by Main.screenWidth/Height, it will scale properly. Every single thing you draw needs to use
            // this vector, unless they are a completely new one and use Main.screenWidth.Height themselves for the VERY BASE of their definition.
            Vector2 spawnPos = drawCenter + new Vector2(300, 0);

            spriteBatch.Draw(backgroundTexture, spawnPos, null, Color.White, 0, backgroundTexture.Size() * 0.5f, 1f, 0, 0);
            spriteBatch.Draw(glowTexture, spawnPos, null, Color.Cyan, 0, backgroundTexture.Size() * 0.5f, 1f, 0, 0);


            // Block the mouse if we are hovering over it.
            Rectangle hoverArea = Utils.CenteredRectangle(spawnPos, backgroundTexture.Size());
            Rectangle mouseHitbox = new(Main.mouseX, Main.mouseY, 2, 2);
            bool isHovering = mouseHitbox.Intersects(hoverArea);
            if (isHovering)
            {
                Main.blockMouse = Main.LocalPlayer.mouseInterface = true;
            }

            // Go to the next things to draw, passing in spawnPos for convienience.
            DrawElements(spriteBatch, spawnPos);
        }

        public static void DrawElements(SpriteBatch spriteBatch, Vector2 spawnPos)
        {
            #region KillAllBosses
            // ALL THE TEXTURES
            Texture2D crossTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Cross", (AssetRequestMode)2).Value;
            Texture2D crossGlowTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/CrossGlow", (AssetRequestMode)2).Value;
            Texture2D tickTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Tick", (AssetRequestMode)2).Value;
            Texture2D tickGlowTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/TickGlow", (AssetRequestMode)2).Value;
            Texture2D whiteGlowSmall = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/SmallerWhiteRect", (AssetRequestMode)2).Value;
            // Get the mouse hitbox
            Rectangle mouseHitbox = new(Main.mouseX, Main.mouseY, 2, 2);

            // Scrollable icons

            // The method I use here to make things disapear when scrolling so they dont "break out" of their container is.. scuffed? honestly i dont know how else
            // you would do this, and it works very well. The way i wrote it is probably not that great, but its fully functional so uh, ye.
            // The below sets up the two zones after drawing the boss icons, so that they draw over the icons, allowing the icons to stop drawing when fully under.
            Texture2D deleteIconTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/BossUI/ThingForScrolling", (AssetRequestMode)2).Value;
            Texture2D deleteIconTextureBottom = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/BossUI/ThingForScrollingBottom", (AssetRequestMode)2).Value;
            Texture2D deleteIconTextureGlow = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/BossUI/ThingForScrollingGlow", (AssetRequestMode)2).Value;
            Vector2 deleteIconCenter = spawnPos + new Vector2(-34, -154);
            Vector2 deleteIconCenter2 = spawnPos + new Vector2(-40, 173);
            Vector2 deleteIconCenter3 = spawnPos + new Vector2(-34, 161);

            // We want to draw these first so they go under the kill zones.
            DrawBossIcons(spriteBatch, spawnPos, deleteIconCenter, deleteIconCenter2);

            // Draw the kill zones. This is for detecting if it scrolls, if the center of it is above or below these, it will stop drawing to keep it in bounds.

            spriteBatch.Draw(deleteIconTexture, deleteIconCenter, null, Color.White, 0, deleteIconTexture.Size() * 0.5f, 1f, 0, 0);
            spriteBatch.Draw(deleteIconTextureBottom, deleteIconCenter2, null, Color.White, 0, deleteIconTexture.Size() * 0.5f, 1f, 0, 0);
            spriteBatch.Draw(deleteIconTextureGlow, deleteIconCenter3, null, Color.Cyan, 0, deleteIconTexture.Size() * 0.5f, 1f, 0, 0);

            // Mark all as alive button stuff.
            Vector2 tickPos = new(-95f, -155f);
            Rectangle tickHoverRect = Utils.CenteredRectangle(spawnPos + tickPos, whiteGlowSmall.Size());
            if (mouseHitbox.Intersects(tickHoverRect))
            {
                spriteBatch.Draw(whiteGlowSmall, spawnPos + tickPos, null, Color.White * 0.3f, 0, whiteGlowSmall.Size() * 0.5f, 0.7f, 0, 0);
                Rectangle tickGlowRect = Utils.CenteredRectangle(spawnPos + tickPos, tickTexture.Size());
                if (mouseHitbox.Intersects(tickGlowRect))
                {
                    spriteBatch.Draw(tickGlowTexture, spawnPos + tickPos, null, Color.White, 0, tickGlowTexture.Size() * 0.5f, 1.4f, 0, 0);
                    Main.hoverItemName = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.BossUI.EnableAll");
                    if ((Main.mouseLeft && Main.mouseLeftRelease || Main.mouseRight && Main.mouseRightRelease) && TogglesUIManager.ClickCooldownTimer == 0)
                    {
                        // On click stuff
                        MarkAllBossesAsX(false);
                        TogglesUIManager.ClickCooldownTimer = TogglesUIManager.ClickCooldownLength;
                        SoundEngine.PlaySound(SoundID.MenuTick, Main.LocalPlayer.Center);
                    }
                }
            }
            spriteBatch.Draw(tickTexture, spawnPos + tickPos, null, Color.White, 0, tickTexture.Size() * 0.5f, 1.4f, 0, 0);

            // Mark all as dead button.
            Vector2 crossPos = new(25f, -154f);
            Rectangle crossHoverRect = Utils.CenteredRectangle(spawnPos + crossPos, whiteGlowSmall.Size());
            if (mouseHitbox.Intersects(crossHoverRect))
            {
                spriteBatch.Draw(whiteGlowSmall, spawnPos + crossPos, null, Color.White * 0.3f, 0, whiteGlowSmall.Size() * 0.5f, 0.7f, 0, 0);
                Rectangle crossGlowRect = Utils.CenteredRectangle(spawnPos + crossPos, tickTexture.Size());
                if (mouseHitbox.Intersects(crossGlowRect))
                {
                    spriteBatch.Draw(crossGlowTexture, spawnPos + crossPos, null, Color.White, 0, crossGlowTexture.Size() * 0.5f, 1.4f, 0, 0);
                    Main.hoverItemName = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.BossUI.DisableAll");
                    if ((Main.mouseLeft && Main.mouseLeftRelease || Main.mouseRight && Main.mouseRightRelease) && TogglesUIManager.ClickCooldownTimer == 0)
                    {
                        MarkAllBossesAsX(true);
                        TogglesUIManager.ClickCooldownTimer = TogglesUIManager.ClickCooldownLength;
                        SoundEngine.PlaySound(SoundID.MenuTick, Main.LocalPlayer.Center);
                    }
                }
            }
            spriteBatch.Draw(crossTexture, spawnPos + crossPos, null, Color.White, 0, crossTexture.Size() * 0.5f, 1.4f, 0, 0);
            #endregion

            #region Info
            /*Texture2D infoTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Info").Value;
            Texture2D infoGlowTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/InfoGlow").Value;

            Vector2 infoPos = new(-10f, -154f);
            Rectangle infoHoverRect = Utils.CenteredRectangle(spawnPos + infoPos, whiteGlowSmall.Size());

            if (mouseHitbox.Intersects(infoHoverRect))
            {
                Rectangle infoGlowHoverRect = Utils.CenteredRectangle(spawnPos + infoPos, infoTexture.Size());

                spriteBatch.Draw(whiteGlowSmall, spawnPos + infoPos, null, Color.White * 0.3f, 0, whiteGlowSmall.Size() * 0.5f, 1f, 0, 0);
                if (mouseHitbox.Intersects(infoGlowHoverRect))
                    spriteBatch.Draw(infoGlowTexture, spawnPos + infoPos, null, Color.White, 0, infoGlowTexture.Size() * 0.5f, 1.2f, 0, 0);

                Main.hoverItemName = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.BossUI.Explanation") + "\n" + Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.BossUI.Explanation2");

            }
            spriteBatch.Draw(infoTexture, spawnPos + infoPos, null, Color.White, 0, infoTexture.Size() * 0.5f, 1.2f, 0, 0);*/
            #endregion

            #region Scrollbar
            Texture2D scrollbarBackgroundTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/scrollbarBackground", (AssetRequestMode)2).Value;
            Texture2D scrollbarTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/fullScrollbar", (AssetRequestMode)2).Value;
            Vector2 scrollbarBackgroundOffset = new(83, 8);
            spriteBatch.Draw(scrollbarBackgroundTexture, spawnPos + scrollbarBackgroundOffset, null, Color.White, 0, scrollbarBackgroundTexture.Size() * 0.5f, 1, 0, 0);

            // I didnt want to pass this Rectangle through as a parameter so i re-get the background rectangle here. This is to allow for scrolling with the mouse wheel.
            Texture2D backgroundTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/baseSettingsUIBackgroundWide", (AssetRequestMode)2).Value;
            Rectangle backRect = Utils.CenteredRectangle(spawnPos, backgroundTexture.Size());

            float maxScrollDistance = -50f;
            if (BossElements.Count / 3f < 5f)
                maxScrollDistance = 0f;
            else
                maxScrollDistance *= MathF.Ceiling((BossElements.Count / 3f) - 5f);

            if (mouseHitbox.Intersects(backRect))
            {
                PlayerInput.LockVanillaMouseScroll("BossUI");
                // This means the mouse wheel has moved up.
                if (PlayerInput.MouseInfo.ScrollWheelValue - PlayerInput.MouseInfoOld.ScrollWheelValue > 0)
                {
                    // This need it minused not added, I have no fucking idea why lmao.
                    ScrollbarOffset.Y -= 50 * 0.47f;
                    ScrollbarOffset.Y = MathHelper.Clamp(ScrollbarOffset.Y, 8f, -maxScrollDistance);
                }
                // This means the wheel moved down. The same thing happens inside here as above, just in the other direction.
                else if (PlayerInput.MouseInfo.ScrollWheelValue - PlayerInput.MouseInfoOld.ScrollWheelValue < 0)
                {

                    ScrollbarOffset.Y += 50 * 0.47f;
                    ScrollbarOffset.Y = MathHelper.Clamp(ScrollbarOffset.Y, 8f, -maxScrollDistance);
                }
            }

            Vector2 scrollOffset = ScrollbarOffset;
            //if (-maxScrollDistance > 235f)
                scrollOffset.Y = Utils.Remap(scrollOffset.Y, 8f, -maxScrollDistance, 8f, 235f);

            spriteBatch.Draw(scrollbarTexture, spawnPos + scrollOffset, null, Color.White, 0, scrollbarTexture.Size() * 0.5f, 1f, 0, 0);
            #endregion
        }

        public static void DrawBossIcons(SpriteBatch spriteBatch, Vector2 spawnPos, Vector2 killIfAbove, Vector2 killIfBelow)
        {
            // Get all of the base textures.
            Texture2D deleteIconTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/BossUI/ThingForScrolling", (AssetRequestMode)2).Value;
            Texture2D deleteIconTextureBottom = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/BossUI/ThingForScrollingBottom", (AssetRequestMode)2).Value;
            Texture2D deleteIconTextureGlow = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/BossUI/ThingForScrollingGlow", (AssetRequestMode)2).Value;
            Texture2D crossTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Cross", (AssetRequestMode)2).Value;
            Texture2D crossGlowTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/CrossGlow", (AssetRequestMode)2).Value;
            Texture2D tickTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Tick", (AssetRequestMode)2).Value;
            Texture2D tickGlowTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/TickGlow", (AssetRequestMode)2).Value;

            // And the initial draw position.
            Vector2 drawPosition = spawnPos + new Vector2(-105, -90);

            for (int i = 0; i < BossElements.Count; i++)
            {
                if (i > 0)
                {
                    if (i % 3 == 0)
                    {
                        drawPosition.X -= HorizontalOffset * 2f;
                        drawPosition.Y += VerticalOffset;
                    }
                    else
                        drawPosition.X += HorizontalOffset;
                }

                Vector2 drawPositionFinal = drawPosition - Vector2.UnitY * ScrollbarOffset.Y;
                BossToggleElement element = BossElements[i];

                // Only draw it if we are inside the bounds.
                if (drawPositionFinal.Y !> killIfAbove.Y && drawPositionFinal.Y !< killIfBelow.Y)
                {
                    bool dead = element.GetStatus();
                    Texture2D tickOrCross = dead ? crossTexture : tickTexture;
                    Texture2D tickOrCrossGlow = dead ? crossGlowTexture : tickGlowTexture;

                    // Get a bunch of Rectangles.
                    Rectangle hitbox = Utils.CenteredRectangle(drawPositionFinal, element.Texture.Size() * element.Scale);
                    Rectangle indicatorHitbox = Utils.CenteredRectangle(drawPositionFinal + new Vector2(10, 10), tickOrCross.Size());
                    Rectangle mouseHitbox = new(Main.mouseX, Main.mouseY, 2, 2);

                    // nono and nono2 are the rects of the kill zones. You dont want to be able to interact with the icons through it, so
                    // ensure you arent hovering over it. No, I do not know why I deemed this a fitting name.
                    Rectangle nono = Utils.CenteredRectangle(killIfAbove, deleteIconTexture.Size());
                    Rectangle nono2 = Utils.CenteredRectangle(killIfBelow, deleteIconTextureGlow.Size());
                    Rectangle nono3 = Utils.CenteredRectangle(killIfBelow, deleteIconTextureBottom.Size());
                    bool dontDraw = mouseHitbox.Intersects(nono) || mouseHitbox.Intersects(nono2) || mouseHitbox.Intersects(nono3);

                    //Used to increase Boss Icon size when hovered.
                    float scalemult = 1;

                    Texture2D whiteTexture = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/BossIcons/bossWhiteRect", (AssetRequestMode)2).Value;
                    Rectangle whiteRect = Utils.CenteredRectangle(drawPositionFinal, whiteTexture.Size());

                    if (mouseHitbox.Intersects(whiteRect))
                    {
                        // Draw white texture
                        spriteBatch.Draw(whiteTexture, drawPositionFinal, null, Color.White * 0.15f, 0, whiteTexture.Size() * 0.5f, 1, 0, 0);

                        // If we are hovering over the icon and can draw
                        if (mouseHitbox.Intersects(hitbox) && !dontDraw)
                        {
                            // Draw it and set the mouse text.
                            scalemult = 1.2f;
                            //spriteBatch.Draw(element.GlowTexture, drawPositionFinal, null, Color.White, 0, element.GlowTexture.Size() * 0.5f, element.Scale, 0, 0);
                            Main.hoverItemName = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.BossUI.Toggle", element.Name);
                        }
                        if (NohitUtils.CanAndHasClickedUIElement)
                        {
                            if (Main.keyState.IsKeyDown(Keys.LeftShift))
                            {
                                float maxLayer = element.Weight;

                                bool statusToSetTo = element.GetStatus();

                                bool playSound = false;

                                foreach (var element2 in BossElements)
                                {
                                    if (element2.Weight >= maxLayer)
                                        continue;

                                    if (element2.GetStatus() == statusToSetTo)
                                        continue;

                                    element2.MarkAsStatus(statusToSetTo);
                                    playSound = true;
                                }
                                if (playSound)
                                    SoundEngine.PlaySound(SoundID.MenuTick, Main.LocalPlayer.Center);
                            }
                            else
                            {
                                element.ToggleValue();
                                SoundEngine.PlaySound(SoundID.MenuTick, Main.LocalPlayer.Center);
                            }
                        }
                    }
                    // Draw the base texture.
                    

                    spriteBatch.Draw(element.Texture, drawPositionFinal, null, Color.White, 0, element.Texture.Size() * 0.5f, element.Scale * scalemult, 0, 0);

                    // Draw the indicator.
                    string status = dead ? Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.BossUI.Dead") : Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.BossUI.Alive");
                    spriteBatch.Draw(tickOrCross, drawPositionFinal + new Vector2(10, 10), null, Color.White, 0, tickOrCross.Size() * 0.5f, 1, 0, 0);

                    // If we are hovering over it, and can draw
                    if (mouseHitbox.Intersects(indicatorHitbox) && !dontDraw)
                    {
                        // Draw it and set the mouse text.
                        spriteBatch.Draw(tickOrCrossGlow, drawPositionFinal + new Vector2(10, 10), null, Color.White, 0, tickOrCrossGlow.Size() * 0.5f, 1, 0, 0);
                        Main.hoverItemName = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.BossUI.Toggle", element.Name) + "\n" + status;
                    }
                }
            }
        }

        public static void MarkAllBossesAsX(bool value)
        {
            foreach (var element in BossElements)
                element.MarkAsStatus(value);
        }
        #endregion
    }
}