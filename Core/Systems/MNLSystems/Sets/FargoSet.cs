using FargowiltasSouls.Content.Bosses.BanishedBaron;
using FargowiltasSouls.Content.Bosses.Champions.Cosmos;
using FargowiltasSouls.Content.Bosses.Champions.Earth;
using FargowiltasSouls.Content.Bosses.Champions.Life;
using FargowiltasSouls.Content.Bosses.Champions.Nature;
using FargowiltasSouls.Content.Bosses.Champions.Shadow;
using FargowiltasSouls.Content.Bosses.Champions.Spirit;
using FargowiltasSouls.Content.Bosses.Champions.Terra;
using FargowiltasSouls.Content.Bosses.Champions.Timber;
using FargowiltasSouls.Content.Bosses.Champions.Will;
using FargowiltasSouls.Content.Bosses.CursedCoffin;
using FargowiltasSouls.Content.Bosses.DeviBoss;
using FargowiltasSouls.Content.Bosses.Lifelight;
using FargowiltasSouls.Content.Bosses.TrojanSquirrel;
using FargowiltasSouls.Core.Systems;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace MidnightNohit.Core.Systems.MNLSystems.Sets
{
    [JITWhenModsEnabled(ModCompatability.FargoSouls.Name)]
    [ExtendsFromMod(ModCompatability.FargoSouls.Name)]
    public static class FargoSet
    {
        public static Dictionary<int, int> FargoMNLS => new()
        {
            [ModContent.NPCType<TrojanSquirrel>()] = 3600,
            [NPCID.KingSlime] = 3600,
            [NPCID.EyeofCthulhu] = 3600,
            [ModContent.NPCType<CursedCoffin>()] = 4500,
            [NPCID.EaterofWorldsHead] = 3600,
            [NPCID.BrainofCthulhu] = 3600,
            [NPCID.QueenBee] = 3600,
            [NPCID.SkeletronHead] = 3600,
            [NPCID.Deerclops] = 3600,
            [ModContent.NPCType<DeviBoss>()] = 5400,
            [NPCID.WallofFlesh] = 3600,
            [NPCID.QueenSlimeBoss] = 5400,
            [ModContent.NPCType<BanishedBaron>()] = 5400,
            [NPCID.Retinazer] = 5400,
            [NPCID.Spazmatism] = 5400,
            [NPCID.SkeletronPrime] = 5400,
            [NPCID.TheDestroyer] = 5400,
            [ModContent.NPCType<LifeChallenger>()] = 5400,
            [NPCID.Plantera] = 5400,
            [NPCID.Golem] = 5400,
            [NPCID.DD2Betsy] = 3600,
            [NPCID.HallowBoss] = 5400,
            [NPCID.DukeFishron] = 5400,
            [NPCID.CultistBoss] = 5400,
            [NPCID.MoonLordCore] = 7200,
            [ModContent.NPCType<TimberChampionHead>()] = 5400,
            [ModContent.NPCType<TerraChampion>()] = 5400,
            [ModContent.NPCType<EarthChampion>()] = 5400,
            [ModContent.NPCType<NatureChampion>()] = 5400,
            [ModContent.NPCType<LifeChampion>()] = 5400,
            [ModContent.NPCType<ShadowChampion>()] = 5400,
            [ModContent.NPCType<SpiritChampion>()] = 5400,
            [ModContent.NPCType<WillChampion>()] = 5400,
            [ModContent.NPCType<CosmosChampion>()] = 5400,           
        };

        public static void Load()
        {
            MNLSet fargoset = new(FargoMNLS, () =>
            {
                if (!WorldSavingSystem.EternityMode)
                    return MNLWeights.NoWeight;

                if (WorldSavingSystem.MasochistModeReal)
                    return MNLWeights.Eternity;

                return MNLWeights.Eternity;
            });
            MNLsHandler.RegisterSet(fargoset);
        }
    }
}
