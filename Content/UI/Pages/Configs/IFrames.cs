using Microsoft.Xna.Framework.Graphics;
using MidnightNohit.Config;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MidnightNohit.Content.UI.Pages.Configs
{
    public class IFrames : PageUIElement
    {
        public override Texture2D Texture => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/TogglesUI/IFrames", AssetRequestMode.ImmediateLoad).Value;
        public override Texture2D GlowTexture => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/TogglesUI/IFramesGlow", AssetRequestMode.ImmediateLoad).Value;

        public override string Description => Language.GetTextValue($"Mods.MidnightNohit.Configs.NohitConfig.DisableIframes.Tooltip");
        public override string Name => Language.GetTextValue($"Mods.MidnightNohit.Configs.NohitConfig.DisableIframes.Label").Replace("[i:554] ", "");

        public override bool Toggle => NohitConfig.Instance.DisableIframes;
        public override void OnClick()
        {
            NohitConfig.Instance.DisableIframes = !NohitConfig.Instance.DisableIframes;
            NohitConfig.Instance.SaveChanges();
        }
    }
}
