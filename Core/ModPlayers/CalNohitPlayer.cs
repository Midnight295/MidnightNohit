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
                    Player.KillMe(PlayerDeathReason.ByCustomReason(Player.name + Language.GetTextValue($"Mods.MidnightNohit.DeathMessages.HInferno" + Main.rand.Next(1, 3)), 1000.0, 0, false);
                

                if (Player.FindBuffIndex(ModContent.BuffType<VulnerabilityHex>()) > -1)
                    Player.KillMe(PlayerDeathReason.ByCustomReason(Player.name + Language.GetTextValue($"Mods.MidnightNohit.DeathMessages.VHex")), 1000.0, 0, false);

                if (ModLoader.TryGetMod("InfernumMode", out Mod InfernumMode))
                {
                    InfernumMode.TryFind("Madness", out ModBuff Madness);
                    if (Player.FindBuffIndex(Madness.Type) > -1)
                        Player.KillMe(PlayerDeathReason.ByCustomReason(Player.name + Language.GetTextValue($"Mods.MidnightNohit.DeathMessages.Madness")), 1000.0, 0, false);
                }

                Player.buffImmune[ModContent.BuffType<TarragonImmunity>()] = true;
                Player.buffImmune[ModContent.BuffType<SilvaRevival>()] = true;
                Player.Calamity().tarragonImmunity = false;
                Player.Calamity().hasSilvaEffect = false;
            }

            if (CalNohitConfig.Instance.DisableRippers)
            {
                Player.Calamity().adrenaline -= 1;
                Player.Calamity().rage -= 1;              
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
