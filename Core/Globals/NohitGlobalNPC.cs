using MidnightNohit.Core.Systems.MNLSystems;
using MidnightNohit.Core.Systems.TieringSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MidnightNohit.Core.Globals
{
    public class NohitGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void OnKill(NPC npc)
        {
            switch (npc.type)
            {
                case NPCID.BrainofCthulhu:
                    TieringSystem.DownedBrain = true;
                    break;
                case NPCID.EaterofWorldsHead:
                    if (npc.boss == true)
                        TieringSystem.DownedEater = true;
                    break;
            }
            MNLsHandler.NPCKillChecks(npc);
        }
    }
}
