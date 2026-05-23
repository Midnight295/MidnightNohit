using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MidnightNohit.Content.UI.Pages.PermanentUpgrades;

public class ManaCrystalCount : PageUIElement
{
    public override Texture2D Texture => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/UpgradesUI/ManaCrystalCount", AssetRequestMode.ImmediateLoad).Value;
    public override Texture2D GlowTexture => ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/UpgradesUI/ManaCrystalCountGlow", AssetRequestMode.ImmediateLoad).Value;

    public override string Description => Language.GetTextValue($"Mods.MidnightNohit.UI.Upgrades.ManaCrystal.Description");
    public override string Name => Language.GetTextValue($"Mods.MidnightNohit.UI.Upgrades.ManaCrystal.Name");
    public override int OptionCount => 9;

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

        Main.LocalPlayer.ConsumedManaCrystals = CurrentOption;
    }
}

public class ManaCrystalCountSystem : ModSystem
{
    public override void OnWorldLoad()
    {
        ManaCrystalCount.CurrentOption = Main.LocalPlayer.ConsumedManaCrystals;
    }
}