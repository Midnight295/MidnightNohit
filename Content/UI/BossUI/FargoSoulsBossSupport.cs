using MidnightNohit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.Localization;
using FargowiltasSouls.Core.Systems;
using System.Reflection;
using MidnightNohit.Core.Systems;

namespace MidnightNohit.Content.UI.BossUI
{
    [JITWhenModsEnabled(ModCompatability.FargoSouls.Name)]
    [ExtendsFromMod(ModCompatability.FargoSouls.Name)]
    public static class FargoSoulsBossSupport
    {   
        public static void InitializeFargoBossSupport()
        {
            var downed = typeof(WorldSavingSystem).GetFields(NohitUtils.AllBindingFlags);
            


            //new BossToggleElement(true, "FargowiltasSouls/Content/Bosses/TrojanSquirrel/TrojanSquirrel_Head_Boss", Language.GetTextValue($"Mods.FargowiltasSouls.NPCs.TrojanSquirrel.DisplayName"),
            //    (FieldInfo)WorldSavingSystem.Downed[9], 0.8f, 1).Register();

            new BossToggleElement(true, "FargowiltasSouls/Content/Bosses/DeviBoss/DeviBoss_Head_Boss", Language.GetTextValue($"Mods.FargowiltasSouls.NPCs.DeviBoss.DisplayName"),
                typeof(WorldSavingSystem).GetField("downedDevi", NohitUtils.AllBindingFlags), 7.2f, 1).Register();

            new BossToggleElement(true, "FargowiltasSouls/Content/Bosses/AbomBoss/AbomBoss_Head_Boss", Language.GetTextValue($"Mods.FargowiltasSouls.NPCs.AbomBoss.DisplayName"),
                typeof(WorldSavingSystem).GetField("downedAbom", NohitUtils.AllBindingFlags), 28.5f, 1.3f).Register();

            new BossToggleElement(true, "FargowiltasSouls/Content/Bosses/MutantBoss/MutantBoss_Head_Boss", Language.GetTextValue($"Mods.FargowiltasSouls.NPCs.MutantBoss.DisplayName"),
                typeof(WorldSavingSystem).GetField("downedMutant", NohitUtils.AllBindingFlags), 32f, 1.3f).Register();
       }
    }
}
