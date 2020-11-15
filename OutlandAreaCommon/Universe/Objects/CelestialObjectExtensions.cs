using System.Drawing;

namespace OutlandAreaCommon.Universe.Objects
{
    public static class CelestialObjectExtensions
    {
        public static PointF GetLocation(this ICelestialObject celestialObject)
        {
            return new PointF(celestialObject.PositionX, celestialObject.PositionY);
        }

    }
}
