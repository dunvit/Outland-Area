using System;
using EngineCore.Geometry;
using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects.Spaceships;

namespace EngineCore.Universe.Objects
{
    public class CelestialObjectsFactory
    {
        public static ICelestialObject GenerateAsteroid(GameSession gameSession)
        {
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
            var spaceship = gameSession.GetPlayerSpaceShip().ToSpaceship();

            Spaceship newCelestialObject = null;

            switch (spaceShipType)
            {
                case 12:
                    newCelestialObject = Fury.Generate();
                    break;
                default:
                    break;
            }

            if (newCelestialObject != null)
            {
                newCelestialObject.PositionX = spaceship.PositionX + Math.Abs(500 + RandomGenerator.GetInteger(-20, 20));
                newCelestialObject.PositionY = spaceship.PositionY + Math.Abs(500 + RandomGenerator.GetInteger(-20, 20));
                newCelestialObject.Speed = newCelestialObject.MaxSpeed;

                newCelestialObject.Direction = GeometryTools.Azimuth(spaceship.GetLocation(), newCelestialObject.GetLocation());
            }

            return newCelestialObject;
        }
    }
}
