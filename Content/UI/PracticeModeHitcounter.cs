using CalamityMod.Debugging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MidnightNohit.Config;
using MidnightNohit.Core;
using MidnightNohit.Core.ModPlayers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.Localization;

namespace MidnightNohit.Content.UI;

public class PracticeModeHitcounter
{
    internal const float defaultX = 75f;
    internal const float defaultY = .15f;
    public static string text;
    public static float Opacity;
    public static int disablingLerp;
    public static int enablingLerp;

    public static void Draw(Player player)
    {
        Color color = Color.White;
        if (NohitConfig.Instance.PracticeMode)
        {
            disablingLerp = 0;
            Opacity = MathHelper.Lerp(0, 1, ++enablingLerp * 0.06f);
        }
        else
        {
            enablingLerp = 0;
            Opacity = MathHelper.Lerp(1, 0, ++disablingLerp * 0.06f);
        }

        text = Language.GetTextValue("Mods.MidnightNohit.UI.HitsTaken");

        Vector2 textSize = FontAssets.ItemStack.Value.MeasureString(text);
        Vector2 screenpos = new Vector2(
        Main.screenWidth - 440,
        0) + textSize / 2;

        int hitsTaken = player.GetModPlayer<NohitPlayer>().PracticeHitsTaken;

        SpriteBatch sb = Main.spriteBatch;
        

        Utils.DrawBorderStringFourWay(sb, FontAssets.ItemStack.Value, text, screenpos.X, screenpos.Y, color * Opacity, Color.Black * Opacity, Vector2.Zero, 1f);
        Utils.DrawBorderStringFourWay(sb, FontAssets.DeathText.Value, hitsTaken.ToString(), screenpos.X + (textSize.X / 3f), screenpos.Y + FontAssets.ItemStack.Value.MeasureString(hitsTaken.ToString()).Y, color * Opacity, Color.Black * Opacity, default, 1f);
    }
}
