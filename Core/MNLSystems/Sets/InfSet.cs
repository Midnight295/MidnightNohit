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
using CalamityMod.NPCs.PrimordialWyrm;
using CalamityMod.NPCs.ProfanedGuardians;
using CalamityMod.NPCs.Providence;
using CalamityMod.NPCs.Ravager;
using CalamityMod.NPCs.Signus;
using CalamityMod.NPCs.SlimeGod;
using CalamityMod.NPCs.StormWeaver;
using CalamityMod.NPCs.SupremeCalamitas;
using CalamityMod.NPCs.Yharon;
using CalamityMod.World;
using InfernumMode;
using InfernumMode.Core.GlobalInstances.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace MidnightNohit.Core.MNLSystems.Sets
{
    [JITWhenModsEnabled(ModCompatability.Infernum.Name)]
    [ExtendsFromMod(ModCompatability.Infernum.Name)]
    public static class InfSet
    {
        public static Dictionary<int, int> InfernumMNLs => new()
        {
            [NPCID.KingSlime] = 2400,
            [ModContent.NPCType<DesertScourgeHead>()] = 2700,
            [NPCID.EyeofCthulhu] = 3000,
            [ModContent.NPCType<Crabulon>()] = 3300,
            [NPCID.EaterofWorldsHead] = 3300,
            [NPCID.BrainofCthulhu] = 3300,
            [ModContent.NPCType<HiveMind>()] = 4200,
            [ModContent.NPCType<PerforatorHive>()] = 4800,
            [NPCID.QueenBee] = 3600,
            [NPCID.Deerclops] = 3600,
            [NPCID.SkeletronHead] = 4500,
            [ModContent.NPCType<SlimeGodCore>()] = 3900,
            [NPCID.WallofFlesh] = 3600,
            // Hardmode
            [NPCID.BloodNautilus] = 3600,
            [NPCID.QueenSlimeBoss] = 3900,
            [ModContent.NPCType<Cryogen>()] = 4500,
            [NPCID.Retinazer] = 5400,
            [NPCID.Spazmatism] = 5400,
            [ModContent.NPCType<BrimstoneElemental>()] = 4800,
            [NPCID.TheDestroyer] = 4500,
            [ModContent.NPCType<AquaticScourgeHead>()] = 5700,
            [NPCID.SkeletronPrime] = 4500,
            [ModContent.NPCType<CalamitasClone>()] = 6300,
            [NPCID.Plantera] = 4800,
            [ModContent.NPCType<Leviathan>()] = 6000,
            [ModContent.NPCType<Anahita>()] = 6000,
            [ModContent.NPCType<AstrumAureus>()] = 4200,
            [NPCID.Golem] = 5700,
            [ModContent.NPCType<PlaguebringerGoliath>()] = 4500,
            [NPCID.HallowBoss] = 6600,
            [NPCID.DukeFishron] = 3900,
            [ModContent.NPCType<RavagerBody>()] = 4500,
            [NPCID.CultistBoss] = 4200,
            [ModContent.NPCType<AstrumDeusHead>()] = 5400,
            [NPCID.MoonLordCore] = 6000,
            // PostMoonlord
            [ModContent.NPCType<ProfanedGuardianCommander>()] = 4800,
            [ModContent.NPCType<Bumblefuck>()] = 4200,
            [ModContent.NPCType<Providence>()] = 11100,
            [ModContent.NPCType<StormWeaverHead>()] = 3900,
            [ModContent.NPCType<CeaselessVoid>()] = 5400,
            [ModContent.NPCType<Signus>()] = 3900,
            [ModContent.NPCType<Polterghast>()] = 7500,
            [ModContent.NPCType<OldDuke>()] = 5100,
            [ModContent.NPCType<DevourerofGodsHead>()] = 6000,
            [ModContent.NPCType<Yharon>()] = 9600,
            [ModContent.NPCType<PrimordialWyrmHead>()] = 5100,
            [ModContent.NPCType<SupremeCalamitas>()] = 12000,
            [ModContent.NPCType<Artemis>()] = 1,
            [ModContent.NPCType<Apollo>()] = 1,
            [ModContent.NPCType<AresBody>()] = 1,
            [ModContent.NPCType<ThanatosHead>()] = 1,
        };

        public static void Load()
        {
            MNLSet infset = new MNLSet(InfernumMNLs, () =>
            {
                if (!WorldSaveSystem.InfernumModeEnabled)
                    return MNLWeight.None;

                return MNLWeight.Infernum;
            });
            MNLSystem.RegisterSet(infset);
        }
    }
}
