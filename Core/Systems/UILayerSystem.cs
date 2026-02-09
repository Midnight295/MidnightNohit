using Microsoft.Xna.Framework;
using MidnightNohit.Content.UI;
using MidnightNohit.Content.UI.MiscUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace MidnightNohit.Core.Systems
{
    public class UILayerSystem : ModSystem
    {
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {

            int mouseIndex = layers.FindIndex((layer) => layer.Name == "Vanilla: Mouse Text");
            if (mouseIndex == -1)
                return;

            layers.Insert(mouseIndex, new LegacyGameInterfaceLayer("Mnl Timer", delegate ()
            {
                MnlTimer.Draw(Main.LocalPlayer);
                return true;
            }, InterfaceScaleType.None));

            layers.Insert(mouseIndex, new LegacyGameInterfaceLayer("Special UIs", () =>
            {
                
                if (!Main.inFancyUI && Main.playerInventory)
                {
                    NohitUIButton.Draw(Main.spriteBatch);
                }
                if (!Main.inFancyUI)
                {
                    TogglesUIManager.Draw(Main.spriteBatch);
                }
                return true;
            }, InterfaceScaleType.UI));
        }

        public override void UpdateUI(GameTime gameTime)
        {
            base.UpdateUI(gameTime);
        }
    }
}
