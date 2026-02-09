using MidnightNohit.Content.UI.BossUI;
using MidnightNohit.Content.UI.MiscUI;
using MidnightNohit.Content.UI.Pages;

using MidnightNohit.Content.UI.SingleElements;
using MidnightNohit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace MidnightNohit
{
	public partial class MidnightNohit : Mod
	{
        internal static MidnightNohit Instance;

        public override void Load()
        {
            Instance = this;
            //UIManagerAutoloader.InitializeLocks();
            NohitUIButton.Load();

            UIManagerAutoloader.InitializeToggles();
            //UIManagerAutoloader.InitializePermanentUpgrades();
            SingleElementAutoloader.Initialize();
            BossTogglesUIManager.InitializeBossElements();
        }

        public override void PostSetupContent()
        {
            if (ModCompatability.Calamity.Loaded)
                CalamityBossSupport.InitializeCalamityBossSupport();

            if (ModCompatability.FargoSouls.Loaded)
                FargoSoulsBossSupport.InitializeFargoBossSupport();
        }

        public override void Unload()
        {
            Instance = null;
        }
    }
}
