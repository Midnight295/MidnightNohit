using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MidnightNohit.Config;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static MidnightNohit.Core.Systems.TieringSystems.TieringSystem;


namespace MidnightNohit.Core.Globals
{
    public class TieringGlobalItem : GlobalItem
    {
        public TooltipLine CreateProgressionTooltip(int itemType, BossLockInformation bossLockInformation)
        {
            string text = Language.GetTextValue($"Mods.MidnightNohit.UI.Tiering.ProgressionInformation", bossLockInformation.BossName);
            return new TooltipLine(Mod, $"ItemLock{itemType}", text);
        }

        public override bool InstancePerEntity => true;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (NohitConfig.Instance.ItemLocks)
                if (ItemShouldBeMarked(item.type, out var lockInformation))
                    tooltips.Add(CreateProgressionTooltip(item.type, lockInformation));

            if (NohitConfig.Instance.PotionLocks)
                if (PotionShouldBeMarked(item.type, out var lockInformation))
                    tooltips.Add(CreateProgressionTooltip(item.type, lockInformation));
        }

        public override bool CanUseItem(Item item, Player player) => LockItemOrPotionFromUse(item.type);

        public override bool CanEquipAccessory(Item item, Player player, int slot, bool modded)
        {
            if (NohitConfig.Instance.ItemLocks)
                return !ItemShouldBeMarked(item.type, out var _);

            return true;
        }
        public override void PostDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {   
            Texture2D locksprite = ModContent.Request<Texture2D>("MidnightNohit/Assets/MiscUI/ItemLock").Value;
            if (NohitConfig.Instance.ItemLocks)
                if (ItemShouldBeMarked(item.type, out var lockInformation) || PotionShouldBeMarked(item.type, out var lockinformation))
                    spriteBatch.Draw(locksprite, position + new Vector2(-12, -15), Color.White with { A = 225});
            base.PostDrawInInventory(item, spriteBatch, position, frame, drawColor, itemColor, origin, scale);
        }
    }
}
