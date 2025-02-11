﻿using MidnightNohit.Config;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;


namespace MidnightNohit.Core.ModPlayers
{
    public class NohitPlayer : ModPlayer
    {
        public override void PreUpdate()
        {

            Player player = Main.LocalPlayer;
            if (NohitConfig.Instance.DisableIframes)
            {
                //player.immune = false;
                player.immuneTime = 0;
                player.eocHit = 0;
                player.eocDash = 0;
                player.hurtCooldowns[0] = 0;
                player.hurtCooldowns[1] = 0;             
            }

            if (NohitConfig.Instance.debuffs == Debuffs.All)
            {
                if (player.lifeRegen < 0)
                {
                    Player.KillMe(PlayerDeathReason.ByCustomReason(Language.GetTextValue($"Mods.MidnightNohit.DeathMessages.NegativeRegen", Player.name)), 1000, 0, false);
                }
            }

            if (NohitUtils.IsAnyBossesAlive())
            {
                NohitUtils.MNLTimer();
            }
            else
            {
                --NohitUtils.MainTimer;
                NohitUtils.MainTimer = 0;
                NohitUtils.Minutes = 0;
                NohitUtils.Seconds = 0;             
            }
                

            /*Player player = Main.LocalPlayer;
            if (NohitConfig.Instance.defiled == Defiled.Normal)
            {
                NoWings();
            }

            if (NohitConfig.Instance.defiled == Defiled.True)
            {
                player.wings = 0;
                player.rocketBoots = 0;
                Player.buffImmune[BuffID.BeeMount] = true;
                Player.buffImmune[BuffID.QueenSlimeMount] = true;
                Player.buffImmune[BuffID.PigronMount] = true;
                Player.buffImmune[BuffID.Rudolph] = true;
                Player.buffImmune[BuffID.UFOMount] = true;
                Player.buffImmune[BuffID.WitchBroom] = true;
                Player.buffImmune[BuffID.CuteFishronMount] = true;
                Player.buffImmune[BuffID.PirateShipMount] = true;
                Player.buffImmune[BuffID.DrillMount] = true;
                Player.buffImmune[BuffID.DarkMageBookMount] = true;
                //Player.buffImmune[BuffID.
            }*/
        }

        public override void UpdateDead()
        {
            lastbosstype = 0;
            base.UpdateDead();
        }

        public override void OnRespawn()
        {
            base.OnRespawn();
        }

        /*private void NoWings()
        {
            Main.LocalPlayer.wingTime = 0;
        }*/

        public override void OnHitByNPC(NPC npc, Player.HurtInfo hurtInfo)
        {
            if (NohitConfig.Instance.InstantKill)
            {
                string messagetouse = "" + Main.rand.Next(1, 10);
                if (Main.LocalPlayer.wingsLogic > 0 && Main.LocalPlayer.wingTime == 0)
                {
                    messagetouse = "NoWingTime";
                }
                Player.KillMe(PlayerDeathReason.ByCustomReason(Language.GetTextValue($"Mods.MidnightNohit.DeathMessages.InstantKill." + messagetouse, npc.FullName, Player.name)), 1000, 0, false);
            }
            
        }

        public override void OnHitByProjectile(Projectile proj, Player.HurtInfo hurtInfo)
        {
            if (NohitConfig.Instance.InstantKill)
            {
                string messagetouse = "" + Main.rand.Next(1, 10);
                if (Main.LocalPlayer.wingsLogic > 0 && Main.LocalPlayer.wingTime == 0)
                {
                    messagetouse = "NoWingTime";
                }
                Player.KillMe(PlayerDeathReason.ByCustomReason(Language.GetTextValue($"Mods.MidnightNohit.DeathMessages.InstantKill." + messagetouse, proj.Name, Player.name)), 1000, 0, false);
            };
        }
    }
}
