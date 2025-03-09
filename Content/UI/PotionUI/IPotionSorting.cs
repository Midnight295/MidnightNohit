using System.Collections.Generic;

namespace MidnightNohit.Content.UI.PotionUI
{
    public interface IPotionSorting
    {
        public string Name { get; }

        public List<PotionElement> SortPotions(ref List<PotionElement> potions);
    }
}
