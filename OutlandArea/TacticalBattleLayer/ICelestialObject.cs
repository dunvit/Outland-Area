using System.Drawing;

namespace OutlandArea.TacticalBattleLayer
{
    public interface ICelestialObject
    {
        long Id { get; set; }
        string Name { get; set; }
        int Direction { get; set; }
        int Signature { get; set; }
        int Velocity { get; set; }
        Point Location { get; set; }
        string ImageSmall { get; set; }
    }
}
