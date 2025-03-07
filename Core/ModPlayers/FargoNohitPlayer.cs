using FargowiltasSouls.Content.Buffs.Boss;
using FargowiltasSouls.Content.Buffs.Masomode;
using MidnightNohit.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MidnightNohit.Core.ModPlayers
{
    [JITWhenModsEnabled(ModCompatability.FargoSouls.Name)]
    [ExtendsFromMod(ModCompatability.FargoSouls.Name)]
    public class FargoNohitPlayer : ModPlayer
    {
        public override void PreUpdate()
        {
            if (NohitConfig.Instance.debuffs == Debuffs.Specific)
            {
                if (Player.FindBuffIndex(ModContent.BuffType<BaronsBurdenBuff>()) > -1 && !Main.LocalPlayer.wet)
                    Player.KillMe(PlayerDeathReason.ByCustomReason(Player.name + Language.GetTextValue($"Mods.MidnightNohit.DeathMessages.Baron" + Main.rand.Next(1, 3))), 1000.0, 0, false);

                if (Player.FindBuffIndex(ModContent.BuffType<GodEaterBuff>()) > -1)
                    Player.KillMe(PlayerDeathReason.ByCustomReason(Player.name + Language.GetTextValue($"Mods.MidnightNohit.DeathMessages.GodEater" + Main.rand.Next(1, 3))), 1000.0, 0, false);
            }
        }
    }
}
