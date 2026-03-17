using MidnightNohit.Core;
using Terraria.ModLoader;

namespace MidnightNohit.Content.UI.BossUI;

[JITWhenModsEnabled(ModCompatability.WrathoftheGods.Name)]
[ExtendsFromMod(ModCompatability.WrathoftheGods.Name)]
public static class WrathofTheGodsBossSupport
{
    public static void InitializeWoTGBossSupport()
    {
        /*new BossToggleElement(true, "FargowiltasSouls/Content/Bosses/DeviBoss/DeviBoss_Head_Boss", Language.GetTextValue($"Mods.FargowiltasSouls.NPCs.DeviBoss.DisplayName"),
            typeof(WorldSavingSystem).GetField("downedDevi", NohitUtils.AllBindingFlags), 7.2f, 1).Register();

        new BossToggleElement(true, "FargowiltasSouls/Content/Bosses/AbomBoss/AbomBoss_Head_Boss", Language.GetTextValue($"Mods.FargowiltasSouls.NPCs.AbomBoss.DisplayName"),
            typeof(WorldSavingSystem).GetField("downedAbom", NohitUtils.AllBindingFlags), 28.5f, 2, 1.3f).Register();

        new BossToggleElement(true, "FargowiltasSouls/Content/Bosses/MutantBoss/MutantBoss_Head_Boss", Language.GetTextValue($"Mods.FargowiltasSouls.NPCs.MutantBoss.DisplayName"),
            typeof(WorldSavingSystem).GetField("downedMutant", NohitUtils.AllBindingFlags), 32f, 2, 1.3f).Register();*/
    }
}
