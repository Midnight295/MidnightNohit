using CalamityMod.Buffs.DamageOverTime;
using MidnightNohit.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;
using CalamityMod.Buffs.StatBuffs;
using CalamityMod;
using Terraria;
using CalamityMod.CalPlayer;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using CalamityMod.Buffs.Mounts;
using System.Security.Cryptography.X509Certificates;
using CalamityMod.UI.Rippers;
using Terraria.Graphics.Effects;
using ReLogic.Content;

namespace MidnightNohit.Core.ModPlayers
{
    [JITWhenModsEnabled(ModCompatability.Calamity.Name)]
    [ExtendsFromMod(ModCompatability.Calamity.Name)]
    public class CalNohitPlayer : ModPlayer
    {
        public override void PreUpdate()
        {
            if (NohitConfig.Instance.debuffs == Debuffs.Specific)
            {
                if (Player.FindBuffIndex(ModContent.BuffType<HolyInferno>()) > -1)
                    Player.KillMe(PlayerDeathReason.ByCustomReason(Player.name + Language.GetTextValue($"Mods.MidnightNohit.DeathMessages.HInferno" + Main.rand.Next(1, 3))), 1000.0, 0, false);
                

                if (Player.FindBuffIndex(ModContent.BuffType<VulnerabilityHex>()) > -1)
                    Player.KillMe(PlayerDeathReason.ByCustomReason(Player.name + Language.GetTextValue($"Mods.MidnightNohit.DeathMessages.VHex" + Main.rand.Next(1, 3))), 1000.0, 0, false);

                if (ModLoader.TryGetMod("InfernumMode", out Mod InfernumMode))
                {
                    InfernumMode.TryFind("Madness", out ModBuff Madness);
                    if (Player.FindBuffIndex(Madness.Type) > -1)
                        Player.KillMe(PlayerDeathReason.ByCustomReason(Player.name + Language.GetTextValue($"Mods.MidnightNohit.DeathMessages.Madness" + Main.rand.Next(1, 3))), 1000.0, 0, false);
                }
            }

            if (CalNohitConfig.Instance.DisableRippers)
            {
                Player.Calamity().adrenaline -= 1;
                Player.Calamity().rage -= 1;
                typeof(RipperUI).GetField("adrenBorderTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("MidnightNohit/Assets/MiscUI/LockedAdrenaline", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("electrolyteGelTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("MidnightNohit/Assets/MiscUI/InvisiblePixel", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("starlightFuelTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("MidnightNohit/Assets/MiscUI/InvisiblePixel", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("ectoheartTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("MidnightNohit/Assets/MiscUI/InvisiblePixel", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("rageBorderTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("MidnightNohit/Assets/MiscUI/LockedRage", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("mushroomPlasmaTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("MidnightNohit/Assets/MiscUI/InvisiblePixel", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("infernalBloodTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("MidnightNohit/Assets/MiscUI/InvisiblePixel", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("redLightningTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("MidnightNohit/Assets/MiscUI/InvisiblePixel", AssetRequestMode.ImmediateLoad).Value);
            }
            else
            {
                typeof(RipperUI).GetField("adrenBorderTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("CalamityMod/UI/Rippers/AdrenalineBarBorder", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("electrolyteGelTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("CalamityMod/UI/Rippers/AdrenalineDisplay_ElectrolyteGelPack", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("starlightFuelTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("CalamityMod/UI/Rippers/AdrenalineDisplay_StarlightFuelCell", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("ectoheartTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("CalamityMod/UI/Rippers/AdrenalineDisplay_Ectoheart", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("rageBorderTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("CalamityMod/UI/Rippers/RageBarBorder", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("mushroomPlasmaTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("CalamityMod/UI/Rippers/RageDisplay_MushroomPlasmaRoot", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("infernalBloodTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("CalamityMod/UI/Rippers/RageDisplay_InfernalBlood", AssetRequestMode.ImmediateLoad).Value);
                typeof(RipperUI).GetField("redLightningTex", NohitUtils.AllBindingFlags).SetValue(null, ModContent.Request<Texture2D>("CalamityMod/UI/Rippers/RageDisplay_RedLightningContainer", AssetRequestMode.ImmediateLoad).Value);
            }

            if (NohitConfig.Instance.InstantKill)
            {
                Player.buffImmune[ModContent.BuffType<TarragonImmunity>()] = true;
                Player.buffImmune[ModContent.BuffType<SilvaRevival>()] = true;
                Player.Calamity().SpongeShieldDurability = 0;
                Player.Calamity().tarragonImmunity = false;
                Player.Calamity().hasSilvaEffect = false;
                Player.Calamity().disableAllDodges = true;
               
            }

            /*if (NohitConfig.Instance.defiled == Defiled.True)
            {
                Player.buffImmune[ModContent.BuffType<MarniteLiftBuff>()] = true;
                Player.buffImmune[ModContent.BuffType<BrimroseMount>()] = true;
                Player.buffImmune[ModContent.BuffType<BumbledogeMount>()] = true;
                Player.buffImmune[ModContent.BuffType<GazeOfCrysthamyrBuff>()] = true;
                Player.buffImmune[ModContent.BuffType<DraedonGamerChairBuff>()] = true; //fuck off.
            }*/

        }       
    }
}
