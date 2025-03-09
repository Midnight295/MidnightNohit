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

namespace MidnightNohit.Content.UI
{
    public class MnlTimer
    {
        internal const float defaultX = 97.5f;
        internal const float defaultY = 54.17f;
        public static void Draw(Player player)
        {
            if (Main.gameMenu || !NohitConfig.Instance.MNLTimer || !NohitUtils.IsAnyBossesAlive())
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

            string text =  NohitUtils.Minutes + ":" + NohitUtils.DeadSpace + NohitUtils.Seconds;

            Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, text, screenpos.X, screenpos.Y, Color.White, Color.Black, default, 1.01f);           
        }
    }
}
