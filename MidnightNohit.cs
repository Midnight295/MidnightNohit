using MidnightNohit.Content.UI.BossUI;
using MidnightNohit.Content.UI.MiscUI;
using MidnightNohit.Content.UI.Pages;

using MidnightNohit.Content.UI.SingleElements;
using MidnightNohit.Core;
using Terraria.ModLoader;

namespace MidnightNohit;

public partial class MidnightNohit : Mod
{
    internal static MidnightNohit Instance;

    public static ModKeybind TimerToCursor { get; private set; }
    public static ModKeybind KillBind { get; private set; }
    public override void Load()
    {
        Instance = this;

        TimerToCursor = KeybindLoader.RegisterKeybind(this, "TimerToCursor", Microsoft.Xna.Framework.Input.Keys.LeftAlt);
        KillBind = KeybindLoader.RegisterKeybind(this, "KillBind", Microsoft.Xna.Framework.Input.Keys.K);

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
        TimerToCursor = null;
        KillBind = null;
        Instance = null;
    }
}
