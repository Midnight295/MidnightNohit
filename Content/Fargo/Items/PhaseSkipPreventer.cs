using MidnightNohit.Content.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using MidnightNohit.Core;
using Terraria.Audio;
using MidnightNohit.Core.ModPlayers;
using FargowiltasSouls.Core.Systems;

namespace MidnightNohit.Content.Fargo.Items
{
    public class PhaseSkipPreventerDisabled : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 50;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Cyan;
        }

        public override bool CanUseItem(Player player) => false;
        public override bool CanRightClick() => true;
        public override void RightClick(Player player)
        {
            player.SwitchItem(Item, ModContent.ItemType<PhaseSkipPreventerEnabled>());
            SoundEngine.PlaySound(SoundID.Unlock, Main.LocalPlayer.Center);
        }   
    }

    public class PhaseSkipPreventerEnabled : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 50;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Cyan;
        }

        public override void UpdateInventory(Player player)
        {
            WorldSavingSystem.SkipMutantP1 -= 1;
        }

        public override bool CanUseItem(Player player) => false;
        public override bool CanRightClick() => true;
        public override void RightClick(Player player)
        {
            player.SwitchItem(Item, ModContent.ItemType<PhaseSkipPreventerDisabled>());
            SoundEngine.PlaySound(SoundID.Unlock, Main.LocalPlayer.Center);
        }
    }
}
