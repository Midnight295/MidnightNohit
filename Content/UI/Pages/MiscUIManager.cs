using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;
using MidnightNohit.Core;

namespace MidnightNohit.Content.UI.Pages
{
    public static partial class UIManagerAutoloader
    {
        public const string MiscUIName = "MiscManager";
        public static string miscToggles = GameCulture.FromCultureName(GameCulture.CultureName.Chinese).IsActive? "杂项设置":"Misc Toggles";

        public static void InitializeMisc()
        {
            List<PageUIElement> uIElements = new()
            {
                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/gravestone", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/gravestoneGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.Gravestones.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.Gravestones.Description"),
                1f,
                () => { Toggles.GravestonesEnabled = !Toggles.GravestonesEnabled; },
                typeof(Toggles).GetField("GravestonesEnabled", NohitUtils.AllBindingFlags)),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/lightHack", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/lightHackGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.LightHack.Name"),
                () => Toggles.LightHack < 1 ? Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.LightHack.Description") + (" ") + ((Toggles.LightHack + 0.25f) * 100f).ToString() + "%" : Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.LightHack.Disable"),
                2f,
                () => 
                {
                    Toggles.LightHack = Toggles.LightHack switch
                    {
                        0f => 0.25f, 
                        0.25f => 0.5f,
                        0.5f => 0.75f,
                        0.75f => 1f,
                        _ => 0f, 
                    };

                    string text = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.LightHack.SetTo", Toggles.LightHack * 100f);
                    if (Toggles.LightHack == 0f)
                        text = Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.LightHack.Disable2");

                    TogglesUIManager.QueueMessage(text, Color.LightSkyBlue);
                }),

                /*new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/shroom", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/shroomGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.Shrooms.Normal.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.Shrooms.Normal.Description"),
                3f,
                () => { Toggles.ShroomsExtraDamage = !Toggles.ShroomsExtraDamage; },
                typeof(Toggles).GetField("ShroomsExtraDamage", NohitUtils.AllBindingFlags)),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/shroom", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/shroomGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.Shrooms.Full.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.Shrooms.Full.Description"),
                4f,
                () => { Toggles.ProperShrooms = !Toggles.ProperShrooms; },
                typeof(Toggles).GetField("ProperShrooms", NohitUtils.AllBindingFlags)),

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/shroom", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/shroomGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.Shrooms.Full.RGBName"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.Shrooms.Full.RGBDescription"),
                5f,
                () => { Toggles.ShroomShader = !Toggles.ShroomShader; },
                typeof(Toggles).GetField("ShroomShader", NohitUtils.AllBindingFlags)),

                /*new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/time", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/timeGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.MNL.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.MNL.Description"),
                6f,
                () =>
                {
                    Toggles.MNLIndicator = !Toggles.MNLIndicator;

                    if (!Toggles.MNLIndicator && Toggles.SassMode)
                        Toggles.SassMode = false;
                },
                typeof(Toggles).GetField("MNLIndicator", NohitUtils.AllBindingFlags)),*/

                /*new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/sass", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Powers/sassGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.Sass.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.Sass.Description"),
                7f,
                () =>
                { 
                    Toggles.SassMode = !Toggles.SassMode;
                    //if (!Toggles.SassMode) 
                        //SoundEngine.PlaySound(new SoundStyle("MidnightNohit/Assets/Sounds/Custom/babyLaugh"), Main.LocalPlayer.Center);
                },
                typeof(Toggles).GetField("SassMode", NohitUtils.AllBindingFlags),
                new ToggleBlockInformation(() => Toggles.MNLIndicator, "Enable the MNL Indicator to toggle")),*/

                new PageUIElement(ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/dps", AssetRequestMode.ImmediateLoad).Value,
                ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/dpsGlow", AssetRequestMode.ImmediateLoad).Value,
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.DPS.Name"),
                () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.DPS.Description"),
                8f,
                () => { Toggles.BossDPS = !Toggles.BossDPS; },
                typeof(Toggles).GetField("BossDPS", NohitUtils.AllBindingFlags)),
            };

            TogglesPage uIManager = new(uIElements, MiscUIName, "Mods.MidnightNohit.UI.UIButtons.MiscUI" /*Language.GetTextValue($"Mods.MidnightNohit.UI.UIButtons.MiscUI")*/, ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/settingsUIIcon", AssetRequestMode.ImmediateLoad).Value, 5f);
            uIManager.TryRegister();
        }   
    }
}
