using Microsoft.Xna.Framework.Graphics;
using MidnightNohit.Config;
using MidnightNohit.Content.UI.Pages;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Localization;
using Terraria.ModLoader;

public class PracticeMode : PageUIElement
{
    public override Texture2D Texture => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/TogglesUI/gravestone", AssetRequestMode.ImmediateLoad).Value;
    public override Texture2D GlowTexture => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/TogglesUI/gravestoneGlow", AssetRequestMode.ImmediateLoad).Value;

    public override string Description => Language.GetTextValue($"Mods.MidnightNohit.Configs.NohitConfig.PracticeMode.ShortenedTooltip");
    public override string Name => Language.GetTextValue($"Mods.MidnightNohit.Configs.NohitConfig.PracticeMode.Label");

    public override bool Toggle => NohitConfig.Instance.PracticeMode;
    public override void OnClick()
    {
        NohitConfig.Instance.PracticeMode = !NohitConfig.Instance.PracticeMode;
        NohitConfig.Instance.InstantKill = false;
        NohitConfig.Instance.DisableIframes = false;
        NohitConfig.Instance.SaveChanges();
    }
}
