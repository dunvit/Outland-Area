﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Engine.Common.Geometry;
using log4net;
using log4net.Repository.Hierarchy;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Geometry;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe.Objects.Spaceships;
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

                newCelestialObject.Direction = SpaceMapTools.GetAngleBetweenPoints(newCelestialObject.GetLocation().ToVector2(), spaceship.GetLocation().ToVector2());
            }

            return newCelestialObject;
        }
    }
}
