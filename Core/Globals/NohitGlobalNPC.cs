using MidnightNohit.Core.Systems.MNLSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MidnightNohit.Core.Globals
{
    public class NohitGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void OnKill(NPC npc)
        {
            MNLsHandler.NPCKillChecks(npc);
        }
    }
}
