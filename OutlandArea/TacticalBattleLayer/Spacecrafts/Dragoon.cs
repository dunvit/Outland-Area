using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandArea.TacticalBattleLayer.Spacecrafts
{
    public class Dragoon : BaseSpacecraft, ISpacecraft, ICelestialObject
    {
        public string Name { get; set; }
        public int Direction { get; set; }
        public int Signature { get; set; } = 66;
        public int Velocity { get; set; }
        public Point Location { get; set; }
        public string ImageSmall { get; set; } = "Dragoon.jpg";

        public Point LocationInLastTurn { get; set; }
    }
}
