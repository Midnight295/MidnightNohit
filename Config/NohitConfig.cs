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
    public class NohitConfig : ModConfig
    {
        public static NohitConfig Instance => ModContent.GetInstance<NohitConfig>();

        public override ConfigScope Mode => ConfigScope.ClientSide;
        public const string ModName = "MidnightNohit";

        [Header("Nohit")]
        //[DefaultValue(0)]
        //[Slider]
        //[DrawTicks]
        //public Defiled defiled;

        [DefaultValue(false)]
        public bool DisableIframes;

        [DefaultValue(false)]
        public bool DisableDebuffs;

        [DefaultValue(true)]
        public bool DQDebuffs;

        [DefaultValue(false)]
        public bool InstantKill;

        [DefaultValue(true)]
        public bool InventoryStations;
    }
}
