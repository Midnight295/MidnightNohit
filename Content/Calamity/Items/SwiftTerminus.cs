using CalamityMod.Events;
using CalamityMod.NPCs.Leviathan;
using CalamityMod.NPCs.ProfanedGuardians;
using CalamityMod.NPCs.Yharon;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MidnightNohit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MidnightNohit.Content.Calamity.Items
{
    [JITWhenModsEnabled(ModCompatability.Calamity.Name)]
    [ExtendsFromMod(ModCompatability.Calamity.Name)]
    public class SwiftTerminus : ModItem
    {
        public int boss = 0;
        public int tier = 1;
        public int maxtier = 0;
        public string bossname;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 54;
            Item.height = 70;
            Item.rare = ItemRarityID.Blue;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 10;
            Item.useAnimation = 10;
            
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool? UseItem(Player player)
        {

            if (player.altFunctionUse == 2)
            {
                int Direction = Math.Sign(Main.MouseWorld.X - player.position.X);
                boss += Direction;
                if (boss > maxtier)
                    boss = 0;              
                else if (boss < 0)
                    boss = maxtier;

                //Main.NewText(boss.ToString());

                if (ModCompatability.Infernum.Loaded)
                    maxtier = 44;
                else maxtier = 43;

                if (boss >= 0)
                    tier = 1;
                if (boss >= 13)
                    tier = 2;
                if (boss >= 22)
                    tier = 3;
                if (boss >= 32)
                    tier = 4;
                if (boss >= 41)
                    tier = 5;

                for (int i = 0; i < BossRushEvent.Bosses.Count; i++)
                {
                    if (boss == i)
                    {
                        bossname = Lang.GetNPCName(BossRushEvent.Bosses[i].EntityID).Value;
                   

                        if (BossRushEvent.Bosses[i].EntityID == NPCID.Retinazer || BossRushEvent.Bosses[i].EntityID == NPCID.Spazmatism)
                            bossname = Language.GetTextValue($"Enemies.TheTwins");

                        if (BossRushEvent.Bosses[i].EntityID == NPCID.KingSlime)
                            //tier = 1;

                        if (BossRushEvent.Bosses[i].EntityID == NPCID.QueenSlimeBoss)
                            //tier = 2;

                        if (BossRushEvent.Bosses[i].EntityID == ModContent.NPCType<Anahita>())
                        {
                            //tier = 3;
                            bossname = Language.GetTextValue($"Mods.CalamityMod.Items.Lore.LoreLeviathanAnahita.DisplayName");
                        }
                            

                        if (BossRushEvent.Bosses[i].EntityID == NPCID.MoonLordCore)
                            bossname = Language.GetTextValue($"Enemies.MoonLord");

                        
                        if (BossRushEvent.Bosses[i].EntityID == ModContent.NPCType<ProfanedGuardianCommander>())
                        {
                            bossname = Language.GetTextValue($"Mods.CalamityMod.BossChecklistIntegration.ProfanedGuardians.EntryName");
                            //tier = 4;
                        }

                        //if (BossRushEvent.Bosses[i].EntityID == ModContent.NPCType<Yharon>())
                            //tier = 5;


                    }
                }

                Main.NewText(Language.GetTextValue($"Mods.MidnightNohit.Items.SwiftTerminus.ChatMessage", tier, bossname));
            }
            else
            {   
                if (BossRushEvent.BossRushActive || BossRushEvent.StartTimer > 0)
                {
                    BossRushEvent.End();
                }
                else
                {
                    BossRushEvent.BossRushActive = true;
                    BossRushEvent.BossRushStage = boss;
                }
                
            }
            
            return true;
        }                   
    }
}
