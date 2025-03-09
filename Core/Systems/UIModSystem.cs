using MidnightNohit.Content.UI;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MidnightNohit.Content.UI.PotionUI;

namespace MidnightNohit.Core.Systems
{
    public class UIModSystem : ModSystem
    {
        private static void ResetUIStuff()
        {
            TogglesUIManager.ClickCooldownTimer = 0;
            TogglesUIManager.CloseUI();
        }


        public override void OnWorldLoad()
        {
            ResetUIStuff();
        }

        public override void OnWorldUnload() => ResetUIStuff();

        public static ModKeybind OpenTogglesUI { get; private set; }

        public static ModKeybind OpenPotionsUI { get; private set; }

        


        public override void Load()
        {
            OpenTogglesUI = KeybindLoader.RegisterKeybind(Mod, "Open Toggles UI", "L");
            OpenPotionsUI = KeybindLoader.RegisterKeybind(Mod, "Open Potions UI", "P");
        }
    }
}
