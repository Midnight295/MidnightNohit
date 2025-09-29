using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using MidnightNohit.Core;
using MidnightNohit.Content.UI.Pages.Configs;

namespace MidnightNohit.Content.UI.Pages
{
    public static partial class UIManagerAutoloader
    {
        public const string PowerUIName = "UpgradesUI";

        public static void InitializePermanentUpgrades()
        {
            List<PageUIElement> uIElements = new()
            {
                new IFrames(),
            };

            TogglesPage uIManager = new(uIElements, PowerUIName, "Mods.MidnightNohit.UI.UIButtons.UpgradesUI", ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/Buttons/UpgradesUI", AssetRequestMode.ImmediateLoad).Value, 6f);
            uIManager.TryRegister();
        }
    }
}