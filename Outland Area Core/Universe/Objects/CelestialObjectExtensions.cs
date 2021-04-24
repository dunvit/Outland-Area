using System.Drawing;
using EngineCore.Universe.Equipment.Ammunition.Missiles;
using EngineCore.Universe.Model;

namespace EngineCore.Universe.Objects
{
    public static class CelestialObjectExtensions
    {
        public static PointF GetLocation(this ICelestialObject celestialObject)
        {
            return new PointF(celestialObject.PositionX, celestialObject.PositionY);
        }

        public static bool IsSpaceship(this ICelestialObject celestialObject)
        {
            if (celestialObject == null) return false;

            return celestialObject.Classification >= 200 && celestialObject.Classification < 299;
        }

        public static IMissile ToMissile(this ICelestialObject celestialObject)
        {
            return (IMissile)celestialObject;
        }

        public static Explosion ToExplosion(this ICelestialObject celestialObject)
        {
            return (Explosion)celestialObject;
        }

        public static Spaceship ToSpaceship(this ICelestialObject celestialObject)
        {
            return (Spaceship)celestialObject;
        }
    }
}
