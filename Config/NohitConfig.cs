using MidnightNohit.Content.UI;
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
    [BackgroundColor(25, 25, 112, 216)]
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
        public bool InstantKill;

        [DefaultValue(false)]
        public bool DisableIframes;

        [DefaultValue(true)]
        public bool MNLChatMessage;

        [DefaultValue(true)]
        public bool InventoryStations;

        [Header("Debuffs")]

        [DefaultValue(0)]
        [Slider]
        [DrawTicks]
        public Debuffs debuffs;

        [Header("UI")]

        [DefaultValue(true)]
        public bool MNLTimer;

        [Range(0f, 10f)]
        [DefaultValue(MnlTimer.defaultX / 10)]
        public float MNLX;

        [Range(0f, 10f)]
        [DefaultValue(MnlTimer.defaultY / 10)]
        public float MNLY;
    }
}
