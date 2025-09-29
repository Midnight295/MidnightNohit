using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using MidnightNohit.Content.UI.BossUI;
using MidnightNohit.Content.UI.PotionUI;
using MidnightNohit.Core.ModPlayers;

namespace MidnightNohit.Content.UI.SingleElements
{
    public static class SingleElementAutoloader
    {

        public static void Initialize()
        {
            SingleActionElement setSpawnElement = new("SetSpawn", ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/Buttons/SpawnPoint", AssetRequestMode.ImmediateLoad).Value,
                "Mods.MidnightNohit.UI.UIButtons.SetSpawn", () =>
                {
                    Main.spawnTileX = (int)(Main.LocalPlayer.position.X - 8f + Main.LocalPlayer.width / 2) / 16;
                    Main.spawnTileY = (int)(Main.LocalPlayer.position.Y + Main.LocalPlayer.height) / 16;
                    TogglesUIManager.QueueMessage("Spawn Set", Color.White);
                }, 1f);
            setSpawnElement.TryRegister();

            SingleActionElement bossElement = new("BossUI", ModContent.Request<Texture2D>("MidnightNohit/Assets/UI/Buttons/BossUI", AssetRequestMode.ImmediateLoad).Value,
                "Mods.MidnightNohit.UI.UIButtons.BossUI", () =>
                {

                }, 8f, 
                (spritebatch) =>
                {
                    BossTogglesUIManager.Draw(spritebatch);
                });
            bossElement.TryRegister();
        }
    }
}
