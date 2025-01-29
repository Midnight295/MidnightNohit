using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace MidnightNohit.Core
{
    public static class ModCompatability
    {
        public static class Calamity
        {
            // Please use this to avoid typo bugs
            public const string Name = "CalamityMod";

            // TODO: cache, lazy property
            public static bool Loaded => ModLoader.HasMod(Name);

            public static Mod Mod => ModLoader.GetMod(Name);
        }
    }
}
