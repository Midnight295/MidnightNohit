using CalamityMod.NPCs.AquaticScourge;
using CalamityMod.NPCs.AstrumAureus;
using CalamityMod.NPCs.AstrumDeus;
using CalamityMod.NPCs.BrimstoneElemental;
using CalamityMod.NPCs.Bumblebirb;
using CalamityMod.NPCs.CalClone;
using CalamityMod.NPCs.CeaselessVoid;
using CalamityMod.NPCs.Crabulon;
using CalamityMod.NPCs.Cryogen;
using CalamityMod.NPCs.DesertScourge;
using CalamityMod.NPCs.DevourerofGods;
using CalamityMod.NPCs.ExoMechs.Apollo;
using CalamityMod.NPCs.ExoMechs.Ares;
using CalamityMod.NPCs.ExoMechs.Artemis;
using CalamityMod.NPCs.ExoMechs.Thanatos;
using CalamityMod.NPCs.HiveMind;
using CalamityMod.NPCs.Leviathan;
using CalamityMod.NPCs.OldDuke;
using CalamityMod.NPCs.Perforator;
using CalamityMod.NPCs.PlaguebringerGoliath;
using CalamityMod.NPCs.Polterghast;
using CalamityMod.NPCs.ProfanedGuardians;
using CalamityMod.NPCs.Providence;
using CalamityMod.NPCs.Ravager;
using CalamityMod.NPCs.Signus;
using CalamityMod.NPCs.SlimeGod;
using CalamityMod.NPCs.StormWeaver;
using CalamityMod.NPCs.SupremeCalamitas;
using CalamityMod.NPCs.Yharon;
using CalamityMod.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace MidnightNohit.Core.MNLSystems.Sets
{
    [JITWhenModsEnabled(ModCompatability.Calamity.Name)]
    [ExtendsFromMod(ModCompatability.Calamity.Name)]
    public static class DeathSet
    {
        public static Dictionary<int, int> DeathMNLs => new()
        {
            // PreHardmode
            [NPCID.KingSlime] = 2100,
            [ModContent.NPCType<DesertScourgeHead>()] = 2100,
            [NPCID.EyeofCthulhu] = 2700,
            [ModContent.NPCType<Crabulon>()] = 2700,
            [NPCID.EaterofWorldsHead] = 3000,
            [NPCID.BrainofCthulhu] = 3000,
            [ModContent.NPCType<HiveMind>()] = 3600,
            [ModContent.NPCType<PerforatorHive>()] = 3600,
            [NPCID.QueenBee] = 2700,
            [NPCID.Deerclops] = 3300,
            [NPCID.SkeletronHead] = 3600,
            [ModContent.NPCType<SlimeGodCore>()] = 4800,
            [NPCID.WallofFlesh] = 2400,
            // Hardmode
            [NPCID.QueenSlimeBoss] = 3900,
            [ModContent.NPCType<Cryogen>()] = 4200,
            [NPCID.Retinazer] = 4800,
            [NPCID.Spazmatism] = 4800,
            [ModContent.NPCType<BrimstoneElemental>()] = 4500,
            [NPCID.TheDestroyer] = 3900,
            [ModContent.NPCType<AquaticScourgeHead>()] = 3300,
            [NPCID.SkeletronPrime] = 4500,
            [ModContent.NPCType<CalamitasClone>()] = 6600,
            [NPCID.Plantera] = 4200,
            [ModContent.NPCType<Leviathan>()] = 5700,
            [ModContent.NPCType<Anahita>()] = 5700,
            [ModContent.NPCType<AstrumAureus>()] = 4200,
            [NPCID.Golem] = 3300,
            [ModContent.NPCType<PlaguebringerGoliath>()] = 3600,
            [NPCID.HallowBoss] = 5100,
            [NPCID.DukeFishron] = 3600,
            [ModContent.NPCType<RavagerBody>()] = 4200,
            [NPCID.CultistBoss] = 3300,
            [ModContent.NPCType<AstrumDeusHead>()] = 5700,
            [NPCID.MoonLordCore] = 7200,
            // PostMoonlord
            [ModContent.NPCType<ProfanedGuardianCommander>()] = 4200,
            [ModContent.NPCType<Bumblefuck>()] = 3900,
            [ModContent.NPCType<Providence>()] = 7200,
            [ModContent.NPCType<StormWeaverHead>()] = 3300,
            [ModContent.NPCType<CeaselessVoid>()] = 5100,
            [ModContent.NPCType<Signus>()] = 3300,
            [ModContent.NPCType<Polterghast>()] = 5100,
            [ModContent.NPCType<OldDuke>()] = 4800,
            [ModContent.NPCType<DevourerofGodsHead>()] = 7800,
            [ModContent.NPCType<Yharon>()] = 7200,
            [ModContent.NPCType<SupremeCalamitas>()] = 12000,
            [ModContent.NPCType<Artemis>()] = 9000,
            [ModContent.NPCType<Apollo>()] = 9000,
            [ModContent.NPCType<AresBody>()] = 9000,
            [ModContent.NPCType<ThanatosHead>()] = 9000,
        };

        public static void Load()
        {
            MNLSet deathset = new MNLSet(DeathMNLs, () =>
            {
                if (!CalamityWorld.death)
                    return MNLWeight.None;

                return MNLWeight.Death;
            });
            MNLSystem.RegisterSet(deathset);
        }
    }
    
}
