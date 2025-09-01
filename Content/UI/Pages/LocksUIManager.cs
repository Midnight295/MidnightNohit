/*using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using MidnightNohit.Core;

namespace MidnightNohit.Content.UI.Pages
{
    public static partial class UIManagerAutoloader
    {
        public const string LocksUIName = "LocksManager";
    
        public static void InitializeLocks()
        {
            Texture2D potion = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Settings/Potion", AssetRequestMode.ImmediateLoad).Value;
            Texture2D potionGlow = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Settings/PotionGlow", AssetRequestMode.ImmediateLoad).Value;
            Texture2D item = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Settings/Item", AssetRequestMode.ImmediateLoad).Value;
            Texture2D itemGlow = ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/Settings/ItemGlow", AssetRequestMode.ImmediateLoad).Value;

            List<PageUIElement> uIElements = new()
            {
                new PageUIElement(potion,
                    potionGlow,
                    () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.LocksUI.Potion.Tooltips.Name"),
                    () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.LocksUI.Potion.Tooltips.Description"),
                    1f,
                    () => { Toggles.PotionTooltips = !Toggles.PotionTooltips; },
                    typeof(Toggles).GetField("PotionTooltips", NohitUtils.AllBindingFlags)),

                new PageUIElement(potion,
                    potionGlow,
                    () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.LocksUI.Potion.Locks.Name"),
                    () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.LocksUI.Potion.Locks.Description"),
                    2f,
                    () => { Toggles.PotionLock = !Toggles.PotionLock; },
                    typeof(Toggles).GetField("PotionLock", NohitUtils.AllBindingFlags)),

                new PageUIElement(item,
                    itemGlow,
                    () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.LocksUI.Item.Tooltips.Name"),
                    () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.LocksUI.Item.Tooltips.Description"),
                    3f,
                    () => { Toggles.ItemTooltips = !Toggles.ItemTooltips; },
                    typeof(Toggles).GetField("ItemTooltips", NohitUtils.AllBindingFlags)),

                new PageUIElement(item,
                    itemGlow,
                    () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.LocksUI.Item.Locks.Name"),
                    () => Language.GetTextValue($"Mods.MidnightNohit.UI.Toggles.LocksUI.Item.Locks.Description"),
                    4f,
                    () => { Toggles.ItemLock = !Toggles.ItemLock; },
                    typeof(Toggles).GetField("ItemLock", NohitUtils.AllBindingFlags)),
            };
            TogglesPage uiManager = new(uIElements, LocksUIName, "Mods.MidnightNohit.UI.UIButtons.LocksUI", ModContent.Request<Texture2D>("MidnightNohit/Content/UI/Textures/locksUIIcon", AssetRequestMode.ImmediateLoad).Value, 4f, true);
            uiManager.TryRegister();
        }
    }      
}*/
