using MidnightNohit.Core;
using NoxusBoss.Content.NPCs.Bosses.Avatar.FirstPhaseForm;
using NoxusBoss.Content.NPCs.Bosses.Avatar.SecondPhaseForm;
using NoxusBoss.Content.Rarities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MidnightNohit.Content.Calamity.Items
{
    [JITWhenModsEnabled(ModCompatability.WrathoftheGods.Name)]
    [ExtendsFromMod(ModCompatability.WrathoftheGods.Name)]
    public class AvatarSummoner : ModItem
    {
        public override void SetDefaults()
        {
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ModContent.RarityType<AvatarRarity>();
        }

        public override bool CanUseItem(Player player)
        {
            if (NPC.AnyNPCs(ModContent.NPCType<AvatarRift>()))
                return false;
            if (NPC.AnyNPCs(ModContent.NPCType<AvatarOfEmptiness>()))
                return false;
            return true;
        }
        public override bool? UseItem(Player player)
        {   
            NPC.NewNPC(new EntitySource_WorldEvent(), (int)player.Center.X - 400, (int)player.Center.Y, ModContent.NPCType<AvatarRift>(), 1);
            return true;
        }
    }
}
