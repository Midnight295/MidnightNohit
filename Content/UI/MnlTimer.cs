using MidnightNohit.Config;
using Terraria;
using Terraria.GameContent;
using MidnightNohit.Core;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using Terraria.ID;

namespace MidnightNohit.Content.UI;

public class MnlTimer
{
    internal const float defaultX = 97.5f;
    internal const float defaultY = 54.17f;
    public static string text;
    public static float Opacity;
    public static int disablingLerp;
    public static int enablingLerp;
    public static TimeSpan Time;

    public static bool AtCursor = false;
    public static void Draw(Player player)
    {
        if (!NohitConfig.Instance.MNLTimer)
            return;

        Color color = Color.White;

        if (!Main.CurrentFrameFlags.AnyActiveBossNPC)
        {
            enablingLerp = 0;
            Opacity = MathHelper.Lerp(1, 0, ++disablingLerp * (player.dead? 0.03f : 0.01f));
            if (player.dead)
                color = Color.Red;
            else
                color = Color.Green;
        }
        else
        {
            disablingLerp = 0;
            Opacity = MathHelper.Lerp(0, 1, ++enablingLerp * 0.03f);

            if (Main.gamePaused)
            {
                if (NohitUtils.MNLTimer.IsRunning)
                    NohitUtils.MNLTimer.Stop();
            }
            else
                NohitUtils.MNLTimer.Start();

            Time = NohitUtils.MNLTimer.Elapsed;
        }
        string secondSplit = Time.Seconds <= 9 ? "0" : "";
        string milisecondSplit = Time.Milliseconds <= 9 ? "00" : Time.Milliseconds <= 99 ? "0" : "";
        text = Time.Minutes + ":" + secondSplit + Time.Seconds + ":" + milisecondSplit + Time.Milliseconds;

        Vector2 screenRatioPosition = new Vector2(NohitConfig.Instance.MNLX, NohitConfig.Instance.MNLY) * 10;
        if (screenRatioPosition.X < 0f || screenRatioPosition.X > 100f)
            screenRatioPosition.X = defaultX;
        if (screenRatioPosition.Y < 0f || screenRatioPosition.Y > 100f)
            screenRatioPosition.Y = defaultY;

        Vector2 screenpos = screenRatioPosition;
        screenpos.X = (int)(screenpos.X * 0.01f * Main.screenWidth);
        screenpos.Y = (int)(screenpos.Y * 0.01f * Main.screenWidth);

        if (AtCursor)
            screenpos = Main.MouseWorld + new Vector2(0, FontAssets.ItemStack.Value.MeasureString(text).Y) - Main.screenPosition;

        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.ItemStack.Value, text, screenpos.X, screenpos.Y, color * Opacity, Color.Black * Opacity, default, 1f);
    }
}
