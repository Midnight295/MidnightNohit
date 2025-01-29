using MidnightNohit.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace MidnightNohit.Config
{
    [JITWhenModsEnabled(ModCompatability.Calamity.Name)]
    [ExtendsFromMod(ModCompatability.Calamity.Name)]
    public class CalNohitConfig : ModConfig
    {
        public static CalNohitConfig Instance => ModContent.GetInstance<CalNohitConfig>();

        public override ConfigScope Mode => ConfigScope.ClientSide;
        public const string ModName = "MidnightNohit";


        [Header("CalamityNohit")]

        [DefaultValue(false)]
        public bool DisableRippers;

    }
}
