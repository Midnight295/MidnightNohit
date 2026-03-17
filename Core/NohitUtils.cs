using Microsoft.Xna.Framework;
using MidnightNohit.Content.UI;
using System;
using System.Diagnostics;
using System.Reflection;
using Terraria;


namespace MidnightNohit.Core;

public static partial class NohitUtils
{   
    public static readonly BindingFlags AllBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
    public static int MainTimer;
    public static int Seconds;
    public static int Minutes;
    public static string DeadSpace;      
    public static Rectangle MouseRectangle => new(Main.mouseX, Main.mouseY, 2, 2);

    public static bool CanAndHasClickedUIElement => (Main.mouseLeft && Main.mouseLeftRelease || Main.mouseRight && Main.mouseRightRelease) && TogglesUIManager.ClickCooldownTimer == 0;

    public static float EaseInOutSine(float value) => -(MathF.Cos(MathF.PI * value) - 1) / 2;

    public static float EaseInCirc(float value) => 1 - MathF.Sqrt(1 - MathF.Pow(value, 2));
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

    public static Stopwatch MNLTimer = new();
}
