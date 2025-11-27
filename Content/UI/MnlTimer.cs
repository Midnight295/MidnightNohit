using MidnightNohit.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using ReLogic.Graphics;
using Terraria.GameContent;
using Terraria.Localization;
using MidnightNohit.Core;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using CalamityMod;
using Microsoft.Xna.Framework.Graphics;
using NoxusBoss.Content.NPCs.Bosses.Avatar.FirstPhaseForm;
using NoxusBoss.Content.NPCs.Bosses.Avatar.SecondPhaseForm;

namespace MidnightNohit.Content.UI
{
    public class MnlTimer
    {
        internal const float defaultX = 97.5f;
        internal const float defaultY = 54.17f;
        public static string text;
        public static void Draw(Player player)
        {
            if (Main.gameMenu || !NohitConfig.Instance.MNLTimer || !Main.CurrentFrameFlags.AnyActiveBossNPC)
                return;

            //Main.NewText("I AM GETTING DRAWN");

            Vector2 screenRatioPosition = new Vector2(NohitConfig.Instance.MNLX, NohitConfig.Instance.MNLY) * 10;
            if (screenRatioPosition.X < 0f || screenRatioPosition.X > 100f)
                screenRatioPosition.X = defaultX;
            if (screenRatioPosition.Y < 0f || screenRatioPosition.Y > 100f)
                screenRatioPosition.Y = defaultY;

            Vector2 screenpos = screenRatioPosition;
            screenpos.X = (int)(screenpos.X * 0.01f * Main.screenWidth);
            screenpos.Y = (int)(screenpos.Y * 0.01f * Main.screenWidth);

            text =  NohitUtils.Minutes + ":" + NohitUtils.DeadSpace + NohitUtils.Seconds;

            if (ModCompatability.WrathoftheGods.Loaded)
            {
                FunnyAvatarCompatability();
            }

            Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, text, screenpos.X, screenpos.Y, Color.White, Color.Black, default, 1.01f);           
        }

        [JITWhenModsEnabled(ModCompatability.WrathoftheGods.Name)]
        public static void FunnyAvatarCompatability()
        {
            if (Main.LocalPlayer.name != "midnight295.")
                return;

            if (AvatarOfEmptiness.Myself is not null)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    if (Main.npc[i].type == ModContent.NPCType<AvatarOfEmptiness>() && Main.npc[i].active)
                        if (Main.npc[i].life <= Main.npc[i].lifeMax * 0.6f)
                        {
                            text = Main.rand.Next(1, 10) + ":" + NohitUtils.DeadSpace + Main.rand.Next(1, 100);
                        }
                }
            }
        }
    }
}
