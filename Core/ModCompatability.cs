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
            public const string Name = "CalamityMod";
            public static bool Loaded => ModLoader.HasMod(Name);

            public static Mod Mod => ModLoader.GetMod(Name);
        }

        public static class FargoSouls
        {
            public const string Name = "FargowiltasSouls";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod = ModLoader.GetMod(Name);
        }

        public static class Infernum
        {
            public const string Name = "InfernumMode";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod => ModLoader.GetMod(Name);
            public static bool InfernumDifficulty => Loaded && (bool)Mod.Call("GetInfernumActive");
        }

        public static class WrathoftheGods
        {
            public const string Name = "NoxusBoss";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod => ModLoader.GetMod(Name);
        }
    }
}
