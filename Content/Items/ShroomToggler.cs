using MidnightNohit.Core;
using MidnightNohit.Core.ModPlayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MidnightNohit.Content.Items
{
    public class ShroomToggler : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 50;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.LightRed;
        }

        public override bool CanUseItem(Player player) => false;
        public override bool CanRightClick() => true;
        public override void RightClick(Player player)
        {
            player.SwitchItem(Item, ModContent.ItemType<ShroomTogglerT1>());
            SoundEngine.PlaySound(SoundID.Unlock, Main.LocalPlayer.Center);
        }
    }

    public class ShroomTogglerT1 : ModItem
    {
        public override string Texture => "MidnightNohit/Content/Items/ShroomToggler";
        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 50;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.LightRed;
        }
        public override bool CanUseItem(Player player) => false;
        public override void UpdateInventory(Player player)
        {
            Main.LocalPlayer.GetModPlayer<ShroomPlayer>().trippy = true;
            Main.LocalPlayer.GetModPlayer<ShroomPlayer>().trippyLevel = 1;
        }
        public override bool CanRightClick() => true;
        public override void RightClick(Player player)
        {
            player.SwitchItem(Item, ModContent.ItemType<ShroomTogglerT2>());
            SoundEngine.PlaySound(SoundID.Unlock, Main.LocalPlayer.Center);
        }
    }

    public class ShroomTogglerT2 : ModItem
    {
        public override string Texture => "MidnightNohit/Content/Items/ShroomToggler";
        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 50;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.LightRed;
        }
        public override bool CanUseItem(Player player) => false;
        public override void UpdateInventory(Player player)
        {
            Main.LocalPlayer.GetModPlayer<ShroomPlayer>().trippy = true;
            Main.LocalPlayer.GetModPlayer<ShroomPlayer>().trippyLevel = 2;
        }
        public override bool CanRightClick() => true;
        public override void RightClick(Player player)
        {
            player.SwitchItem(Item, ModContent.ItemType<ShroomTogglerT3>());
            SoundEngine.PlaySound(SoundID.Unlock, Main.LocalPlayer.Center);
        }
    }

    public class ShroomTogglerT3 : ModItem
    {
        public override string Texture => "MidnightNohit/Content/Items/ShroomToggler";
        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 50;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.LightRed;
        }
        public override bool CanUseItem(Player player) => false;
        public override void UpdateInventory(Player player)
        {
            Main.LocalPlayer.GetModPlayer<ShroomPlayer>().trippy = true;
            Main.LocalPlayer.GetModPlayer<ShroomPlayer>().trippyLevel = 3;
        }
        public override bool CanRightClick() => true;
        public override void RightClick(Player player)
        {
            player.SwitchItem(Item, ModContent.ItemType<ShroomToggler>());
            SoundEngine.PlaySound(SoundID.Unlock, Main.LocalPlayer.Center);
        }
    }
}
