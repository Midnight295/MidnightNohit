using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;
using MidnightNohit.Core;
using MidnightNohit.Config;
using MidnightNohit.Content.UI.Pages.Configs;

namespace MidnightNohit.Content.UI.Pages
{
    public static partial class UIManagerAutoloader
    {
        public const string ToggleUIName = "TogglesUI";
        public static string miscToggles = GameCulture.FromCultureName(GameCulture.CultureName.Chinese).IsActive? "杂项设置":"Misc Toggles";

        public static void InitializeToggles()
        {
            List<PageUIElement> uIElements = new()
            {
                new InstantKill(),
                new IFrames(),
            };

            TogglesPage uIManager = new(uIElements, ToggleUIName, "Mods.MidnightNohit.UI.UIButtons.TogglesUI" /*Language.GetTextValue($"Mods.MidnightNohit.UI.UIButtons.MiscUI")*/, ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/Buttons/ToggleUI", AssetRequestMode.ImmediateLoad).Value, 5f);
            uIManager.TryRegister();
        }   
    }
}
