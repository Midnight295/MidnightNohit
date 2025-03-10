using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using MidnightNohit;
using MidnightNohit.Core;
using CalamityMod;
using Terraria.Localization;

namespace MidnightNohit.Content.UI.BossUI
{
    [JITWhenModsEnabled(ModCompatability.Calamity.Name)]
    [ExtendsFromMod(ModCompatability.Calamity.Name)]
    public static class CalamityBossSupport
    {
        public static void InitializeCalamityBossSupport()
        {
            new BossToggleElement(true, "CalamityMod/NPCs/DesertScourge/DesertScourgeHead_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.DesertScourgeHead.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedDesertScourge", NohitUtils.AllBindingFlags), 1.5f, 0.8f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/Crabulon/Crabulon_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.Crabulon.DisplayName").ToString(),
                typeof(DownedBossSystem).GetField("_downedCrabulon", NohitUtils.AllBindingFlags), 2.5f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/HiveMind/HiveMind_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.HiveMind.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedHiveMind", NohitUtils.AllBindingFlags), 4.4f, 0.8f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/Perforator/PerforatorHive_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.PerforatorHive.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedPerforator", NohitUtils.AllBindingFlags), 4.6f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/SlimeGod/SlimeGodCore_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.SlimeGodCore.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedSlimeGod", NohitUtils.AllBindingFlags), 7.5f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/Cryogen/Cryogen_Phase1_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.Cryogen.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedCryogen", NohitUtils.AllBindingFlags), 9.5f, 0.9f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/BrimstoneElemental/BrimstoneElemental_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.BrimstoneElemental.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedBrimstoneElemental", NohitUtils.AllBindingFlags), 10.5f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/AquaticScourge/AquaticScourgeHead_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.AquaticScourgeHead.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedAquaticScourge", NohitUtils.AllBindingFlags), 11.5f, 0.9f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/CalClone/CalamitasClone_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.CalamitasClone.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedCalamitasClone", NohitUtils.AllBindingFlags), 13.3f, 0.9f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/Leviathan/Leviathan_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.Items.Lore.LoreLeviathanAnahita.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedLeviathan", NohitUtils.AllBindingFlags), 13.5f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/AstrumAureus/AstrumAureus_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.AstrumAureus.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedAstrumAureus", NohitUtils.AllBindingFlags), 13.8f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/PlaguebringerGoliath/PlaguebringerGoliath_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.PlaguebringerGoliath.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedPlaguebringer", NohitUtils.AllBindingFlags), 14.5f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/Ravager/RavagerBody_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.RavagerBody.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedRavager", NohitUtils.AllBindingFlags), 16.5f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/AstrumDeus/AstrumDeusHead_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.AstrumDeusHead.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedAstrumDeus", NohitUtils.AllBindingFlags), 17.5f, 0.9f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/ProfanedGuardians/ProfanedGuardianCommander_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.BossChecklistIntegration.ProfanedGuardians.EntryName"),
                typeof(DownedBossSystem).GetField("_downedGuardians", NohitUtils.AllBindingFlags), 19f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/Bumblebirb/Birb_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.Bumblefuck.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedDragonfolly", NohitUtils.AllBindingFlags), 20f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/Providence/Providence_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.Providence.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedProvidence", NohitUtils.AllBindingFlags), 21f, 0.8f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/CeaselessVoid/CeaselessVoid_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.CeaselessVoid.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedCeaselessVoid", NohitUtils.AllBindingFlags), 22f, 0.8f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/StormWeaver/StormWeaverHead_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.StormWeaverHead.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedStormWeaver", NohitUtils.AllBindingFlags), 23f, 0.8f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/Signus/Signus_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.Signus.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedSignus", NohitUtils.AllBindingFlags), 24f, 0.8f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/Polterghast/Polterghast_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.Polterghast.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedPolterghast", NohitUtils.AllBindingFlags), 25f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/OldDuke/OldDuke_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.OldDuke.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedBoomerDuke", NohitUtils.AllBindingFlags), 26f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/DevourerofGods/DevourerofGodsHead_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.DevourerofGodsHead.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedDoG", NohitUtils.AllBindingFlags), 27f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/Yharon/Yharon_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.Yharon.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedYharon", NohitUtils.AllBindingFlags), 28f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/ExoMechs/Ares/AresBody_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.BossChecklistIntegration.ExoMechs.EntryName"),
                typeof(DownedBossSystem).GetField("_downedExoMechs", NohitUtils.AllBindingFlags), 29f, 0.7f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/SupremeCalamitas/HoodedHeadIcon", Language.GetTextValue($"Mods.CalamityMod.NPCs.SupremeCalamitas.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedCalamitas", NohitUtils.AllBindingFlags), 30f).Register();

            new BossToggleElement(true, "CalamityMod/NPCs/PrimordialWyrm/PrimordialWyrmHead_Head_Boss", Language.GetTextValue($"Mods.CalamityMod.NPCs.PrimordialWyrmHead.DisplayName"),
                typeof(DownedBossSystem).GetField("_downedPrimordialWyrm", NohitUtils.AllBindingFlags), 31f).Register();
        }
    }
}
