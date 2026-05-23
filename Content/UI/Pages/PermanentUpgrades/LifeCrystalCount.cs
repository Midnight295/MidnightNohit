using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MidnightNohit.Content.UI.Pages.PermanentUpgrades;

public class LifeCrystalCount : PageUIElement
{
    public override Texture2D Texture => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/UpgradesUI/LifeCrystalCount", AssetRequestMode.ImmediateLoad).Value;
    public override Texture2D GlowTexture => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/UpgradesUI/LifeCrystalCountGlow", AssetRequestMode.ImmediateLoad).Value;

    public override string Description => Language.GetTextValue($"Mods.MidnightNohit.UI.Upgrades.LifeCrystal.Description");
    public override string Name => Language.GetTextValue($"Mods.MidnightNohit.UI.Upgrades.LifeCrystal.Name");
    public override int OptionCount => 15;

    public static int CurrentOption;

    public override string GetIntToggleText()
    {
        if (CurrentOption == OptionCount)
            return "Max";
        return CurrentOption.ToString();
    }

    public override void OnClick(bool rightClick)
    {
        if (rightClick)
            CurrentOption++;
        else
            CurrentOption++;

        if (CurrentOption < 0)
            CurrentOption = OptionCount;

        if (CurrentOption > OptionCount)
            CurrentOption = 0;

        Main.LocalPlayer.ConsumedLifeCrystals = CurrentOption;    
    }
}

public class LifeCrystalCountSystem : ModSystem
{
    public override void OnWorldLoad()
    {
        LifeCrystalCount.CurrentOption = Main.LocalPlayer.ConsumedLifeCrystals;
    }
}
