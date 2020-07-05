using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandArea.TacticalBattleLayer.Commands
{
    class Navigation: ICommand
    {
        public string Description { get; }
        public int TimePointCost { get; }
        public int SuccessChance { get; }

        public Navigation(string description, int timePointCost, int successChance)
        {
            TimePointCost = timePointCost;
            Description = description;
            SuccessChance = successChance;
        }
    }
}
