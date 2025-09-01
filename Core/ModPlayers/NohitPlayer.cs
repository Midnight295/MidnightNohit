using MidnightNohit.Config;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;
using MidnightNohit.Core.Systems.MNLSystems;
using MidnightNohit.Content.UI.PotionUI;
using MidnightNohit.Content.UI;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;
using MidnightNohit.Core.Systems;


namespace MidnightNohit.Core.ModPlayers
{
    public class NohitPlayer : ModPlayer
    {
        public override void PreUpdate()
        {
            if (!Main.showFrameRate)
                Main.showFrameRate = true;


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
            if (GMHitCooldownTimer > 0)
                GMHitCooldownTimer--;
            if (PotionUICooldownTimer > 0)
                PotionUICooldownTimer--;
            if (ToggleUICooldownTimer > 0)
                ToggleUICooldownTimer--;
            if (TogglesUIManager.ClickCooldownTimer > 0)
                TogglesUIManager.ClickCooldownTimer--;

            TogglesUIManager.Update();
        }

        /*private void NoWings()
        {
            Main.LocalPlayer.wingTime = 0;
        }*/

        public override void OnHitByNPC(NPC npc, Player.HurtInfo hurtInfo)
        {
            if (NohitConfig.Instance.InstantKill)
            {
                string messagetouse = "" + Main.rand.Next(1, 13);
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
                string messagetouse = "" + Main.rand.Next(1, 13);
                if (Main.LocalPlayer.wingsLogic > 0 && Main.LocalPlayer.wingTime == 0)
                {
                    messagetouse = "NoWingTime";
                }
                Player.KillMe(PlayerDeathReason.ByCustomReason(Language.GetTextValue($"Mods.MidnightNohit.DeathMessages.InstantKill." + messagetouse, proj.Name, Player.name)), 1000, 0, false);
            };
        }

        public override void OnRespawn()
        {
            if (Player.whoAmI == Main.myPlayer)
                MNLsHandler.PlayerRespawnChecks();
        }

        public static int ToggleUICooldownTimer { get; internal set; }

        public static int PotionUICooldownTimer { get; internal set; }

        public const int UICooldownTimerLength = 10;

        internal static int GMHitCooldownTimer = 0;

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (UIModSystem.OpenTogglesUI.JustPressed)
            {
                if (PotionUIManager.IsDrawing == true)
                {
                    TogglesUIManager.CloseUI(true);
                    ToggleUICooldownTimer = UICooldownTimerLength;
                    PotionUICooldownTimer = UICooldownTimerLength;
                }
                else if (ToggleUICooldownTimer == 0)
                {
                    if (TogglesUIManager.UIOpen)
                        TogglesUIManager.CloseUI(true);
                    else
                        TogglesUIManager.OpenUI(true);
                }

            }

            if (UIModSystem.OpenPotionsUI.JustPressed)
            {
                if (PotionUIManager.IsDrawing && PotionUICooldownTimer == 0)
                {
                    SoundEngine.PlaySound(SoundID.MenuClose, Main.LocalPlayer.Center);
                    PotionUIManager.IsDrawing = false;
                    PotionUICooldownTimer = UICooldownTimerLength;
                }
                else if (PotionUICooldownTimer == 0)
                {
                    SoundEngine.PlaySound(SoundID.MenuOpen, Main.LocalPlayer.Center);
                    PotionUIManager.IsDrawing = true;
                    PotionUICooldownTimer = UICooldownTimerLength;
                }

            }
        }

    }
}
