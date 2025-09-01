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
        public static FieldInfo GetFieldInfo(int value)
        {
            Type enumType = typeof(WorldSavingSystem.Downed);
            Type enumUnderlyingType = Enum.GetUnderlyingType(enumType);
            Array enumValues = Enum.GetValues(enumType);

            FieldInfo field = enumType.GetField(enumValues.GetValue(value).ToString(), NohitUtils.AllBindingFlags);
            return field;
        }

        public static void InitializeFargoBossSupport()
        {
            

            //new BossToggleElement("FargowiltasSouls/Content/Bosses/TrojanSquirrel/TrojanSquirrel_Head_Boss", Language.GetTextValue($"Mods.FargowiltasSouls.NPCs.TrojanSquirrel.DisplayName"),
            //    GetFieldInfo(9), 0.8f, 1).Register();

            new BossToggleElement("FargowiltasSouls/Content/Bosses/DeviBoss/DeviBoss_Head_Boss", Language.GetTextValue($"Mods.FargowiltasSouls.NPCs.DeviBoss.DisplayName"),
                typeof(WorldSavingSystem).GetField("downedDevi", NohitUtils.AllBindingFlags), 7.2f, 1).Register();

            new BossToggleElement("FargowiltasSouls/Content/Bosses/AbomBoss/AbomBoss_Head_Boss", Language.GetTextValue($"Mods.FargowiltasSouls.NPCs.AbomBoss.DisplayName"),
                typeof(WorldSavingSystem).GetField("downedAbom", NohitUtils.AllBindingFlags), 28.5f, 2, 1.3f).Register();

            new BossToggleElement("FargowiltasSouls/Content/Bosses/MutantBoss/MutantBoss_Head_Boss", Language.GetTextValue($"Mods.FargowiltasSouls.NPCs.MutantBoss.DisplayName"),
                typeof(WorldSavingSystem).GetField("downedMutant", NohitUtils.AllBindingFlags), 32f, 2, 1.3f).Register();
       }
    }
}
