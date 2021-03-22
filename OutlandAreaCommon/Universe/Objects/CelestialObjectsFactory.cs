using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Repository.Hierarchy;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe.Objects.Spaceships.NPC;

namespace OutlandAreaCommon.Universe.Objects
{
    public class CelestialObjectsFactory
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        

        public static ICelestialObject GenerateAsteroid(GameSession gameSession)
        {
            Logger.Debug($"[CelestialObjectsFactory][GenerateAsteroid] Start generate.");

            var spaceship = gameSession.GetPlayerSpaceShip().ToSpaceship();

            ICelestialObject newCelestialObject = new Asteroid
            {
                Id = RandomGenerator.GetId(),
                PositionX = spaceship.PositionX + 500 + RandomGenerator.GetInteger(1, 200),
                PositionY = spaceship.PositionY + 500 + RandomGenerator.GetInteger(1, 200),
                Name = RandomGenerator.GenerateCelestialObjectName(),
                Direction = RandomGenerator.Direction(),
                Speed = RandomGenerator.GetInteger(1, 30),
                Classification = CelestialObjectTypes.Asteroid.ToInt(),
                IsScanned = false,
                Signature = 210
            };


            return newCelestialObject;
        }

        public static ICelestialObject GenerateNpcShip(GameSession gameSession, int spaceShipClass, int spaceShipType, int standing)
        {
            Logger.Debug($"[CelestialObjectsFactory][GenerateNpcShip] Start generate.");

            var spaceship = gameSession.GetPlayerSpaceShip().ToSpaceship();

            ICelestialObject newCelestialObject = Fury.Generate(gameSession);

            return newCelestialObject;
        }
    }
}
