using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using MidnightNohit.Core;
using Terraria.GameContent;
using Terraria;
using Terraria.ID;
using MidnightNohit.Core.MNLSystems.Sets;

namespace MidnightNohit.Core.MNLSystems
{   
    public class MNLSystem : ModSystem
    {
        public static List<MNLSet> MNLSets
        {
            get;
            private set;
        } = new();

        public static Dictionary<int, int> ActiveSet
        {
            get
            {
                return MNLSets.OrderBy(s => s.Weight()).Last().IDAndLength;
            }

        }

        public static IEnumerable<NPC> GetMNLs()
        {
            static bool Bosses(NPC n) => (n.boss || n.type == NPCID.EaterofWorldsHead || n.type == NPCID.EaterofWorldsBody || n.type == NPCID.EaterofWorldsTail) && n.active && ActiveSet.ContainsKey(n.type);

            if (Main.npc.Any(Bosses))
                return Main.npc.Where(Bosses);

            return null;
        }

        public override void Load()
        {
            if (ModCompatability.Calamity.Loaded)
            {
                RevSet.Load();
                DeathSet.Load();
            }

            if (ModCompatability.Infernum.InfernumDifficulty)
            {
                InfSet.Load();
            }

            if (ModCompatability.FargoSouls.Loaded)
            {
                FargoSet.Load();
            }

        }
        
        public override void Unload()
        {
            MNLSets = null;
        }

        public static void RegisterSet(MNLSet set) => MNLSets.Add(set);
    }

    public class MNLSet
    {
        public readonly Dictionary<int, int> IDAndLength;
        public readonly Func<float> Weight;

        public MNLSet(Dictionary<int, int> IDandlength, Func<float> weight)
        {
            IDAndLength = IDandlength;
            Weight = weight;
        }
    }

    public class MNLWeight
    {
        public const float None = 0;
        public const float Rev = 1f;
        public const float Death = 2f;
        public const float Infernum = 3f;
        public const float Eternity = 4f;
    }
}
