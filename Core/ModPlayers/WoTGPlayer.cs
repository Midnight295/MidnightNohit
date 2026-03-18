
using MidnightNohit.Config;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;
using NoxusBoss.Content.Buffs;

namespace MidnightNohit.Core.ModPlayers;

[JITWhenModsEnabled(ModCompatability.WrathoftheGods.Name)]
[ExtendsFromMod(ModCompatability.WrathoftheGods.Name)]
public class WoTGPlayer : ModPlayer
{
    public override void PreUpdate()
    {
        if (NohitConfig.Instance.debuffs == Debuffs.Specific && !NohitConfig.Instance.PracticeMode)
        {
            if (Player.FindBuffIndex(ModContent.BuffType<AntimatterAnnihilation>()) > -1)
                Player.KillMe(PlayerDeathReason.ByCustomReason(Player.name + Language.GetTextValue($"Mods.MidnightNohit.DeathMessages.AvatarAntiMatter" + Main.rand.Next(1, 3))), 1000.0, 0, false);
        }
    }
}
