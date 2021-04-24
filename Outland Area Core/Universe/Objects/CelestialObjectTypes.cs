
namespace EngineCore.Universe.Objects
{
    public enum CelestialObjectTypes
    {
        None = -1000,
        PointInMap = -1,
        Missile = 300,
        SpaceshipPlayer = 200,
        SpaceshipNpcNeutral = 201,
        SpaceshipNpcEnemy = 202,
        SpaceshipNpcFriend = 203,
        Asteroid = 1,
        Explosion = 800,
        ScanProbe = 600
    }

    public static class CelestialObjectTypesExtensions
    {
        public static int ToInt(this CelestialObjectTypes command)
        {
            return (int)command;
        }
    }
}
