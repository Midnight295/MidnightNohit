using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using MidnightNohit.Core;

namespace MidnightNohit.Content.UI.Pages
{
    public static partial class UIManagerAutoloader
    {
        public const string PowerUIName = "PowersManager";

        public static void InitializePower()
        {
            List<PageUIElement> uIElements = new()
            {
                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Godmode", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/GodmodeGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.PowersUI.Godmode.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.PowersUI.Godmode.Description"),
                1f,
                () => { Toggles.GodmodeEnabled = !Toggles.GodmodeEnabled; },
                typeof(Toggles).GetField("GodmodeEnabled", NohitUtils.AllBindingFlags)
                ),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/InstantDeath", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/InstantDeathGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.PowersUI.InstantDeath.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.PowersUI.InstantDeath.Description"),
                2f,
                () => { Toggles.InstantDeath = !Toggles.InstantDeath; },
                typeof(Toggles).GetField("InstantDeath", NohitUtils.AllBindingFlags)
                ),

                /*new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Wings", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/WingsGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.PowersUI.InfiniteFlight.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.PowersUI.InfiniteFlight.Description"),
                3f,
                () => { Toggles.InfiniteFlightTime = !Toggles.InfiniteFlightTime; },
                typeof(Toggles).GetField("InfiniteFlightTime", NohitUtils.AllBindingFlags)
                ),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Potion", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/PotionGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.PowersUI.InfinitePotions.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.PowersUI.InfinitePotions.Description"),
                4f,
                () => { Toggles.InfinitePotions = !Toggles.InfinitePotions; },
                typeof(Toggles).GetField("InfinitePotions", NohitUtils.AllBindingFlags)
                ),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Ammo", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/AmmoGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.PowersUI.InfiniteAmmo.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.PowersUI.InfiniteAmmo.Description"),
                5f,
                () => { Toggles.InfiniteAmmo = !Toggles.InfiniteAmmo; },
                typeof(Toggles).GetField("InfiniteAmmo", NohitUtils.AllBindingFlags)
                ),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Cons", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/ConsGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.PowersUI.InfiniteConsumables.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.PowersUI.InfiniteConsumables.Description"),
                6f,
                () => { Toggles.InfiniteConsumables = !Toggles.InfiniteConsumables; },
                typeof(Toggles).GetField("InfiniteConsumables", NohitUtils.AllBindingFlags)
                )*/
            };

            TogglesPage uIManager = new(uIElements, PowerUIName, "Mods.MidnightNohit.UI.UIButtons.PowersUI", ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/playerUIIcon", AssetRequestMode.ImmediateLoad).Value, 6f);
            uIManager.TryRegister();
        }
    }
}