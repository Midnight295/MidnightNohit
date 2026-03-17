using MidnightNohit.Content.UI;
using Terraria.ModLoader;

namespace MidnightNohit.Core.Systems;

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
}
