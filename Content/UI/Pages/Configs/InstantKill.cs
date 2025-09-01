using Microsoft.Xna.Framework;
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
    public class InstantKill : PageUIElement
    {
        public override Texture2D Texture => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/TogglesUI/gravestone", AssetRequestMode.ImmediateLoad).Value;
        public override Texture2D GlowTexture => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/TogglesUI/gravestoneGlow", AssetRequestMode.ImmediateLoad).Value;

        public override string Description => Language.GetTextValue($"Mods.MidnightNohit.Configs.NohitConfig.InstantKill.Tooltip");
        public override string Name => Language.GetTextValue($"Mods.MidnightNohit.Configs.NohitConfig.InstantKill.Label").Replace("[i:1274] ", "");

        public override bool Toggle => NohitConfig.Instance.InstantKill;
        public override void OnClick()
        {
            NohitConfig.Instance.InstantKill = !NohitConfig.Instance.InstantKill;
            NohitConfig.Instance.SaveChanges();
        }
    }
}
