using Terraria;
using Terraria.ID;


namespace MidnightNohit.Core
{
    public static partial class NohitUtils
    {
        public static int MainTimer;
        public static int Seconds;
        public static int Minutes;
        public static string DeadSpace;
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
    }
}
