using OutlandAreaCommon.Common;
using OutlandAreaCommon.Tactical;

namespace OutlandAreaCommon.Universe.Objects.Spaceships.NPC
{
    public class Fury 
    {
        public static Spaceship Generate()
        {
            var spaceShip = new Spaceship
            {
                Id = RandomGenerator.GetId(), 
                Name = "Fury - A" + RandomGenerator.RandomString(6), 
                MaxSpeed = 6,
                Speed = 6,
                Classification = CelestialObjectTypes.SpaceshipNpcEnemy.ToInt(),
                IsScanned = false,
                Signature = 12
            };

            return spaceShip;
        }
    }
}
