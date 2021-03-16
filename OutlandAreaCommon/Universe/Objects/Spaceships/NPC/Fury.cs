using OutlandAreaCommon.Common;
using OutlandAreaCommon.Tactical;

namespace OutlandAreaCommon.Universe.Objects.Spaceships.NPC
{
    public class Fury 
    {
        public static Spaceship Generate(GameSession gameSession)
        {
            var spaceship = gameSession.GetPlayerSpaceShip().ToSpaceship();

            var spaceShip = new Spaceship
            {
                Id = RandomGenerator.GetId(), 
                Name = "Fury - A" + RandomGenerator.RandomString(6), 
                MaxSpeed = 6,
                Speed = 6,
                PositionX = spaceship.PositionX + 500 + RandomGenerator.GetInteger(1, 200),
                PositionY = spaceship.PositionY + 500 + RandomGenerator.GetInteger(1, 200),
                Direction = RandomGenerator.Direction(),
                Classification = CelestialObjectTypes.SpaceshipNpcEnemy.ToInt(),
                IsScanned = false,
                Signature = 12
            };

            return spaceShip;
        }
    }
}
