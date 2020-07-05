using System;
using System.Drawing;

namespace OutlandArea.TacticalBattleLayer
{
    public class BaseSpacecraft
    {
        public long Id { get; set; } = DateTime.UtcNow.Ticks;
        public bool IsPlayerSpacecraft { get; set; } = false;

        
    }
}
