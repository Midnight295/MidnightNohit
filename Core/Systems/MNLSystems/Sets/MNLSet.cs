using System;
using System.Collections.Generic;

namespace MidnightNohit.Core.Systems.MNLSystems.Sets
{
    //Ported from Imogen QoL, with permission from it's creator.
    public class MNLSet
    {
        public readonly Dictionary<int, int> AssosiatedIDsAndFightLength;

        public readonly Func<float> Weight;

        public MNLSet(Dictionary<int, int> assosiatedIDsAndFightLength, Func<float> weight)
        {
            AssosiatedIDsAndFightLength = assosiatedIDsAndFightLength;
            Weight = weight;
        }
    }
}
