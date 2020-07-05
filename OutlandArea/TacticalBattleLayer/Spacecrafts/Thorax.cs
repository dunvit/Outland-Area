using System.Drawing;

namespace OutlandArea.TacticalBattleLayer.Spacecrafts
{
    public class Thorax : BaseSpacecraft, ISpacecraft, ICelestialObject
    {
        public string Name { get; set; }
        public int Direction { get; set; }
        public int Signature { get; set; } = 120;
        public int Velocity { get; set; }
        public Point Location { get; set; }
        public string ImageSmall { get; set; } = "Thorax.jpg";
        public Point LocationInLastTurn { get; set; }
    }
}
