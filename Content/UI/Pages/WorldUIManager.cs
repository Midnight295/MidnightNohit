using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using MidnightNohit.Content.UI.Pages;
using MidnightNohit.Core;

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

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Spawns", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/SpawnsGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.EnemySpawns.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.EnemySpawns.Description"),
                2f,
                () => { Toggles.NoSpawns = !Toggles.NoSpawns; },
                typeof(Toggles).GetField("NoSpawns", NohitUtils.AllBindingFlags)),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/time", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/timeGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.Time.TimeFlow.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.Time.TimeFlow.Description"),
                3f,
                () => { Toggles.FrozenTime = !Toggles.FrozenTime; },
                typeof(Toggles).GetField("FrozenTime", NohitUtils.AllBindingFlags)),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/time", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/timeGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.Time.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.Time.Description"),
                4f,
                () => 
                {
                     Main.dayTime = !Main.dayTime;
                     Main.time = 0.0;
                     if (Main.dayTime)
                        TogglesUIManager.QueueMessage(Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.Time.TimeDay"), Color.Gold);
                     else
                        TogglesUIManager.QueueMessage(Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.Time.TimeNight"), Color.DimGray);
                }),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/water", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/waterGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.ToggleRain.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.ToggleRain.Description"),
                5f,
                () => { Toggles.ToggleRain = !Toggles.ToggleRain; },
                typeof(Toggles).GetField("ToggleRain", NohitUtils.AllBindingFlags)),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Event", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/EventGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.DisableEvents.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.DisableEvents.Description"),
                6f,
                () => { Toggles.DisableEvents = !Toggles.DisableEvents; }),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/biome", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/biomeGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.BiomeFountains.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.BiomeFountains.Description"),
                7f,
                () => { Toggles.BiomeFountainsForceBiome = !Toggles.BiomeFountainsForceBiome; },
                typeof(Toggles).GetField("BiomeFountainsForceBiome", NohitUtils.AllBindingFlags)),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/difficulty", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/difficultyGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.WorldDifficulty.Name"),
                () => 
                {
                    string difficulty = "";
                
                    switch (Main.GameMode)
                    {
                        case 0:
                            difficulty = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.WorldDifficulty.Difficulty.Expert.Name");
                            break;

                        case 1:
                            difficulty = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.WorldDifficulty.Difficulty.Master.Name");
                            break;

                        case 2:
                            difficulty = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.WorldDifficulty.Difficulty.Journey.Name");
                            break;

                        default:
                            difficulty = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.WorldDifficulty.Difficulty.Normal.Name");
                            break;
                    }
                    return Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.WorldDifficulty.Difficulty.SetTo", difficulty);
                },
                8f,
                () => 
                {
                    string text;
                    Color color;
                    switch (Main.GameMode)
                    {
                        case 0:
                            Main.GameMode = 1;
                            Main.LocalPlayer.difficulty = 0;
                            text = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.WorldDifficulty.Difficulty.Expert.Enable");
                            color = new Color(175, 75, 255);
                            break;

                        case 1:
                            Main.GameMode = 2;
                            Main.LocalPlayer.difficulty = 0;
                            text = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.WorldDifficulty.Difficulty.Master.Enable");
                            color = new Color(255, 68, 68);
                            break;

                        case 2:
                            Main.GameMode = 3;
                            Main.LocalPlayer.difficulty = 3;
                            text = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.WorldDifficulty.Difficulty.Journey.Enable");
                            color = new Color(255, 255, 102);
                            break;

                        default:
                            Main.GameMode = 0;
                            Main.LocalPlayer.difficulty = 0;
                            text = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.WorldDifficulty.Difficulty.Normal.Enable");
                            color = Color.White;
                            break;
                    }
                    TogglesUIManager.QueueMessage(text, color);
                }),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/Skull", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/SkullGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.PlayerDifficulty.Name"),
                () =>
                {
                    string difficulty;
                    switch (Main.LocalPlayer.difficulty)
                    {
                        case 0:
                            difficulty = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.PlayerDifficulty.Difficulty.Mediumcore.Name");
                            break;
                        case 1:
                            difficulty = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.PlayerDifficulty.Difficulty.Hardcore.Name");
                            break;
                        default:
                            difficulty = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.PlayerDifficulty.Difficulty.Classic.Name");
                            break;
                    }
                    return Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.PlayerDifficulty.Difficulty.SetTo", difficulty);
                },
                9f,
                () =>
                {
                    string text;
                    Color color;
                    switch (Main.LocalPlayer.difficulty)
                    {
                        case 0:
                            Main.LocalPlayer.difficulty = 1;
                            text = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.PlayerDifficulty.Difficulty.Mediumcore.Enable");
                            color = new Color(175, 75, 255);
                            break;

                        case 1:
                            Main.LocalPlayer.difficulty = 2;
                            text = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.PlayerDifficulty.Difficulty.Hardcore.Enable");
                            color = new Color(255, 68, 68);
                            break;

                        default:
                            Main.LocalPlayer.difficulty = 0;
                            text = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.PlayerDifficulty.Difficulty.Classic.Enable");
                            color = Color.White;
                            break;
                    }
                    if (Main.GameMode == 3 && Main.LocalPlayer.difficulty != 3)
                        // Stops you and the world desyncing being journey.
                        Main.GameMode = 1;

                    TogglesUIManager.QueueMessage(text, color);
                }),

                //new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/water", AssetRequestMode.ImmediateLoad).Value,
                //ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/waterGlow", AssetRequestMode.ImmediateLoad).Value,
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.MapTeleporting.Name"),
                //() => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.WorldUI.MapTeleporting.Description"),
                //10f,
                //() => { MapSystem.MapTeleport = !MapSystem.MapTeleport; },
                //typeof(MapSystem).GetField("MapTeleport", MidnightNohitUtils.UniversalBindingFlags)),
            };
            ;
            TogglesPage uIManager = new(uIElements, WorldUIName, "Mods.MidnightNohit.UI.UIButtons.WorldUI", ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/worldUIIcon", AssetRequestMode.ImmediateLoad).Value, 7f);
            uIManager.TryRegister();
        }
    }
}
