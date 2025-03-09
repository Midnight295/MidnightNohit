using Microsoft.Xna.Framework;
using MidnightNohit.Content.UI;
using System;
using System.Reflection;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;


namespace MidnightNohit.Core
{
    public static partial class NohitUtils
    {   
        public static readonly BindingFlags AllBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
        public static int MainTimer;
        public static int Seconds;
        public static int Minutes;
        public static string DeadSpace;
        // Ported from Imogen QoL, with permission from it's creator.
        public static Vector2 ScreenCenter => new(Main.screenWidth * 0.5f, Main.screenHeight * 0.5f);

        public static Rectangle MouseRectangle => new(Main.mouseX, Main.mouseY, 2, 2);

        public static bool CanAndHasClickedUIElement => (Main.mouseLeft && Main.mouseLeftRelease || Main.mouseRight && Main.mouseRightRelease) && TogglesUIManager.ClickCooldownTimer == 0;

        public static float EaseInOutSine(float value) => -(MathF.Cos(MathF.PI * value) - 1) / 2;

        public static float EaseInCirc(float value) => 1 - MathF.Sqrt(1 - MathF.Pow(value, 2));
        //
        public static void SwitchItem(this Player player, Item itemToReplace, int itemIDtoReplaceWith)
        {
            bool foundSlot = false;
            for (int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i] == itemToReplace)
                {
                    Item newItem = new(itemIDtoReplaceWith, itemToReplace.stack, itemToReplace.prefix);
                    newItem.active = true;
                    newItem.favorited = itemToReplace.favorited;
                    player.inventory[i] = newItem;
                    itemToReplace.active = false;
                    foundSlot = true;
                    break;
                }
            }
            if (!foundSlot) //didn't find item in normal inventory, drop instead
            {
                Item.NewItem(player.GetSource_ItemUse(itemToReplace), player.Center, itemIDtoReplaceWith, prefixGiven: itemToReplace.prefix);
            }
        }
        public static bool IsAnyBossesAlive()
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].active && (Main.npc[i].boss || Main.npc[i].type == NPCID.EaterofWorldsHead || Main.npc[i].type == NPCID.EaterofWorldsBody || Main.npc[i].type == NPCID.EaterofWorldsTail))
                {
                    return true;
                }
            }
            return false;           
        }

        public static void MNLTimer()
        {
            if (!IsAnyBossesAlive())
            {
                MainTimer = 0;
                --MainTimer;
                Seconds = 0;
                Minutes = 0;
                return;
            }

            if (++MainTimer >= 60)
            {
                Seconds += 1;
                MainTimer = 0;
            }

            if (Seconds < 10)
                DeadSpace = "0";
            else
                DeadSpace = ""; 

            if (Seconds >= 60)
            {
                Seconds = 0;
                Minutes += 1;
            }

        }

        //Ported from Imogen QoL, with permission from it's creator.
        public static void DisplayText(string text, Color? color = null)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
                Main.NewText(text, color ?? Color.White);
            else if (Main.netMode == NetmodeID.Server)
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), color ?? Color.White);
        }
    }
}
