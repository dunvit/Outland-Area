using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandArea.TacticalBattleLayer
{
    public class BaseSpacecraft
    {
        public long Id { get; set; } = DateTime.UtcNow.Ticks;
        public bool IsPlayerSpacecraft { get; set; } = false;
    }
}
