using MidnightNohit.Core;
using NoxusBoss.Content.NPCs.Bosses.Avatar.FirstPhaseForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using CalamityMod.NPCs.ExoMechs;
using Mono.Cecil;
using Microsoft.Xna.Framework;
using CalamityMod.Rarities;

namespace MidnightNohit.Content.Calamity.Items
{
    [JITWhenModsEnabled(ModCompatability.Calamity.Name)]
    [ExtendsFromMod(ModCompatability.Calamity.Name)]
    public class DraedonSummoner : ModItem
    {
        public override void SetDefaults()
        {
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ModContent.RarityType<Turquoise>();
        }

        public override bool CanUseItem(Player player)
        {
            if (NPC.AnyNPCs(ModContent.NPCType<Draedon>()))
                return false;
            return true;
        }
        public override bool? UseItem(Player player)
        {   
            Vector2 DraedonSummonPosition = Main.LocalPlayer.Center + new Vector2(-8f, -100f);
            NPC.NewNPC(new EntitySource_WorldEvent(), (int)DraedonSummonPosition.X, (int)DraedonSummonPosition.Y, ModContent.NPCType<Draedon>());
            return true;
        }
    }
}
