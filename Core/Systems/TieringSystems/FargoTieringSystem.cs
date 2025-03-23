using Terraria.ModLoader;
using static MidnightNohit.Core.Systems.TieringSystems.TieringSystem;
using Terraria;
using FargowiltasSouls.Content.Items.Weapons.BossDrops;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using FargowiltasSouls.Content.Patreon.Catsounds;
using FargowiltasSouls.Core.Systems;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Terraria.ID;
using FargowiltasSouls.Content.Items.Consumables;
using FargowiltasSouls.Content.Patreon.ParadoxWolf;
using FargowiltasSouls.Content.Patreon.Tiger;
using FargowiltasSouls.Content.Items.Weapons.Misc;
using FargowiltasSouls.Content.Patreon.Purified;
using FargowiltasSouls.Content.Items.Accessories.Essences;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using FargowiltasSouls.Content.Patreon.DevAesthetic;
using FargowiltasSouls.Content.Items.Weapons.SwarmDrops;
using FargowiltasSouls.Content.Patreon.Duck;
using FargowiltasSouls.Content.Items.Weapons.Challengers;
using FargowiltasSouls.Content.Patreon.GreatestKraken;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Patreon.Daawnz;
using FargowiltasSouls.Content.Patreon.Sasha;
using FargowiltasSouls.Content.Patreon.Volknet;
using FargowiltasSouls.Content.Items.Weapons.FinalUpgrades;
using FargowiltasSouls.Content.Items.Ammos;

