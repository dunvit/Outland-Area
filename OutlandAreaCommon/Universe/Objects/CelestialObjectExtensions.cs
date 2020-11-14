using System.Drawing;

namespace OutlandAreaCommon.Universe.Objects
{
    public static class CelestialObjectExtensions
    {
        public static Point GetLocation(this ICelestialObject celestialObject)
        {
            return new Point(celestialObject.PositionX, celestialObject.PositionY);
        }

    }
}
