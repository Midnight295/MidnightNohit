using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MidnightNohit.Config;
using CalamityMod.Items.Placeables.Furniture;
using CalamityMod.Buffs.Placeables;

namespace MidnightNohit.Core.Globals
{
    internal class NohitGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void UpdateInventory(Item item, Player player)
        {
            if (NohitConfig.Instance.InventoryStations)
            {
                if (item.type == ItemID.Campfire)
                    player.AddBuff(BuffID.Campfire, 2);
                if (item.type == ItemID.HeartLantern)
                    player.AddBuff(BuffID.HeartLamp, 2);
                if (item.type == ItemID.StarinaBottle)
                    player.AddBuff(BuffID.StarInBottle, 2);
                if (item.type == ItemID.SharpeningStation)
                    player.AddBuff(BuffID.Sharpened, 2);
                if (item.type == ItemID.AmmoBox)
                    player.AddBuff(BuffID.AmmoBox, 2);
                if (item.type == ItemID.CrystalBall)
                    player.AddBuff(BuffID.Clairvoyance, 2);
                if (item.type == ItemID.BewitchingTable)
                    player.AddBuff(BuffID.Bewitched, 2);
                if (item.type == ItemID.WarTable)
                    player.AddBuff(BuffID.WarTable, 2);

            }
        }
    }

    [JITWhenModsEnabled(ModCompatability.Calamity.Name)]
    [ExtendsFromMod(ModCompatability.Calamity.Name)]
    internal class CalNohitGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void UpdateInventory(Item item, Player player)
        {
            if (NohitConfig.Instance.InventoryStations)
            {
                if (item.type == ModContent.ItemType<CrimsonEffigy>())
                    player.AddBuff(ModContent.BuffType<CrimsonEffigyBuff>(), 2);
                if (item.type == ModContent.ItemType<CorruptionEffigy>())
                    player.AddBuff(ModContent.BuffType<CorruptionEffigyBuff>(), 2);
            }
        }
    }
}
