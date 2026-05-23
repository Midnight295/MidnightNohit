using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MidnightNohit.Core;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static MidnightNohit.Content.UI.Pages.ATogglesPage;

namespace MidnightNohit.Content.UI.Pages;

public abstract class PageUIElement
{
    public virtual string Name => "";
    public virtual string Description => "";

    public virtual Texture2D Texture => null;
    public virtual Texture2D GlowTexture => null;
    public virtual float Layer => 1f;
    public virtual ToggleBlockInformation? BlockInformation => null;

    public const string ColorTag = "c/ffcc44:";
    public const string DisabledTag = "c/de4444:";
    public static string EnabledText = Language.GetTextValue($"Mods.MidnightNohit.UI.UIButtons.Enabled");
    public static string DisabledText = Language.GetTextValue($"Mods.MidnightNohit.UI.UIButtons.Disabled", DisabledTag);

    public static Texture2D Lock => ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/lock", AssetRequestMode.ImmediateLoad).Value;
    public static Texture2D LockGlow => ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/lockGlow", AssetRequestMode.ImmediateLoad).Value;
    public static Texture2D Tick => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/Checkmark", AssetRequestMode.ImmediateLoad).Value;
    public static Texture2D TickGlow => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/CheckmarkGlow", AssetRequestMode.ImmediateLoad).Value;
    public static Texture2D Cross => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/Cross", AssetRequestMode.ImmediateLoad).Value;
    public static Texture2D CrossGlow => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/CrossGlow", AssetRequestMode.ImmediateLoad).Value;

    public static Texture2D IntegerButton => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/IntegerButton", AssetRequestMode.ImmediateLoad).Value;
    public static Texture2D IntegerButtonGlow => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/IntegerButtonGlow", AssetRequestMode.ImmediateLoad).Value;

    public static Vector2 IndicatorOffset => new(10f, 10f);

    public string HoverTextFormatted => $"[{ColorTag}{Description}]";

    public virtual void OnClick() { }

    public virtual void OnClick(bool clickType) { }


    /// <summary>
    /// The text that is displayed beneath an Integer based toggle's icon.
    /// </summary>
    /// <returns></returns>
    public virtual string GetIntToggleText() => "";

    public virtual bool Toggle => false;

    public virtual int OptionCount => 0;

    public virtual void Draw(Vector2 drawPosition, float backgroundWidth)
    {
        Vector2 iconDrawPosition = drawPosition - Vector2.UnitX * (backgroundWidth * 0.35f);
        Rectangle iconRectangle = Utils.CenteredRectangle(iconDrawPosition, Texture.Size());

        bool intToggle = OptionCount > 0;

        bool blocked = false;
        if (BlockInformation != null)
            blocked = !BlockInformation.Value.CanToggle();

        // Check if the element is being hovered over.
        Rectangle selectionRectangle = Utils.CenteredRectangle(drawPosition, HoverBackgroundTexture.Size());
        if (selectionRectangle.Intersects(NohitUtils.MouseRectangle))
        {

            Main.spriteBatch.Draw(HoverBackgroundTexture, drawPosition, null, Color.White * 0.15f, 0f, HoverBackgroundTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0.1f);

            string extraText = string.Empty;

            // If hovering over the icon, draw the glow texture.
            if (iconRectangle.Intersects(NohitUtils.MouseRectangle))
            {
                Main.spriteBatch.Draw(GlowTexture, iconDrawPosition, null, Color.Yellow, 0f, GlowTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0.2f);
                if (intToggle)
                    extraText = "\n" + $"Left Click to increment, Right Click to decrement.";
            }

            if (blocked)
                extraText = "\n" + $"[{DisabledTag}{BlockInformation.Value.ExtraHoverText}]";
            Main.hoverItemName = HoverTextFormatted + extraText;

            if (!intToggle)
            {
                if (NohitUtils.AnyClick)
                {
                    TogglesUIManager.ClickCooldownTimer = TogglesUIManager.ClickCooldownLength;
                    SoundEngine.PlaySound(SoundID.MenuTick, Main.LocalPlayer.Center);
                    OnClick();
                }
            }
            else
            {
                if (NohitUtils.RightClick)
                {
                    TogglesUIManager.ClickCooldownTimer = TogglesUIManager.ClickCooldownLength;
                    SoundEngine.PlaySound(SoundID.MenuTick, Main.LocalPlayer.Center);
                    OnClick(true);
                }
                if (NohitUtils.LeftClick)
                {
                    TogglesUIManager.ClickCooldownTimer = TogglesUIManager.ClickCooldownLength;
                    SoundEngine.PlaySound(SoundID.MenuTick, Main.LocalPlayer.Center);
                    OnClick(false);             
                }
            }
        }

        Main.spriteBatch.Draw(Texture, iconDrawPosition, null, Color.White, 0f, Texture.Size() * 0.5f, 1f, SpriteEffects.None, 0.2f);

        if (blocked)
        {
            Rectangle lockRectangle = Utils.CenteredRectangle(iconDrawPosition + IndicatorOffset, Lock.Size());
            if (lockRectangle.Intersects(NohitUtils.MouseRectangle))
                Main.spriteBatch.Draw(LockGlow, iconDrawPosition + IndicatorOffset, null, Color.White, 0f, LockGlow.Size() * 0.5f, 1f, SpriteEffects.None, 0.25f);
            else
                Main.spriteBatch.Draw(Lock, iconDrawPosition + IndicatorOffset, null, Color.White, 0f, Lock.Size() * 0.5f, 1f, SpriteEffects.None, 0.25f);
        }

        else 
        {
            //if (intToggle)
            //    return;

            Texture2D indicatorTexture = blocked ? Lock : Toggle ? Tick : Cross;
            Texture2D indicatorGlowTexture = blocked ? LockGlow : Toggle ? TickGlow : CrossGlow;

            Rectangle indicatorRectangle = Utils.CenteredRectangle(iconDrawPosition + IndicatorOffset, indicatorTexture.Size());
            if (indicatorRectangle.Intersects(NohitUtils.MouseRectangle) && !intToggle)
            {
                Main.spriteBatch.Draw(indicatorGlowTexture, iconDrawPosition + IndicatorOffset, null, Color.Yellow, 0f, indicatorGlowTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0.25f);
            
                // Also update the hover text, if it isnt already been set due to being blocked.
                if (!blocked && !intToggle)
                    Main.hoverItemName = HoverTextFormatted + "\n" + (Toggle ? EnabledText : DisabledText);
            }

            if (intToggle)
            {
                string text = GetIntToggleText();
                Vector2 size = FontAssets.MouseText.Value.MeasureString(text);
                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, text, iconDrawPosition.X - (size.X / 2.5f), iconDrawPosition.Y + IndicatorOffset.Y, Color.White, Color.Black, Vector2.Zero, 0.75f);
            }
            else
                Main.spriteBatch.Draw(indicatorTexture, iconDrawPosition + IndicatorOffset, null, Color.White, 0f, indicatorTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0.25f);
            
        }

        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, Name, iconDrawPosition.X + 25, iconDrawPosition.Y - 7, Color.White, Color.Black, Vector2.Zero, 0.75f);
    }
}
