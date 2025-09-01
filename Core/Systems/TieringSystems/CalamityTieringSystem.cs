using CalamityMod;
using CalamityMod.Items;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Accessories.Wings;
using CalamityMod.Items.Fishing.AstralCatches;
using CalamityMod.Items.Fishing.BrimstoneCragCatches;
using CalamityMod.Items.Fishing.SunkenSeaCatches;
using CalamityMod.Items.LoreItems;
using CalamityMod.Items.Potions;
using CalamityMod.Items.Potions.Alcohol;
using CalamityMod.Items.Tools;
using CalamityMod.Items.Weapons.DraedonsArsenal;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Typeless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static MidnightNohit.Core.Systems.TieringSystems.TieringSystem;

namespace MidnightNohit.Core.Systems.TieringSystems
{
    [JITWhenModsEnabled(ModCompatability.Calamity.Name)]
    [ExtendsFromMod(ModCompatability.Calamity.Name)]
    public static class CalamityTieringSystem
    {
        public static int GetMechsDead()
        {
            int amount = 0;
            if (NPC.downedMechBoss1)
                amount++;
            if (NPC.downedMechBoss2)
                amount++;
            if (NPC.downedMechBoss3)
                amount++;

            return amount;
        }

        public static void LoadCalamityTiers()
        {
            BossLockInformation.AddLockInformation(() => NPC.downedSlimeKing, $"NPCName.KingSlime",
            [
                ModContent.ItemType<CrownJewel>(),
                ModContent.ItemType<HeartofDarkness>(),
                ModContent.ItemType<Laudanum>(),
                ModContent.ItemType<StressPills>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedDesertScourge, $"Mods.CalamityMod.NPCs.DesertScourgeHead.DisplayName",
            [
                //Accessories
                ModContent.ItemType<AeroStone>(),
                ModContent.ItemType<OceanCrest>(),
                ModContent.ItemType<AmidiasPendant>(),
                ModContent.ItemType<SandCloak>(),
                ModContent.ItemType<VoltaicJelly>(),
                ModContent.ItemType<GiantPearl>(),
                ModContent.ItemType<ShieldoftheOcean>(),
                //Weapons
                ModContent.ItemType<SaharaSlicers>(),
                ModContent.ItemType<Riptide>(),
                ModContent.ItemType<AmidiasTrident>(),
                ModContent.ItemType<RedtideSpear>(),
                ModContent.ItemType<UrchinMace>(),
                ModContent.ItemType<UrchinFlail>(),
                ModContent.ItemType<MonstrousKnives>(),
                //Ranged Weapons
                ModContent.ItemType<Barinade>(),
                ModContent.ItemType<Shellshooter>(),
                ModContent.ItemType<CoralCannon>(),
                ModContent.ItemType<FirestormCannon>(),
                ModContent.ItemType<ReedBlowgun>(),
                ModContent.ItemType<StormSurge>(),
                //Magic Weapons
                ModContent.ItemType<AquamarineStaff>(),
                ModContent.ItemType<SandstreamScepter>(),
                ModContent.ItemType<CoralSpout>(),
                ModContent.ItemType<Waywasher>(),
                ModContent.ItemType<SparklingEmpress>(),
                //Summon Weapons
                ModContent.ItemType<EnchantedConch>(),
                ModContent.ItemType<PolypLauncher>(),
                ModContent.ItemType<Cnidarian>(),
                //Rogue Weapons
                ModContent.ItemType<SeafoamBomb>(),
                ModContent.ItemType<EnchantedAxe>(),
                ModContent.ItemType<FishboneBoomerang>(),
                ModContent.ItemType<SandDollar>(),
                ModContent.ItemType<ScourgeoftheDesert>(),
                ModContent.ItemType<SnapClam>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedBoss1, $"NPCName.EyeofCthulhu",
            [
                //Weapons
                ModContent.ItemType<Basher>(),
                ModContent.ItemType<TeardropCleaver>(),
                //Ranged Weapons
                ModContent.ItemType<Toxibow>(),
                //Magic Weapons
                ModContent.ItemType<ParasiticSceptor>(),
                ModContent.ItemType<SkyGlaze>(),
                ModContent.ItemType<AcidGun>(),
                //Summon Weapons
                ModContent.ItemType<DeathstareRod>(),
                ModContent.ItemType<RustyBeaconPrototype>(),
                ModContent.ItemType<CausticCroakerStaff>(),
                //Rogue Weapons
                ModContent.ItemType<ContaminatedBile>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedCrabulon, $"Mods.CalamityMod.NPCs.Crabulon.DisplayName",
            [
                //Accessories
                ModContent.ItemType<FungalClump>(),
                //Weapons
                ModContent.ItemType<MycelialClaws>(),
                //Ranged Weapons
                ModContent.ItemType<Fungicide>(),
                //Magic Weapons
                ModContent.ItemType<HyphaeRod>(),
                //Rogue Weapons
                ModContent.ItemType<InfestedClawmerang>(),
                ModContent.ItemType<Mycoroot>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBrain && DownedEater, $"Mods.MidnightNohit.UI.Tiering.Evils",
            [
                //Accessories
                ModContent.ItemType<SilencingSheath>(),
                ModContent.ItemType<EnchantedPearl>(),
                //Weapons
                ModContent.ItemType<TaintedBlade>(),
                //Ranged Weapons
                ModContent.ItemType<MagnaCannon>(),
                ModContent.ItemType<OpalStriker>(),
                ModContent.ItemType<FirestormCannon>(),
                //Magic Weapons
                ModContent.ItemType<TheCauldron>(),
                //Summon Weapons
                ModContent.ItemType<ScabRipper>(),
                ModContent.ItemType<VileFeeder>(),
                //Rogue Weapons
                ModContent.ItemType<MeteorFist>(),
                ModContent.ItemType<SludgeSplotch>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedPerforator && DownedBossSystem.downedHiveMind, $"Mods.MidnightNohit.UI.Tiering.Evils2",
            [
                //Accessories   
                ModContent.ItemType<HarpyRing>(),
                ModContent.ItemType<BloodstainedGlove>(),
                ModContent.ItemType<FilthyGlove>(),
                ModContent.ItemType<BloodyWormTooth>(),
                ModContent.ItemType<FeatherCrown>(),
                ModContent.ItemType<RottenBrain>(),
                ModContent.ItemType<SkylineWings>(),
                ItemID.HorseshoeBundle,
                ItemID.BundleofBalloons,
                //Weapons
                ModContent.ItemType<BrokenBiomeBlade>(),
                ModContent.ItemType<GaussDagger>(),
                ModContent.ItemType<PerfectDark>(),
                ModContent.ItemType<VeinBurster>(),
                ModContent.ItemType<WindBlade>(),
                ModContent.ItemType<AirSpinner>(),
                ModContent.ItemType<Aorta>(),
                ModContent.ItemType<GoldplumeSpear>(),             
                //Ranged Weapons
                ModContent.ItemType<Goobow>(),
                ModContent.ItemType<LunarianBow>(),
                ModContent.ItemType<Eviscerator>(),
                ModContent.ItemType<BulletFilledShotgun>(),
                ModContent.ItemType<Shadethrower>(),
                ModContent.ItemType<AquashardShotgun>(),
                ModContent.ItemType<FlurrystormCannon>(),
                ModContent.ItemType<Taser>(),
                //Magic Weapons
                ModContent.ItemType<BloodBath>(),
                ModContent.ItemType<ShaderainStaff>(),
                ModContent.ItemType<PulsePistol>(),
                ModContent.ItemType<Tradewinds>(),
                //Summon Weapons
                ModContent.ItemType<StarSwallowerContainmentUnit>(),
                ModContent.ItemType<DankStaff>(),
                //Rogue Weapons
                ModContent.ItemType<TrackingDisk>(),
                ModContent.ItemType<FeatherKnife>(),
                ModContent.ItemType<Turbulance>(),
                ModContent.ItemType<SkyStabber>(),
                ModContent.ItemType<RotBall>(),
                ModContent.ItemType<ToothBall>(),
                //Classless
                ModContent.ItemType<Aestheticus>(),
                ModContent.ItemType<Skynamite>()
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedQueenBee, $"NPCName.QueenBee",
            [
                ModContent.ItemType<TheBee>(),
                ModContent.ItemType<HardenedHoneycomb>(),
                ModContent.ItemType<HoneyDew>()
                
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedBoss3, $"NPCName.SkeletronHead",
            [
                //Accessories
                ModContent.ItemType<IronBoots>(),
                ModContent.ItemType<CounterScarf>(),
                ModContent.ItemType<MirageMirror>(),
                ModContent.ItemType<OldDie>(),
                ModContent.ItemType<AnechoicPlating>(),
                ModContent.ItemType<DepthCharm>(),
                ModContent.ItemType<ArchaicPowder>(),
                //Weapons
                ModContent.ItemType<BallOFugu>(),
                //Ranged Weapons
                ModContent.ItemType<Archerfish>(),
                //Magic Weapons
                ModContent.ItemType<AbyssShocker>(),
                ModContent.ItemType<BlackAnurian>(),
                //Summon Weapons
                ModContent.ItemType<EyeOfNight>(),
                ModContent.ItemType<StaffOfNecrosteocytes>(),
                ModContent.ItemType<FleshOfInfidelity>(),
                ModContent.ItemType<HerringStaff>(),
                //Rogue Weapons
                ModContent.ItemType<Glaive>(),
                ModContent.ItemType<Kylie>(),
                ModContent.ItemType<Cinquedea>(),
                ModContent.ItemType<ShinobiBlade>(),
                ModContent.ItemType<Lionfish>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedSlimeGod, $"Mods.CalamityMod.NPCs.SlimeGodCore.DisplayName",
            [
                //Accessories
                ModContent.ItemType<RadiantOoze>(),
                ModContent.ItemType<JellyChargedBattery>(),
                ModContent.ItemType<ManaPolarizer>(),
                //Weapons
                ModContent.ItemType<GeliticBlade>(),
                ModContent.ItemType<TheGodsGambit>(),
                ModContent.ItemType<FracturedArk>(),
                //Ranged Weapons
                ModContent.ItemType<GunkShot>(),
                ModContent.ItemType<OverloadedBlaster>(),
                //Magic Weapons
                ModContent.ItemType<NightsRay>(),
                ModContent.ItemType<AbyssalTome>(),
                ModContent.ItemType<EldritchTome>(),
                //Summon Weapons
                ModContent.ItemType<CorroslimeStaff>(),
                ModContent.ItemType<CrimslimeStaff>(),
                ModContent.ItemType<SlimePuppetStaff>(),
                //Rogue Weapons
                ModContent.ItemType<GelDart>(),
            ]);

            BossLockInformation.AddLockInformation(() => Main.hardMode, $"NPCName.WallofFlesh",
            [
                //Accessories
                ModContent.ItemType<GrandGelatin>(),
                ModContent.ItemType<AmalgamatedBrain>(),
                ModContent.ItemType<BloodyWormScarf>(),
                ModContent.ItemType<EvasionScarf>(),
                ModContent.ItemType<RogueEmblem>(),
                ModContent.ItemType<TheFirstShadowflame>(),
                ModContent.ItemType<WifeinaBottle>(),
                ModContent.ItemType<WifeinaBottlewithBoobs>(),
                ModContent.ItemType<EyeoftheStorm>(),
                ModContent.ItemType<GiantTortoiseShell>(),
                ModContent.ItemType<HowlsHeart>(),
                ModContent.ItemType<TheTransformer>(),
                ModContent.ItemType<UrsaSergeant>(),
                ModContent.ItemType<SpelunkersAmulet>(),
                ModContent.ItemType<SupremeBaitTackleBoxFishingStation>(),
                ModContent.ItemType<DeepDiver>(),
                //Weapons
                ModContent.ItemType<Aftershock>(),
                ModContent.ItemType<AxeofPurity>(),
                ModContent.ItemType<Carnage>(),
                ModContent.ItemType<CelestialClaymore>(),
                ModContent.ItemType<EutrophicScimitar>(),
                ModContent.ItemType<EvilSmasher>(),
                ModContent.ItemType<StormSaber>(),
                ModContent.ItemType<TrueCausticEdge>(),
                ModContent.ItemType<Roxcalibur>(),
                ModContent.ItemType<YinYo>(),
                ModContent.ItemType<EarthenPike>(),
                ModContent.ItemType<ClamCrusher>(),
                ModContent.ItemType<TheDarkMaster>(), 
                //Ranged Weapons
                ModContent.ItemType<FlarewingBow>(),
                ModContent.ItemType<Buzzkill>(),
                ModContent.ItemType<ClamorRifle>(),
                ModContent.ItemType<Needler>(),
                ModContent.ItemType<P90>(),
                ModContent.ItemType<SlagMagnum>(),
                ModContent.ItemType<Meowthrower>(),
                ModContent.ItemType<PolarisParrotfish>(),
                ModContent.ItemType<MidasPrime>(),
                ModContent.ItemType<ThermoclineBlaster>(),
                ModContent.ItemType<NitroExpressRifle>(),
                ItemID.RocketI,
                ItemID.RocketII,
                //Magic Weapons
                ModContent.ItemType<GloriousEnd>(),
                ModContent.ItemType<FrigidflashBolt>(),
                ModContent.ItemType<Poseidon>(),
                ModContent.ItemType<Serpentine>(),
                ModContent.ItemType<ClothiersWrath>(),
                //Summon Weapons
                ModContent.ItemType<AncientIceChunk>(),
                ModContent.ItemType<BlackHawkRemote>(),
                ModContent.ItemType<CausticStaff>(),
                ModContent.ItemType<HauntedScroll>(),
                ModContent.ItemType<ShellfishStaff>(),
                //Rogue Weapons
                ModContent.ItemType<BlastBarrel>(),
                ModContent.ItemType<BlazingStar>(),
                ModContent.ItemType<Equanimity>(),
                ModContent.ItemType<CursedDagger>(),
                ModContent.ItemType<Prismalline>(),
                ModContent.ItemType<IchorSpear>(),
                ModContent.ItemType<WaveSkipper>(),
                ModContent.ItemType<BurningStrife>(),
                ModContent.ItemType<GacruxianMollusk>(),
                ModContent.ItemType<SlickCane>(),
                //Classless
                ModContent.ItemType<LunicEye>(),
                ModContent.ItemType<StarStruckWater>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedCryogen, $"Mods.CalamityMod.NPCs.Cryogen.DisplayName",
            [
                ModContent.ItemType<SoulofCryogen>(),
                ModContent.ItemType<StarlightWings>(),
                ModContent.ItemType<FrostFlare>(),
                ModContent.ItemType<AmbrosialAmpoule>(),
                ModContent.ItemType<CryoStone>(),
                ModContent.ItemType<OrnateShield>(),
                ModContent.ItemType<PermafrostsConcoction>(),
                ModContent.ItemType<GlacialEmbrace>(),
                ModContent.ItemType<HoarfrostBow>(),
                ModContent.ItemType<Icebreaker>(),
                ModContent.ItemType<Avalanche>(),
                ModContent.ItemType<SnowstormStaff>(),
                ModContent.ItemType<KelvinCatalyst>(),
                ModContent.ItemType<FrostbiteBlaster>(),
                ModContent.ItemType<IcicleTrident>(),
                ModContent.ItemType<IceStar>()
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedAquaticScourge, $"Mods.CalamityMod.NPCs.AquaticScourgeHead.DisplayName",
            [
                ModContent.ItemType<AquaticEmblem>(),
                ModContent.ItemType<CorrosiveSpine>(),
                ModContent.ItemType<NuclearFuelRod>(),
                ModContent.ItemType<SubmarineShocker>(),
                ModContent.ItemType<Barinautical>(),
                ModContent.ItemType<Downpour>(),
                ModContent.ItemType<DeepseaStaff>(),
                ModContent.ItemType<ScourgeoftheSeas>(),
                ModContent.ItemType<SulphurousGrabber>(),
                ModContent.ItemType<FlakToxicannon>(),
                ModContent.ItemType<SlitheringEels>(),
                ModContent.ItemType<BelchingSaxophone>(),
                ModContent.ItemType<OrthoceraShell>(),
                ModContent.ItemType<SkyfinBombers>(),
                ModContent.ItemType<SpentFuelContainer>(),
                ModContent.ItemType<Bonebreaker>(),
                ModContent.ItemType<CorrodedCaustibow>(),
                ModContent.ItemType<Miasma>(),
                ModContent.ItemType<AcidicRainBarrel>(),
                ModContent.ItemType<SeasSearing>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedMechBoss1, $"Mods.MidnightNohit.UI.Tiering.DestroyerShort",
            [
                ModContent.ItemType<GaussPistol>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedMechBoss2, $"Enemies.TheTwins",
            [
                ModContent.ItemType<Arbalest>(),
                ModContent.ItemType<SpeedBlaster>(),
                ModContent.ItemType<FrequencyManipulator>(),
                ModContent.ItemType<HydraulicVoltCrasher>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedMechBoss3, $"NPCName.SkeletronPrime",
            [
                ModContent.ItemType<GraveGrimreaver>(),
                ModContent.ItemType<InfernaCutter>(),
                ModContent.ItemType<MatterModulator>(),
                ModContent.ItemType<MountedScanner>(),
                ModContent.ItemType<ForbiddenOathblade>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedMechBoss3 && (NPC.downedMechBoss2 || NPC.downedMechBoss1), $"Mods.MidnightNohit.UI.Tiering.SPAndOne",
            [
                ModContent.ItemType<IonBlaster>()
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedCryogen && NPC.downedMechBossAny, $"Mods.MidnightNohit.UI.Tiering.CryoAndOne",
            [
                ModContent.ItemType<CrystalPiercer>(),
                ModContent.ItemType<FlarefrostBlade>(),
                ModContent.ItemType<DarklightGreatsword>(),
                ModContent.ItemType<StarnightLance>(),
                ModContent.ItemType<DarkechoGreatbow>(),
                ModContent.ItemType<Shimmerspark>(),
                ModContent.ItemType<ShadecrystalBarrage>(),
                ModContent.ItemType<DaedalusGolemStaff>(),
                ModContent.ItemType<ShardlightPickaxe>(),
                ModContent.ItemType<AbyssalWarhammer>()
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedMechBossAny, $"Mods.MidnightNohit.UI.Tiering.OneMech",
            [
                ModContent.ItemType<SHPC>(),
                ModContent.ItemType<AnarchyBlade>(),
                ModContent.ItemType<TundraFlameBlossomsStaff>(),
                ModContent.ItemType<ElectriciansGlove>(),
                ModContent.ItemType<RuinMedallion>(),
                ModContent.ItemType<HoneyDew>(),
                ModContent.ItemType<BrimstoneFury>(),
                ModContent.ItemType<BrimstoneSword>(),
                ModContent.ItemType<BurningSea>(),
                ModContent.ItemType<BrimroseStaff>(),
                ModContent.ItemType<Brimblade>(),
                ModContent.ItemType<IgneousExaltation>(),
                ModContent.ItemType<WyvernsCall>(),
                ModContent.ItemType<Nychthemeron>(),
                ModContent.ItemType<StormfrontRazor>(),
                ModContent.ItemType<MythrilKnife>(),
                ModContent.ItemType<OrichalcumSpikedGemstone>(),
                ModContent.ItemType<AnarchyBlade>(),
                ModContent.ItemType<SHPC>(),
                ModContent.ItemType<DeepcoreGK2>(),
                ItemID.OrichalcumSword,
                ItemID.OrichalcumRepeater,
                ItemID.OrichalcumHalberd,
                ItemID.OrichalcumChainsaw,
                ItemID.OrichalcumDrill,
                ItemID.OrichalcumPickaxe,
                ItemID.OrichalcumWaraxe,
                ItemID.MythrilSword,
                ItemID.MythrilRepeater,
                ItemID.MythrilHalberd,
                ItemID.MythrilDrill,
                ItemID.MythrilChainsaw,
                ItemID.MythrilPickaxe,
                ItemID.MythrilWaraxe,
                ItemID.Yelets,
                ItemID.MushroomSpear,
                ItemID.Hammush,
                ItemID.Code2,
                ItemID.BookStaff,
                ItemID.DD2PhoenixBow,
                ItemID.MonkStaffT1,
                ItemID.MonkStaffT2,
                ItemID.DD2SquireDemonSword,
                ItemID.SpiritFlame,
                ItemID.SkyFracture,
                ItemID.OnyxBlaster,
            ]);

            BossLockInformation.AddLockInformation(() => GetMechsDead() >= 2, $"Mods.MidnightNohit.UI.Tiering.TwoMech",
            [
                ModContent.ItemType<SHPC>(),
                ModContent.ItemType<AnarchyBlade>(),
                ModContent.ItemType<TundraFlameBlossomsStaff>(),
                ModContent.ItemType<ElectriciansGlove>(),
                ModContent.ItemType<RuinMedallion>(),
                ModContent.ItemType<HoneyDew>(),
                ModContent.ItemType<BrimstoneFury>(),
                ModContent.ItemType<BrimstoneSword>(),
                ModContent.ItemType<BurningSea>(),
                ModContent.ItemType<BrimroseStaff>(),
                ModContent.ItemType<Brimblade>(),
                ModContent.ItemType<IgneousExaltation>(),
                ModContent.ItemType<WyvernsCall>(),
                ModContent.ItemType<Nychthemeron>(),
                ModContent.ItemType<StormfrontRazor>(),
                ModContent.ItemType<MythrilKnife>(),
                ModContent.ItemType<OrichalcumSpikedGemstone>(),
                ModContent.ItemType<AnarchyBlade>(),
                ModContent.ItemType<SHPC>(),
                ItemID.OrichalcumSword,
                ItemID.OrichalcumRepeater,
                ItemID.OrichalcumHalberd,
                ItemID.OrichalcumChainsaw,
                ItemID.OrichalcumDrill,
                ItemID.OrichalcumPickaxe,
                ItemID.OrichalcumWaraxe,
                ItemID.MythrilSword,
                ItemID.MythrilRepeater,
                ItemID.MythrilHalberd,
                ItemID.MythrilDrill,
                ItemID.MythrilChainsaw,
                ItemID.MythrilPickaxe,
                ItemID.MythrilWaraxe,
                ItemID.Yelets,
                ItemID.MushroomSpear,
                ItemID.Hammush,
                ItemID.Code2,
                ItemID.BookStaff,
                ItemID.DD2PhoenixBow,
                ItemID.MonkStaffT1,
                ItemID.MonkStaffT2,
                ItemID.DD2SquireDemonSword,
                ItemID.SpiritFlame,
                ItemID.SkyFracture,
                ItemID.OnyxBlaster,
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3, $"Mods.MidnightNohit.UI.Tiering.AllMech",
            [
                ModContent.ItemType<MOAB>(),
                ModContent.ItemType<AngelTreads>(),
                ModContent.ItemType<HallowedRune>(),
                ModContent.ItemType<MomentumCapacitor>(),
                ModContent.ItemType<TrueBiomeBlade>(),
                ModContent.ItemType<Cryophobia>(),
                ModContent.ItemType<VengefulSunStaff>(),
                ModContent.ItemType<SpearofDestiny>(),
                ModContent.ItemType<ValkyrieRay>(),
                ModContent.ItemType<CatastropheClaymore>(),
                ModContent.ItemType<Pwnagehammer>(),
                ModContent.ItemType<Exorcism>(),
                ModContent.ItemType<GleamingMagnolia>(),
                ModContent.ItemType<TerrorTalons>(),
                ItemID.MinecartMech,
                ItemID.HallowedBar,
                ItemID.AvengerEmblem,
                ItemID.HallowJoustingLance,
                ItemID.PickaxeAxe,
                ItemID.Drax,
                ItemID.Gungnir,
                ItemID.Excalibur,
                ItemID.LightDisc,
                ItemID.HallowedRepeater,
                ItemID.TrueExcalibur,
                ItemID.TrueNightsEdge,
                ItemID.ChlorophytePartisan,
                ItemID.ChlorophyteSaber,
                ItemID.ChlorophyteClaymore,
                ItemID.ChlorophyteShotbow,
                ItemID.ChlorophytePickaxe,
                ItemID.ChlorophyteDrill,
                ItemID.ChlorophyteChainsaw,
                ItemID.ChlorophyteGreataxe,
                ItemID.ChlorophyteWarhammer,
                ItemID.ChlorophyteJackhammer,
                ItemID.VenomStaff,
                ItemID.DeathSickle,
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedCryogen && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3, $"Mods.MidnightNohit.UI.Tiering.CryoAndAll",
            [
                ModContent.ItemType<ArcticBearPaw>(),
                ModContent.ItemType<FrostyFlare>(),
                ModContent.ItemType<CryogenicStaff>()
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedBrimstoneElemental, $"Mods.CalamityMod.NPCs.BrimstoneElemental.DisplayName",
            [
                ModContent.ItemType<Abaddon>(),
                ModContent.ItemType<FlameLickedShell>(),
                ModContent.ItemType<RoseStone>(),
                ModContent.ItemType<Brimlance>(),
                ModContent.ItemType<Hellborn>(),
                ModContent.ItemType<Brimlance>(),
                ModContent.ItemType<SeethingDischarge>(),
                ModContent.ItemType<DormantBrimseeker>()
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedCalamitasClone, $"Mods.CalamityMod.NPCs.CalamitasClone.DisplayName",
            [
				//Accessories
                ModContent.ItemType<ChaosStone>(),
                ModContent.ItemType<VampiricTalisman>(),
                ModContent.ItemType<VoidofCalamity>(),
                ModContent.ItemType<Regenator>(),
                //Weapons
                ModContent.ItemType<Brimlash>(),
                ModContent.ItemType<Oblivion>(),               
                //Ranged Weapons
                ModContent.ItemType<Animosity>(),
                ModContent.ItemType<HavocsBreath>(),
                //Magic Weapons
                ModContent.ItemType<ArtAttack>(),
                ModContent.ItemType<LashesofChaos>(),            
                //Summon Weapons
                ModContent.ItemType<EntropysVigil>(),
                //Rogue Weapons
                ModContent.ItemType<TotalityBreakers>(),
                ModContent.ItemType<CrushsawCrasher>(),
                ModContent.ItemType<DeepWounder>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedPlantBoss, $"NPCName.Plantera",
            [
                ModContent.ItemType<AureateBooster>(),
                ModContent.ItemType<AbyssalMirror>(),
                ModContent.ItemType<DeadshotBrooch>(),
                ModContent.ItemType<GloveOfPrecision>(),
                ModContent.ItemType<GloveOfRecklessness>(),
                ModContent.ItemType<NecklaceofVexation>(),
                ModContent.ItemType<SandSharkToothNecklace>(),
                ModContent.ItemType<StatisBlessing>(),
                ModContent.ItemType<BloomStone>(),
                ModContent.ItemType<AsgardsValor>(),
                //Weapons
                ModContent.ItemType<AbsoluteZero>(),
                ModContent.ItemType<CometQuasher>(),
                ModContent.ItemType<FeralthornClaymore>(),
                ModContent.ItemType<Hellkite>(),
                ModContent.ItemType<MantisClaws>(),
                ModContent.ItemType<BlightedCleaver>(),
                ModContent.ItemType<Quagmire>(),
                ModContent.ItemType<HellionFlowerSpear>(),
                ModContent.ItemType<BotanicPiercer>(),
                ModContent.ItemType<Tumbleweed>(),
                ModContent.ItemType<TrueArkoftheAncients>(),
                //Ranged Weapons
                ModContent.ItemType<TheBallista>(),
                ModContent.ItemType<BlossomFlux>(),
                ModContent.ItemType<VernalBolter>(),
                ModContent.ItemType<EternalBlizzard>(),
                ModContent.ItemType<MarksmanBow>(),
                ModContent.ItemType<BladedgeRailbow>(),
                ModContent.ItemType<WildfireBloom>(),
                ModContent.ItemType<SandstormGun>(),
                ModContent.ItemType<Arietes41>(),
                ItemID.RocketIII,
                ItemID.RocketIV,
                //Magic Weapons
                ModContent.ItemType<ShiftingSands>(),
                ModContent.ItemType<Photosynthesis>(),
                ModContent.ItemType<EvergladeSpray>(),
                ModContent.ItemType<PrimordialEarth>(),
                ModContent.ItemType<TearsofHeaven>(),
                ModContent.ItemType<WintersFury>(),
                ModContent.ItemType<WrathoftheAncients>(),
                //Summon Weapons
                ModContent.ItemType<PlantationStaff>(),
                ModContent.ItemType<SandSharknadoStaff>(),
                ModContent.ItemType<ViralSprout>(),
                //Rogue Weapons
                ModContent.ItemType<DuststormInABottle>(),
                ModContent.ItemType<DefectiveSphere>(),
                ModContent.ItemType<FrostcrushValari>(),
                ModContent.ItemType<MangroveChakram>(),
                ModContent.ItemType<SamsaraSlicer>(),
                ModContent.ItemType<MonkeyDarts>(),
                ModContent.ItemType<FantasyTalisman>(),
                ModContent.ItemType<Sandslasher>(),
                //Classless
                ModContent.ItemType<Hydra>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedAstrumAureus, $"Mods.CalamityMod.NPCs.AstrumAureus.DisplayName",
            [
                //Accessories
                ModContent.ItemType<StarbusterCore>(),
                ModContent.ItemType<InfectedJewel>(),
                ModContent.ItemType<GravistarSabaton>(),
                ModContent.ItemType<HadarianWings>(),
                //Weapons
                ModContent.ItemType<AstralScythe>(),
                ModContent.ItemType<TitanArm>(),
                ModContent.ItemType<Nebulash>(),
                //Ranged Weapons
                ModContent.ItemType<AuroraBlazer>(),
                ModContent.ItemType<StellarCannon>(),
                //Magic Weapons
                ModContent.ItemType<AlulaAustralis>(),
                ModContent.ItemType<AstralachneaStaff>(),
                //Summon Weapons
                ModContent.ItemType<AbandonedSlimeStaff>(),
                ModContent.ItemType<HivePod>(),
                ModContent.ItemType<BorealisBomber>(), 
                //Rogue Weapons
                ModContent.ItemType<StellarKnife>(),
                ModContent.ItemType<AuroradicalThrow>(),
                ModContent.ItemType<HeavenfallenStardisk>(),
                ModContent.ItemType<LeonidProgenitor>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedLeviathan, $"Mods.MidnightNohitCalamity.Tiering.LeviathanShort",
            [
                //Accessories
                ModContent.ItemType<LeviathanAmbergris>(),
                ModContent.ItemType<TheCommunity>(),
                ModContent.ItemType<PearlofEnthrallment>(),
                ModContent.ItemType<AbyssalMirror>(),
                ModContent.ItemType<AbyssalDivingSuit>(),
                ModContent.ItemType<LumenousAmulet>(),
                //Weapons
                ModContent.ItemType<Greentide>(),
                ModContent.ItemType<AbyssBlade>(),
                ModContent.ItemType<Floodtide>(),
                ModContent.ItemType<TyphonsGreed>(),
                //Ranged Weapons
                ModContent.ItemType<Leviatitan>(),
                ModContent.ItemType<FlakKraken>(),
                ModContent.ItemType<Megalodon>(),
                //Magic Weapons
                ModContent.ItemType<Atlantis>(),
                ModContent.ItemType<Keelhaul>(),
                ModContent.ItemType<AnahitasArpeggio>(),
                ModContent.ItemType<HadalUrn>(),
                ModContent.ItemType<UndinesRetribution>(),
                //Summon Weapons
                ModContent.ItemType<GastricBelcherStaff>(),
                ModContent.ItemType<DreadmineStaff>(),
                //Rogue Weapons
                ModContent.ItemType<BrackishFlask>(),
                ModContent.ItemType<LeviathanTeeth>(),
                ModContent.ItemType<Apoctolith>(),
                ModContent.ItemType<BallisticPoisonBomb>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedGolemBoss, $"NPCName.Golem",
            [ 
                //Accessories
                ModContent.ItemType<HadalMantle>(),
                ModContent.ItemType<PlaguedFuelPack>(),
                ModContent.ItemType<SigilofCalamitas>(),
                ModContent.ItemType<StarTaintedGenerator>(),
                ModContent.ItemType<VoidofExtinction>(),
                ModContent.ItemType<AlchemicalFlask>(),
                ModContent.ItemType<TheCamper>(),
                //Weapons
                ModContent.ItemType<AegisBlade>(),
                ModContent.ItemType<HellfireFlamberge>(),
                ModContent.ItemType<Lucrecia>(),
                ModContent.ItemType<SoulHarvester>(),
                ModContent.ItemType<FaultLine>(),
                ModContent.ItemType<VulcaniteLance>(),
                ModContent.ItemType<FallenPaladinsHammer>(),
                ModContent.ItemType<Omniblade>(),
                //Ranged Weapons
                ModContent.ItemType<ContinentalGreatbow>(),
                ModContent.ItemType<ClockGatlignum>(),
                ModContent.ItemType<Helstorm>(),
                ModContent.ItemType<BarracudaGun>(),
                ModContent.ItemType<NullificationPistol>(),
                ModContent.ItemType<PearlGod>(),
                //Magic Weapons
                ModContent.ItemType<InfernalRift>(),
                ModContent.ItemType<Wingman>(),
                ModContent.ItemType<ForbiddenSun>(),
                //Summon Weapons
                ModContent.ItemType<ResurrectionButterfly>(),
                ModContent.ItemType<WitherBlossomsStaff>(),
                //Rogue Weapons
                ModContent.ItemType<Plaguenade>(),
                ModContent.ItemType<ShockGrenade>(),
                ModContent.ItemType<EpidemicShredder>(),
                ModContent.ItemType<SubductionSlicer>(),
                //Classless
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedPlaguebringer, $"Mods.CalamityMod.NPCs.PlaguebringerGoliath.DisplayName",
            [
                //Accessories
                //ModContent.ItemType<PlagueHive>(),
                ModContent.ItemType<ToxicHeart>(),
                
                //Weapons
                ModContent.ItemType<ExaltedOathblade>(),
                ModContent.ItemType<Virulence>(),
                ModContent.ItemType<Pandemic>(),
                ModContent.ItemType<DiseasedPike>(),
                ModContent.ItemType<GalvanizingGlaive>(),
                //Ranged Weapons
                ModContent.ItemType<Malevolence>(),
                ModContent.ItemType<TheHive>(),
                ModContent.ItemType<BlightSpewer>(),
                ModContent.ItemType<GaussRifle>(),
                ModContent.ItemType<PestilentDefiler>(),
                //Magic Weapons
                ModContent.ItemType<PlagueStaff>(),
                ModContent.ItemType<GatlingLaser>(),
                //Summon Weapons
                ModContent.ItemType<FuelCellBundle>(),
                ModContent.ItemType<InfectedRemote>(),
                ModContent.ItemType<PulseTurretRemote>(),
                //Rogue Weapons
                ModContent.ItemType<Malachite>(),
                ModContent.ItemType<SystemBane>(),
                ModContent.ItemType<TheSyringe>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedFishron, $"NPCName.DukeFishron",
            [
                ModContent.ItemType<BrinyBaron>(),
                ModContent.ItemType<DukesDecapitator>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedRavager, $"Mods.CalamityMod.NPCs.RavagerBody.DisplayName",
            [
                ModContent.ItemType<BloodPact>(),
                ModContent.ItemType<FleshTotem>(),
                //Weapons
                ModContent.ItemType<UltimusCleaver>(),
                //Ranged Weapons
                ModContent.ItemType<RealmRavager>(),
                //Magic Weapons
                ModContent.ItemType<Hematemesis>(),
                ModContent.ItemType<Vesuvius>(),
                //Summon Weapons
                ModContent.ItemType<SpikecragStaff>(),
                //Rogue Weapons
                ModContent.ItemType<CraniumSmasher>(),
                ModContent.ItemType<CorpusAvertor>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedAncientCultist, $"Mods.MidnightNohit.UI.Tiering.CultistShort",
            [
                ModContent.ItemType<DarkMatterSheath>(),
                ModContent.ItemType<StatisCurse>(),
                ModContent.ItemType<HeartoftheElements>(),
                ModContent.ItemType<TheAbsorber>(),
                //Weapons
                ModContent.ItemType<BalefulHarvester>(),
                ModContent.ItemType<EntropicClaymore>(),
                ModContent.ItemType<GrandGuardian>(),
                ModContent.ItemType<StormRuler>(),
                ModContent.ItemType<TenebreusTides>(),
                ModContent.ItemType<Respiteblock>(),
                //Ranged Weapons
                ModContent.ItemType<ConferenceCall>(),
                ModContent.ItemType<Shroomer>(),
                ModContent.ItemType<Vortexpopper>(),
                ModContent.ItemType<Scorpio>(),
                ModContent.ItemType<DeadSunsWind>(),
                ModContent.ItemType<SpectralstormCannon>(),
                //Magic Weapons
                ModContent.ItemType<ArchAmaryllis>(),
                ModContent.ItemType<Lazhar>(),
                ModContent.ItemType<NanoPurge>(),
                ModContent.ItemType<TheSwarmer>(),
                ModContent.ItemType<TomeofFates>(),
                ModContent.ItemType<CosmicRainbow>(),
                //Summon Weapons
                //Rogue Weapons
                ModContent.ItemType<StarofDestruction>(),
                ModContent.ItemType<ShardofAntumbra>(),
                //Classless 
                ModContent.ItemType<EyeofMagnus>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedAstrumDeus, $"Mods.CalamityMod.NPCs.AstrumDeusHead.DisplayName",
            [
                ModContent.ItemType<DeificAmulet>(),
                ModContent.ItemType<HideofAstrumDeus>(),
                //Weapons
                ModContent.ItemType<AstralBlade>(),
                ModContent.ItemType<OmegaBiomeBlade>(),
                ModContent.ItemType<TheMicrowave>(),
                ModContent.ItemType<AstralPike>(),
                //Ranged Weapons
                ModContent.ItemType<AstralBow>(),
                ModContent.ItemType<StarSputter>(),
                //Magic Weapons
                ModContent.ItemType<StarShower>(),
                ModContent.ItemType<AstralStaff>(),
                //Summon Weapons
                ModContent.ItemType<StarspawnHelixStaff>(),
                ModContent.ItemType<RadiantStar>(),
                ModContent.ItemType<RegulusRiot>(),
            ]);

            BossLockInformation.AddLockInformation(() => NPC.downedMoonlord, $"Enemies.MoonLord",
            [
                ModContent.ItemType<ExodusWings>(),
                ModContent.ItemType<TracersCelestial>(),
                ModContent.ItemType<StatisNinjaBelt>(),
                ModContent.ItemType<DaawnlightSpiritOrigin>(),
                ModContent.ItemType<EldritchSoulArtifact>(),
                ModContent.ItemType<MoonstoneCrown>(),
                ModContent.ItemType<AbyssalDivingSuit>(),
                //Weapons
                ModContent.ItemType<Devastation>(),
                ModContent.ItemType<ElementalShiv>(),
                ModContent.ItemType<GreatswordofJudgement>(),
                ModContent.ItemType<PlagueKeeper>(),
                ModContent.ItemType<SolsticeClaymore>(),
                ModContent.ItemType<StellarStriker>(),
                ModContent.ItemType<ElementalLance>(),
                ModContent.ItemType<StellarContempt>(),
                ModContent.ItemType<RemsRevenge>(),
                ModContent.ItemType<ArkoftheElements>(),
                //Ranged Weapons
                ModContent.ItemType<AstrealDefeat>(),
                ModContent.ItemType<ClockworkBow>(),
                ModContent.ItemType<PlanetaryAnnihilation>(),
                ModContent.ItemType<Disseminator>(),
                ModContent.ItemType<OnyxChainBlaster>(),
                ModContent.ItemType<PridefulHuntersPlanarRipper>(),
                ModContent.ItemType<Shredder>(),
                ModContent.ItemType<ElementalEruption>(),
                ModContent.ItemType<SuperradiantSlaughterer>(),
                ModContent.ItemType<Starfleet>(),
                ItemID.MiniNukeI,
                ItemID.MiniNukeII,
                //Magic Weapons
                ModContent.ItemType<AsteroidStaff>(),
                ModContent.ItemType<ElementalRay>(),
                ModContent.ItemType<UltraLiquidator>(),
                ModContent.ItemType<ApoctosisArray>(),
                ModContent.ItemType<Effervescence>(),
                ModContent.ItemType<Genesis>(),
                ModContent.ItemType<AuguroftheElements>(),
                ModContent.ItemType<NuclearFury>(),
                ModContent.ItemType<ChronomancersScythe>(),
                //Summon Weapons
                ModContent.ItemType<ElementalAxe>(),
                ModContent.ItemType<FlowersOfMortality>(),
                ModContent.ItemType<TacticalPlagueEngine>(),
                ModContent.ItemType<SanctifiedSpark>(),
                //Rogue Weapons
                ModContent.ItemType<ElementalDisk>(),
                ModContent.ItemType<LunarKunai>(),
                ModContent.ItemType<UtensilPoker>(),
                ModContent.ItemType<HellsSun>(),
                ModContent.ItemType<CelestialReaper>(),
                ModContent.ItemType<AlphaVirus>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedGuardians, $"Mods.CalamityMod.BossChecklistIntegration.ProfanedGuardians.EntryName",
            [
                ModContent.ItemType<WarbanneroftheSun>(),
                ModContent.ItemType<RelicOfConvergence>(),
                ModContent.ItemType<RelicOfDeliverance>(),
                ModContent.ItemType<RelicOfResilience>()
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedDragonfolly, $"Mods.CalamityMod.NPCs.Bumblefuck.DisplayName",
            [
                ModContent.ItemType<BlunderBooster>(),
                ModContent.ItemType<DynamoStemCells>(),
                //Weapons
                ModContent.ItemType<Swordsplosion>(),
                ModContent.ItemType<GildedProboscis>(),
                //Ranged Weapons
                ModContent.ItemType<GoldenEagle>(),
                //Magic Weapon
                ModContent.ItemType<MadAlchemistsCocktailGlove>(),
                ModContent.ItemType<RougeSlash>()
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedProvidence, $"Mods.MidnightNohit.UI.Tiering.ProviShort",
            [
                ModContent.ItemType<ElysianWings>(),
                ModContent.ItemType<TarragonWings>(),
                ModContent.ItemType<BloodflareCore>(),
                ModContent.ItemType<BadgeofBravery>(),
                ModContent.ItemType<BlazingCore>(),
                ModContent.ItemType<ElysianAegis>(),
                ModContent.ItemType<ProfanedSoulArtifact>(),               
                //Weapons
                ModContent.ItemType<GalactusBlade>(),
                ModContent.ItemType<Grax>(),
                ModContent.ItemType<HolyCollider>(),
                ModContent.ItemType<LifehuntScythe>(),
                ModContent.ItemType<TheMutilator>(),
                ModContent.ItemType<Terratomere>(),
                ModContent.ItemType<DefiledGreatsword>(),
                ModContent.ItemType<Lacerator>(),
                ModContent.ItemType<BurningRevelation>(),
                ModContent.ItemType<SeekingScorcher>(),
                ModContent.ItemType<Mourningstar>(),
                ModContent.ItemType<PulseDragon>(),
                ModContent.ItemType<DevilsSunrise>(),
                //Ranged Weapons
                ModContent.ItemType<ArterialAssault>(),
                ModContent.ItemType<NettlevineGreatbow>(),
                ModContent.ItemType<TelluricGlare>(),
                ModContent.ItemType<AngelicShotgun>(),
                ModContent.ItemType<Auralis>(),
                ModContent.ItemType<ClaretCannon>(),
                ModContent.ItemType<Spyker>(),
                ModContent.ItemType<BlissfulBombardier>(),
                ModContent.ItemType<HandheldTank>(),
                ModContent.ItemType<BloodBoiler>(),
                ModContent.ItemType<PristineFury>(),
                ModContent.ItemType<HeavyLaserRifle>(),
                //Magic Weapons
                //ModContent.ItemType<DivineRe>(),
                ModContent.ItemType<ThePrince>(),
                ModContent.ItemType<SanguineFlare>(),
                ModContent.ItemType<ThornBlossom>(),
                ModContent.ItemType<Viscera>(),
                ModContent.ItemType<PlasmaCaster>(),
                ModContent.ItemType<PlasmaRifle>(),
                ModContent.ItemType<PurgeGuzzler>(),
                ModContent.ItemType<Biofusillade>(),
                //Summon Weapons
                ModContent.ItemType<DazzlingStabberStaff>(),
                ModContent.ItemType<DragonbloodDisgorger>(),
                ModContent.ItemType<SnakeEyes>(),
                ModContent.ItemType<ViridVanguard>(),
                ModContent.ItemType<GuidelightofOblivion>(),
                //Rogue Weapons
                ModContent.ItemType<WavePounder>(),
                ModContent.ItemType<MoltenAmputator>(),
                ModContent.ItemType<ShatteredSun>(),
                ModContent.ItemType<TarragonThrowingDart>(),
                ModContent.ItemType<ProfanedPartisan>(),
                ModContent.ItemType<BloodsoakedCrasher>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedStormWeaver, $"Mods.CalamityMod.NPCs.StormWeaverHead.DisplayName",
            [
                ModContent.ItemType<TheStorm>(),
                ModContent.ItemType<Seadragon>(),
                ModContent.ItemType<StormDragoon>(),
                //Magic Weapons
                ModContent.ItemType<Thunderstorm>(),
                ModContent.ItemType<TwistingThunder>(),
                ModContent.ItemType<RealityRupture>(),
                ModContent.ItemType<Teslastaff>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedCeaselessVoid, $"Mods.CalamityMod.NPCs.CeaselessVoid.DisplayName",
            [
                ModContent.ItemType<TheEvolution>(),
                ModContent.ItemType<QuiverofNihility>(),
                //Weapons
                ModContent.ItemType<MirrorBlade>(),
                //Ranged Weapons
                ModContent.ItemType<MolecularManipulator>(),
                //Magic Weapons
                ModContent.ItemType<Mistlestorm>(),
                ModContent.ItemType<TacticiansTrumpCard>(),
                //Summon Weapons
                ModContent.ItemType<VoidConcentrationStaff>(),
                //Rogue Weapons
                ModContent.ItemType<SealedSingularity>(),
                ModContent.ItemType<RealityRupture>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedSignus, $"Mods.MidnightNohit.UI.Tiering.SignusShort",
            [
                ModContent.ItemType<SpectralVeil>(),
                //Ranged Weapons
                ModContent.ItemType<TheSevensStriker>(),
                //Magic Weapons
                ModContent.ItemType<AethersWhisper>(),
                ModContent.ItemType<MagneticMeltdown>(),
                //Summon Weapons
                ModContent.ItemType<Cosmilamp>(),
                ModContent.ItemType<KingofConstellationsTenryu>(),
                //Rogue Weapons
                ModContent.ItemType<CosmicKunai>(),
                ModContent.ItemType<RealityRupture>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedPolterghast, $"Mods.CalamityMod.NPCs.Polterghast.DisplayName",
            [
                ModContent.ItemType<PhantomicArtifact>(),
                ModContent.ItemType<ReaperToothNecklace>(),
                ModContent.ItemType<Affliction>(),
                ModContent.ItemType<AscendantInsignia>(),
                //Weapons
                ModContent.ItemType<GalileoGladius>(),
                ModContent.ItemType<TheLastMourning>(),
                ModContent.ItemType<LionHeart>(),
                ModContent.ItemType<NeptunesBounty>(),
                ModContent.ItemType<VoidEdge>(),
                ModContent.ItemType<TerrorBlade>(),
                ModContent.ItemType<BansheeHook>(),
                ModContent.ItemType<CrescentMoon>(),
                ModContent.ItemType<PhosphorescentGauntlet>(),
                ModContent.ItemType<DeathsAscension>(),
                //Ranged Weapons
                ModContent.ItemType<DaemonsFlame>(),
                ModContent.ItemType<TheMaelstrom>(),
                ModContent.ItemType<Monsoon>(),
                //ModContent.ItemType<DodusHandcannon>(),
                ModContent.ItemType<HalleysInferno>(),
                ModContent.ItemType<SulphuricAcidCannon>(),
                ModContent.ItemType<PearlGod>(),
                //Magic Weapons
                ModContent.ItemType<ClamorNoctus>(),
                ModContent.ItemType<EidolonStaff>(),
                ModContent.ItemType<FatesReveal>(),
                ModContent.ItemType<PhantasmalFury>(),
                ModContent.ItemType<ShadowboltStaff>(),
                ModContent.ItemType<VenusianTrident>(),
                ModContent.ItemType<EidolicWail>(),
                ModContent.ItemType<DarkSpark>(),
                ModContent.ItemType<GhastlyVisage>(),
                //Summon Weapons
                ModContent.ItemType<CalamarisLament>(),
                ModContent.ItemType<EtherealSubjugator>(),
                ModContent.ItemType<GammaHeart>(),
                ModContent.ItemType<Sirius>(),
                ModContent.ItemType<Valediction>(),
                //Rogue Weapons
                ModContent.ItemType<GhoulishGouger>(),
                ModContent.ItemType<JawsOfOblivion>(),
                ModContent.ItemType<TimeBolt>(),
                ModContent.ItemType<PhantasmalRuin>(),
                ModContent.ItemType<NightsGaze>(),
                ModContent.ItemType<DeepSeaDumbbell>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedBoomerDuke, $"Mods.CalamityMod.NPCs.OldDuke.DisplayName",
            [
                ModContent.ItemType<OldDukeScales>(),
                ModContent.ItemType<MutatedTruffle>(),
                //Weapons
                ModContent.ItemType<InsidiousImpaler>(),
                
                //Ranged Weapons
                ModContent.ItemType<FetidEmesis>(),
                ModContent.ItemType<SepticSkewer>(),
                //Magic Weapons
                ModContent.ItemType<VitriolicViper>(),
                //Summon WeaponsS
                ModContent.ItemType<CadaverousCarrion>(),
                //Rogue Weapons
                ModContent.ItemType<ToxicantTwister>(),
                ModContent.ItemType<TheOldReaper>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedDoG, $"Mods.MidnightNohit.UI.Tiering.DogShort",
            [
                ModContent.ItemType<TracersElysian>(),
                ModContent.ItemType<SilvaWings>(),
                ModContent.ItemType<DarkSunRing>(),
                ModContent.ItemType<DimensionalSoulArtifact>(),
                ModContent.ItemType<EclipseMirror>(),
                ModContent.ItemType<ElementalGauntlet>(),
                ModContent.ItemType<ElementalQuiver>(),
                ModContent.ItemType<EtherealTalisman>(),
                ModContent.ItemType<Nanotech>(),
                ModContent.ItemType<NebulousCore>(),
                ModContent.ItemType<Nucleogenesis>(),
                ModContent.ItemType<OccultSkullCrown>(),
                ModContent.ItemType<TheAmalgam>(),
                ModContent.ItemType<VeneratedLocket>(),
                ModContent.ItemType<AsgardianAegis>(),
                ModContent.ItemType<ChaliceOfTheBloodGod>(),
                ModContent.ItemType<RampartofDeities>(),
                ModContent.ItemType<TheSponge>(),
                ModContent.ItemType<Radiance>(),
                //Weapons
                ModContent.ItemType<CosmicShiv>(),
                ModContent.ItemType<DevilsDevastation>(),
                ModContent.ItemType<EssenceFlayer>(),
                ModContent.ItemType<TheEnforcer>(),
                ModContent.ItemType<Excelsus>(),
                ModContent.ItemType<Orderbringer>(),
                ModContent.ItemType<PrismaticBreaker>(),
                ModContent.ItemType<TheObliterator>(),
                ModContent.ItemType<Nadir>(),
                ModContent.ItemType<StreamGouge>(),
                ModContent.ItemType<GalaxySmasher>(),
                ModContent.ItemType<CosmicDischarge>(),
                ModContent.ItemType<EmpyreanKnives>(),
                ModContent.ItemType<FourSeasonsGalaxia>(),
                ModContent.ItemType<Phaseslayer>(),
                ModContent.ItemType<ScourgeoftheCosmos>(),
                ModContent.ItemType<Murasama>(),
                //Ranged Weapons
                ModContent.ItemType<Alluvion>(),
                ModContent.ItemType<Deathwind>(),
                ModContent.ItemType<Phangasm>(),
                ModContent.ItemType<Ultima>(),
                ModContent.ItemType<AntiMaterielRifle>(),
                ModContent.ItemType<Infinity>(),
                ModContent.ItemType<Karasawa>(),
                ModContent.ItemType<Onyxia>(),
                ModContent.ItemType<RubicoPrime>(),
                ModContent.ItemType<SDFMG>(),
                ModContent.ItemType<UniversalGenesis>(),
                ModContent.ItemType<ScorchedEarth>(),
                ModContent.ItemType<ThePack>(),
                ModContent.ItemType<CleansingBlaze>(),
                ModContent.ItemType<PulseRifle>(),
                ModContent.ItemType<Norfleet>(),
                ModContent.ItemType<Starmada>(),
                //Magic Weapons
                ModContent.ItemType<DeathhailStaff>(),
                ModContent.ItemType<IceBarrage>(),
                ModContent.ItemType<SoulPiercer>(),
                ModContent.ItemType<VoltaicClimax>(),
                ModContent.ItemType<Omicron>(),
                ModContent.ItemType<TeslaCannon>(),
                ModContent.ItemType<EventHorizon>(),
                ModContent.ItemType<LightGodsBrilliance>(),
                ModContent.ItemType<PrimordialAncient>(),
                ModContent.ItemType<RecitationoftheBeast>(),
                ModContent.ItemType<FaceMelter>(),
                //Summon Weapons
                ModContent.ItemType<CorvidHarbringerStaff>(),
                ModContent.ItemType<CosmicViperEngine>(),
                ModContent.ItemType<EndoHydraStaff>(),
                ModContent.ItemType<PoleWarper>(),
                ModContent.ItemType<SarosPossession>(),
                ModContent.ItemType<StaffoftheMechworm>(),
                //Rogue Weapons
                ModContent.ItemType<Penumbra>(),
                ModContent.ItemType<PlasmaGrenade>(),
                ModContent.ItemType<Eradicator>(),
                ModContent.ItemType<EclipsesFall>(),
                ModContent.ItemType<GodsParanoia>(),
                ModContent.ItemType<ExecutionersBlade>(),
                ModContent.ItemType<Hypothermia>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedYharon, $"Mods.MidnightNohit.UI.Tiering.YharonShort",
            [
                ModContent.ItemType<TracersCelestial>(),
                ModContent.ItemType<WingsofRebirth>(),
                ModContent.ItemType<DragonScales>(),
                ModContent.ItemType<YharimsGift>(),
                ModContent.ItemType<AuricSoulArtifact>(),
                //Weapons
                ModContent.ItemType<Ataraxia>(),
                ModContent.ItemType<TheOracle>(),
                ModContent.ItemType<DragonPow>(),
                ModContent.ItemType<ArkoftheCosmos>(),
                ModContent.ItemType<TheBurningSky>(),
                ModContent.ItemType<DragonRage>(),
                //Ranged Weapons
                ModContent.ItemType<Drataliornus>(),
                ModContent.ItemType<AcesHigh>(),
                ModContent.ItemType<DragonsBreath>(),
                ModContent.ItemType<Kingsbane>(),
                ModContent.ItemType<TyrannysEnd>(),
                ModContent.ItemType<ChickenCannon>(),
                //Magic Weapons
                ModContent.ItemType<HeliumFlash>(),
                ModContent.ItemType<PhoenixFlameBarrage>(),
                ModContent.ItemType<VoidVortex>(),
                ModContent.ItemType<TheWand>(),
                ModContent.ItemType<AetherfluxCannon>(),
                ModContent.ItemType<YharimsCrystal>(),
                //Summon Weapons
                ModContent.ItemType<MidnightSunBeacon>(),
                ModContent.ItemType<YharonsKindleStaff>(),
                ModContent.ItemType<LiliesOfFinality>(),
                // Rogue Weapons
                ModContent.ItemType<Seraphim>(),
                ModContent.ItemType<Wrathwing>(),
                ModContent.ItemType<TheFinalDawn>(),
                ModContent.ItemType<SearedPan>(),
                ModContent.ItemType<DynamicPursuer>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedExoMechs, $"Mods.MidnightNohit.UI.Tiering.ExoShort",
            [
                ModContent.ItemType<DraedonsHeart>(),
                //Weapons
                ModContent.ItemType<Exoblade>(),
                //ModContent.ItemType<ExoGladius>(), :((((((
                ModContent.ItemType<SpineOfThanatos>(),
                ModContent.ItemType<PhotonRipper>(),
                //Ranged Weapons
                ModContent.ItemType<HeavenlyGale>(),
                ModContent.ItemType<TheJailor>(),
                ModContent.ItemType<SurgeDriver>(),
                ModContent.ItemType<MagnomalyCannon>(),
                ModContent.ItemType<Photoviscerator>(),
                //Magic Weapon
                ModContent.ItemType<VividClarity>(),
                ModContent.ItemType<SubsumingVortex>(),
                //Summon Weapon
                ModContent.ItemType<CosmicImmaterializer>(),
                ModContent.ItemType<AresExoskeleton>(),
                //Rogue Weapons
                ModContent.ItemType<Supernova>(),
                ModContent.ItemType<Celestus>(),
                ModContent.ItemType<TheAtomSplitter>(),
                ModContent.ItemType<RefractionRotor>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedCalamitas, $"Mods.MidnightNohit.UI.Tiering.SCalShort",
            [
                ModContent.ItemType<Calamity>(),
                ModContent.ItemType<ShatteredCommunity>(),
                //Weapons
                ModContent.ItemType<GaelsGreatsword>(),
                ModContent.ItemType<Violence>(),
                //Ranged Weapons
                ModContent.ItemType<Condemnation>(),
                //Magic Weapons
                ModContent.ItemType<Vehemence>(),
                ModContent.ItemType<Heresy>(),
                ModContent.ItemType<Rancor>(),
                ModContent.ItemType<GruesomeEminence>(),
                //Summon Weapons
                ModContent.ItemType<Metastasis>(),
                ModContent.ItemType<Vigilance>(),
                ModContent.ItemType<Perdition>(),
                ModContent.ItemType<CindersOfLament>(),
                //Rogue Weapons
                ModContent.ItemType<Sacrifice>(),
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedPrimordialWyrm, $"Mods.CalamityMod.NPCs.PrimordialWyrmHead.DisplayName",
            [
                ModContent.ItemType<HalibutCannon>()
            ]);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedCalamitas && DownedBossSystem.downedExoMechs, $"Mods.MidnightNohit.UI.Tiering.Endgame",
            [
                ModContent.ItemType<AngelicAlliance>(),
                ModContent.ItemType<ProfanedSoulCrystal>(),
                //Weapons
                ModContent.ItemType<DraconicDestruction>(),
                ModContent.ItemType<Earth>(),
                ModContent.ItemType<IridescentExcalibur>(),
                ModContent.ItemType<RedSun>(),
                ModContent.ItemType<Ozzathoth>(),
                ModContent.ItemType<TriactisTruePaladinianMageHammerofMightMelee>(),
                ModContent.ItemType<IllustriousKnives>(),
                //Ranged Weapons
                ModContent.ItemType<Contagion>(),
                ModContent.ItemType<SomaPrime>(),
                ModContent.ItemType<Svantechnical>(),
                ModContent.ItemType<Voidragon>(), //gets confused with the projectile else lo
                //Magic Weapons
                ModContent.ItemType<Sylvestaff>(),
                ModContent.ItemType<RainbowPartyCannon>(),
                ModContent.ItemType<Apotheosis>(),
                ModContent.ItemType<TheDanceofLight>(),
                ModContent.ItemType<Eternity>(),
                //Summon Weapons
                ModContent.ItemType<Endogenesis>(),
                ModContent.ItemType<TemporalUmbrella>(),
                ModContent.ItemType<FlamsteedRing>(),
                ModContent.ItemType<UniverseSplitter>(),
                //Rogue Weapons
                ModContent.ItemType<NanoblackReaper>(),
                ModContent.ItemType<ScarletDevil>(),
            ]);

            //Potions.
            BossLockInformation.AddLockInformation(() => NPC.downedBoss1, $"NPCName.EyeofCthulhu",
            [
                ModContent.ItemType<SulphurskinPotion>()
            ], true);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedPerforator && DownedBossSystem.downedHiveMind, $"Mods.MidnightNohit.UI.Evils2",
            [
                ModContent.ItemType<TeslaPotion>()
            ], true);

            BossLockInformation.AddLockInformation(() => NPC.downedBoss3, $"NPCName.SkeletronHead",
            [
                ModContent.ItemType<PotionofOmniscience>()
            ], true);

            BossLockInformation.AddLockInformation(() => Main.hardMode, $"NPCName.WallofFlesh",
            [
                ModContent.ItemType<PurpleHaze>(),
                ModContent.ItemType<GrapeBeer>(),
                ModContent.ItemType<Tequila>(),
                ModContent.ItemType<Whiskey>(),
                ModContent.ItemType<Rum>(),
                ModContent.ItemType<Fireball>(),
                ModContent.ItemType<RedWine>(),
                ModContent.ItemType<SoaringPotion>(),
                ModContent.ItemType<FlaskOfCrumbling>()
            ], true);

            BossLockInformation.AddLockInformation(() => NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3, $"Mods.MidnightNohit.UI.Tiering.AllMech",
            [
                ModContent.ItemType<Vodka>(),
                ModContent.ItemType<Screwdriver>(),
                ModContent.ItemType<WhiteWine>(),
            ], true);

            BossLockInformation.AddLockInformation(() => NPC.downedPlantBoss, $"NPCName.Plantera",
            [
                ModContent.ItemType<EvergreenGin>(),
                ModContent.ItemType<Margarita>(),
                ModContent.ItemType<CaribbeanRum>(),
                ModContent.ItemType<OldFashioned>(),
            ], true);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedAstrumAureus, $"Mods.CalamityMod.NPCs.AstrumAureus.DisplayName",
            [
                ModContent.ItemType<Everclear>(),
                ModContent.ItemType<StarBeamRye>(),
                ModContent.ItemType<BloodyMary>(),
                ModContent.ItemType<GravityNormalizerPotion>(),
                ModContent.ItemType<AureusCell>(),
                ModContent.ItemType<AstralInjection>()
            ], true);

            BossLockInformation.AddLockInformation(() => NPC.downedGolemBoss, $"NPCName.Golem",
            [
                ModContent.ItemType<MoscowMule>(),
                ModContent.ItemType<TequilaSunrise>(),
                ModContent.ItemType<Moonshine>(),
                ModContent.ItemType<CinnamonRoll>(),
            ], true);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedCalamitasClone, $"Mods.CalamityMod.NPCs.CalamitasClone.DisplayName",
            [
                ModContent.ItemType<FlaskOfBrimstone>(),
            ], true);

            BossLockInformation.AddLockInformation(() => NPC.downedMoonlord, $"Enemies.MoonLord",
            [
                ModContent.ItemType<SupremeHealingPotion>(),
                ModContent.ItemType<SupremeManaPotion>(),
                ModContent.ItemType<FlaskOfHolyFlames>(),
            ], true);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedProvidence, $"Mods.MidnightNohit.UI.Tiering.ProviShort",
            [
                ModContent.ItemType<Bloodfin>()
            ], true);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedCeaselessVoid, $"Mods.CalamityMod.NPCs.CeaselessVoid.DisplayName",
            [
                ModContent.ItemType<CeaselessHungerPotion>()
            ], true);

            BossLockInformation.AddLockInformation(() => DownedBossSystem.downedDoG, $"Mods.MidnightNohit.UI.Tiering.DogShort",
            [
                ModContent.ItemType<OmegaHealingPotion>()
            ], true);

        }
    }
}