namespace MidnightNohit.Core.Systems.TieringSystems
{
    [JITWhenModsEnabled(ModCompatability.FargoSouls.Name)]
    [ExtendsFromMod(ModCompatability.FargoSouls.Name)]
    public static class FargoTieringSystem
    {   
        public static void LoadFargoTiers()
        {
            //TODO: Put Trojan Squirrel here when the Downed Bool becomes unprotected.



            BossLockInformation.AddLockInformation(() => NPC.downedSlimeKing, $"NPCName.KingSlime",
            [   
                //Melee
                ModContent.ItemType<SlimeKingsSlasher>(),

                //Accessories
                ModContent.ItemType<MedallionoftheFallenKing>(),
                ModContent.ItemType<SlimyShield>(),
                ModContent.ItemType<NinjaEnchant>(),
            ]);

            BossLockInformation.AddLockInformation(() => WorldSavingSystem.DownedAnyBoss, $"Mods.MidnightNohit.UI.Tiering.AnyBoss", 
            [
                //Accessories
                ModContent.ItemType<SandsofTime>(),
                ModContent.ItemType<WyvernFeather>(),
                ModContent.ItemType<FrigidGemstone>()
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedBoss1, $"NPCName.EyeofCthulhu",
            [   
                //Melee     
                ModContent.ItemType<LeashOfCthulhu>(),

                //Accessories
                ModContent.ItemType<AgitatingLens>(),
            ]);

            //TODO: Put Cursed Coffin here when the Downed Bool becomes unprotected.

            BossLockInformation.AddLockInformation(() => DownedBrain && DownedEater, $"Mods.MidnightNohit.UI.Evils",
            [   
                //Melee
                ModContent.ItemType<TheLightningRod>(),

                //Ranged
                ModContent.ItemType<EaterLauncherJr>(),

                //Mage
                ModContent.ItemType<DarkTome>(),

                //Summoner
                ModContent.ItemType<BrainStaff>(),
            
                //Accessories
                ModContent.ItemType<DarkenedHeart>(),
                ModContent.ItemType<GuttedHeart>(),
                ModContent.ItemType<ObsidianEnchant>(),
                ModContent.ItemType<MeteorEnchant>(),
                ModContent.ItemType<CrimsonEnchant>(),
                ModContent.ItemType<MoltenEnchant>(),
                ModContent.ItemType<ShadowEnchant>(),
                ItemID.FastClock
                
                

            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedQueenBee, $"NPCName.QueenBee",
            [   
                //Ranged
                ModContent.ItemType<TheSmallSting>(),

                //Summoner
                ModContent.ItemType<HiveStaff>(),

                //Accessories
                ModContent.ItemType<QueenStinger>(),
                ModContent.ItemType<BeeEnchant>()

            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedBoss3, $"NPCName.SkeletronHead",
            [   
                //Ranged
                ModContent.ItemType<BoneZone>(),

                //Accessories
                ModContent.ItemType<NecromanticBrew>(),
                ModContent.ItemType<NecroEnchant>(),
                
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedDeerclops, $"NPCName.Deerclops",
            [
                ModContent.ItemType<Deerclawps>(),
                ModContent.ItemType<DeerSinew>(),
            ]);

            BossLockInformation.AddLockInformation(() => WorldSavingSystem.DownedDevi, $"Mods.FargowiltasSouls.NPCs.DeviBoss.DisplayName",
            [
                //Summon
                ModContent.ItemType<TouhouStaff>(),

                //Accessories
                ModContent.ItemType<SparklingAdoration>(),
                ModContent.ItemType<ZephyrBoots>(),
                ModContent.ItemType<SupremeDeathbringerFairy>(),
            ]);

            BossLockInformation.AddLockInformation(() => Main.hardMode, $"NPCName.WallofFlesh",
            [   
                //Melee
                ModContent.ItemType<Vineslinger>(),

                //Ranged
                ModContent.ItemType<Mahoguny>(),

                //Mage
                ModContent.ItemType<FleshHand>(),

                //Summon
                ModContent.ItemType<OvergrownKey>(),

                //Accessories; Enchants
                ModContent.ItemType<CobaltEnchant>(),
                ModContent.ItemType<PalladiumEnchant>(),
                ModContent.ItemType<MythrilEnchant>(),
                ModContent.ItemType<OrichalcumEnchant>(),
                ModContent.ItemType<AdamantiteEnchant>(),
                ModContent.ItemType<TitaniumEnchant>(),
                ModContent.ItemType<FrostEnchant>(),
                ModContent.ItemType<ForbiddenEnchant>(),
                ModContent.ItemType<AncientShadowEnchant>(),
                ModContent.ItemType<WizardEnchant>(),
                ModContent.ItemType<PearlwoodEnchant>(),

                //Accessories; Normal
                ModContent.ItemType<ConcentratedRainbowMatter>(),
                ModContent.ItemType<PungentEyeball>(),
                ModContent.ItemType<TribalCharm>(),
                ModContent.ItemType<MysticSkull>(),
                ModContent.ItemType<MysticSkullInactive>(),
                ModContent.ItemType<SecurityWallet>(),
                ModContent.ItemType<WretchedPouch>(),
                ModContent.ItemType<OrdinaryCarrot>(),
                ModContent.ItemType<DreadShell>(),
                ModContent.ItemType<ParadoxWolfSoul>(),

            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedQueenSlime, $"NPCName.QueenSlimeBoss",
            [   
                //Accessories
                ModContent.ItemType<GelicWings>(),
                ModContent.ItemType<CrystalAssassinEnchant>()
            ]);

            //TODO: Put Banished Baron here when the Downed Bool becomes unprotected.

            BossLockInformation.AddLockInformation(() => NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3, $"Mods.MidnightNohit.UI.Tiering.AllMech",
            [   

                //Melee
                ModContent.ItemType<TwinRangs>(),
                ItemID.TrueExcalibur,
                ItemID.TrueNightsEdge,
                ItemID.Excalibur,
                ItemID.LightDisc,
                ItemID.Gungnir,
                ItemID.HallowJoustingLance,
                ItemID.ChlorophytePartisan,
                ItemID.ChlorophyteSaber,
                ItemID.ChlorophyteClaymore,
                ItemID.ChlorophyteShotbow,
                ItemID.DeathSickle,

                //Mage
                ModContent.ItemType<RefractorBlaster>(),
                ModContent.ItemType<TophatSquirrelWeapon>(),
                ItemID.VenomStaff,


                //Summoner
                ModContent.ItemType<ElectricWhip>(),
                ModContent.ItemType<DestroyerGun>(),
                ModContent.ItemType<PrimeStaff>(),

                //Accessories
                ModContent.ItemType<AeolusBoots>(),
                ModContent.ItemType<BionomicCluster>(),
                ModContent.ItemType<BionomicClusterInactive>(),
                ModContent.ItemType<ChlorophyteEnchant>(),
                ModContent.ItemType<ReinforcedPlating>(),
                ModContent.ItemType<FusedLens>(),
                ModContent.ItemType<GroundStick>(),
                ModContent.ItemType<DubiousCircuitry>(),
                ModContent.ItemType<PureHeart>(),
                ModContent.ItemType<HuntressEnchant>(),
                ModContent.ItemType<SquireEnchant>(),
                ModContent.ItemType<HallowEnchant>(),
                ModContent.ItemType<AncientHallowEnchant>(),
                ModContent.ItemType<MonkEnchant>(),
                ModContent.ItemType<ApprenticeEnchant>(),
                ModContent.ItemType<BarbariansEssence>(),
                ModContent.ItemType<ApprenticesEssence>(),
                ModContent.ItemType<OccultistsEssence>(),
                ModContent.ItemType<SharpshootersEssence>(),
                ItemID.AvengerEmblem,

            ]);
            
            //TODO: Put Lifelight here when the Downed Bool becomes unprotected.

            BossLockInformation.AddLockInformation(() => NPC.downedPlantBoss, $"NPCName.Plantera", 
            [
                //Melee
                ModContent.ItemType<Dicer>(),

                //Accessories
                ModContent.ItemType<SpectreEnchant>(),
                ModContent.ItemType<ShroomiteEnchant>(),
                ModContent.ItemType<TurtleEnchant>(),
                ModContent.ItemType<MagicalBulb>(),
                ModContent.ItemType<TikiEnchant>(),
                ModContent.ItemType<SpookyEnchant>(),
                ModContent.ItemType<PumpkingsCape>(),
                ModContent.ItemType<IceQueensCrown>(),
                ModContent.ItemType<LumpOfFlesh>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedGolemBoss, $"NPCName.Golem", 
            [
                //Mage
                ModContent.ItemType<RockSlide>(),

                //Accessories
                ModContent.ItemType<LihzahrdTreasureBox>(),
                ModContent.ItemType<BeetleEnchant>(),
                ModContent.ItemType<ComputationOrb>(),

            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedEmpressOfLight, $"NPCName.HallowBoss", 
            [
                //Melee
                ModContent.ItemType<PrismaRegalia>(),
                
                //Accessories
                ModContent.ItemType<PrecisionSeal>()
            ]);

            BossLockInformation.AddLockInformation(() => WorldSavingSystem.DownedBetsy, $"NPCName.DD2Betsy", 
            [   
                //Ranged
                ModContent.ItemType<DragonBreath>(),

                //Accessories
                ModContent.ItemType<BetsysHeart>(),
                ModContent.ItemType<ShinobiEnchant>(),
                ModContent.ItemType<DarkArtistEnchant>(),
                ModContent.ItemType<RedRidingEnchant>(),
                ModContent.ItemType<ValhallaKnightEnchant>(),
                ModContent.ItemType<SaucerControlConsole>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedFishron, $"NPCName.DukeFishron", 
            [
                //Ranged
                ModContent.ItemType<FishStick>(),
                
                //Accessories
                ModContent.ItemType<MutantAntibodies>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedAncientCultist, $"Mods.MidnightNohit.UI.Tiering.CultistShort",
            [   
                ModContent.ItemType<MutantsPact>(),

                //Accessories
                ModContent.ItemType<CelestialRune>(),
                ModContent.ItemType<ChaliceoftheMoon>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedMoonlord, $"Enemies.MoonLord", 
            [   
                //????
                ModContent.ItemType<MissDrakovisFishingPole>(),

                //Melee
                ModContent.ItemType<MechanicalLeashOfCthulhu>(),
                ModContent.ItemType<SlimeSlingingSlasher>(),

                //Ranged
                ModContent.ItemType<HellZone>(),
                ModContent.ItemType<TheBigSting>(),
                ModContent.ItemType<ScientificRailgun>(),
                ModContent.ItemType<EaterLauncher>(),

                //Mage
                ModContent.ItemType<VortexMagnetRitual>(),
                ModContent.ItemType<FleshCannon>(),

                //Summon
                ModContent.ItemType<DeviousAestheticus>(),
                ModContent.ItemType<BigBrainBuster>(),

                //Accessories
                ModContent.ItemType<GalacticGlobe>(),
                ModContent.ItemType<HeartoftheMasochist>(),
                ModContent.ItemType<SolarEnchant>(),
                ModContent.ItemType<VortexEnchant>(),
                ModContent.ItemType<NebulaEnchant>(),
                ModContent.ItemType<StardustEnchant>(),
                ModContent.ItemType<TimberForce>(),
                ModContent.ItemType<TerraForce>(),
                ModContent.ItemType<EarthForce>(),
                ModContent.ItemType<SpiritForce>(),
                ModContent.ItemType<WillForce>(),
                ModContent.ItemType<ShadowForce>(),
                ModContent.ItemType<LifeForce>(),

                //Souls
                ModContent.ItemType<FlightMasterySoul>(),
                ModContent.ItemType<SupersonicSoul>(),
                ModContent.ItemType<ArchWizardsSoul>(),
                ModContent.ItemType<WorldShaperSoul>(),
                ModContent.ItemType<TrawlerSoul>(),
                ModContent.ItemType<BerserkerSoul>(),
                ModContent.ItemType<SnipersSoul>(),
                ModContent.ItemType<ConjuristsSoul>(),
                ModContent.ItemType<ColossusSoul>(),


            ]);

            BossLockInformation.AddLockInformation(() => WorldSavingSystem.DownedAbom, $"Mods.FargowiltasSouls.NPCs.AbomBoss.DisplayName", 
            [
                //Melee
                ModContent.ItemType<Blender>(),
                ModContent.ItemType<UmbraRegalia>(),
                ModContent.ItemType<GeminiGlaives>(),
                ModContent.ItemType<NanoCore>(),

                //Ranged
                ModContent.ItemType<NukeFishron>(),
                ModContent.ItemType<DragonBreath2>(),

                //Mage
                ModContent.ItemType<RefractorBlaster2>(),
                ModContent.ItemType<GolemTome2>(),

                //Summon
                ModContent.ItemType<OpticStaffEX>(),
                ModContent.ItemType<TheDestroyer>(),
                ModContent.ItemType<DestroyerGun2>(),

                //Accessories
                ModContent.ItemType<AbominableWand>(),
                ModContent.ItemType<MasochistSoul>(),
                ModContent.ItemType<UniverseSoul>(),
                ModContent.ItemType<DimensionSoul>(),
                ModContent.ItemType<TerrariaSoul>(),
            ]);

            BossLockInformation.AddLockInformation(() => WorldSavingSystem.DownedMutant, $"Mods.FargowiltasSouls.NPCs.MutantBoss.DisplayName", 
            [
                //Melee
                ModContent.ItemType<PhantasmalLeashOfCthulhu>(),
                ModContent.ItemType<SlimeRain>(),

                //Ranged
                ModContent.ItemType<TheBiggestSting>(),

                //Mage
                ModContent.ItemType<GuardianTome>(),

                //Endgame Stuff
                ModContent.ItemType<SparklingLove>(),
                ModContent.ItemType<StyxGazer>(),
                ModContent.ItemType<Penetrator>(),

                ModContent.ItemType<FargoArrow>(),
                ModContent.ItemType<FargoBullet>(),

                //Accessories
                ModContent.ItemType<EternitySoul>(),
            ]);
        }

    }
}
