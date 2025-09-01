using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using MidnightNohit.Content.UI.Pages;
using MidnightNohit.Core;
using MidnightNohit.Content.UI.Pages.Configs;

namespace MidnightNohit.Content.UI.Pages
{
    public static partial class UIManagerAutoloader
    {
        public const string WorldUIName = "WorldManager";


        public static void InitializeWorld()
        {
            List<PageUIElement> uIElements = new()
            {
                
                //new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Map", AssetRequestMode.ImmediateLoad).Value,
                //ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/MapGlow", AssetRequestMode.ImmediateLoad).Value,
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.RevealMap.Name"),
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.RevealMap.Description"),
                //1f,
                //() => { MapSystem.MapReveal = true; }),

                //new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Spawns", AssetRequestMode.ImmediateLoad).Value,
                //ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/SpawnsGlow", AssetRequestMode.ImmediateLoad).Value,
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.EnemySpawns.Name"),
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.EnemySpawns.Description"),
                //2f,
                //() => { Toggles.NoSpawns = !Toggles.NoSpawns; },
                //typeof(Toggles).GetField("NoSpawns", NohitUtils.AllBindingFlags)),

                //new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/time", AssetRequestMode.ImmediateLoad).Value,
                //ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/timeGlow", AssetRequestMode.ImmediateLoad).Value,
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.Time.TimeFlow.Name"),
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.Time.TimeFlow.Description"),
                //3f,
                //() => { Toggles.FrozenTime = !Toggles.FrozenTime; },
                //typeof(Toggles).GetField("FrozenTime", NohitUtils.AllBindingFlags)),

              

                //new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/water", AssetRequestMode.ImmediateLoad).Value,
                //ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/waterGlow", AssetRequestMode.ImmediateLoad).Value,
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.ToggleRain.Name"),
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.ToggleRain.Description"),
                //5f,
                //() => { Toggles.ToggleRain = !Toggles.ToggleRain; },
                //typeof(Toggles).GetField("ToggleRain", NohitUtils.AllBindingFlags)),

                //new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/biome", AssetRequestMode.ImmediateLoad).Value,
                //ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/biomeGlow", AssetRequestMode.ImmediateLoad).Value,
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.BiomeFountains.Name"),
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.BiomeFountains.Description"),
                //7f,
                //() => { Toggles.BiomeFountainsForceBiome = !Toggles.BiomeFountainsForceBiome; },
                //typeof(Toggles).GetField("BiomeFountainsForceBiome", NohitUtils.AllBindingFlags)),

                

                //new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/water", AssetRequestMode.ImmediateLoad).Value,
                //ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/waterGlow", AssetRequestMode.ImmediateLoad).Value,
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.MapTeleporting.Name"),
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.MapTeleporting.Description"),
                //10f,
                //() => { MapSystem.MapTeleport = !MapSystem.MapTeleport; },
                //typeof(MapSystem).GetField("MapTeleport", MidnightNohitUtils.UniversalBindingFlags)),
            }
            ;
            TogglesPage uIManager = new(uIElements, WorldUIName, "Mods.MidnightNohit.UI.UIButtons.WorldUI", ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/worldUIIcon", AssetRequestMode.ImmediateLoad).Value, 7f);
            uIManager.TryRegister();
        }
    }
}
