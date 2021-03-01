﻿using System;
using System.Reflection;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class SessionEvents
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Execute(GameSession gameSession)
        {

            return;

            switch (gameSession.Turn)
            {
                case 1:
                    AddAsteroid(gameSession);
                    break;

            }
        }

        private static void AddAsteroid(GameSession gameSession)
        {
            if (gameSession.IsRandomObjectsGeneration == false) return;

            var spaceship = gameSession.GetPlayerSpaceShip().ToSpaceship();

            ICelestialObject newCelestialObject = new Asteroid
            {
                Id = new Random().NextInt(),
                PositionX = spaceship.PositionX + 350,
                PositionY = spaceship.PositionY + 270,
                Name = "DARAON-217-167",
                Direction = spaceship.Direction - 174,
                Speed = 2,
                Classification = CelestialObjectTypes.Asteroid.ToInt(),
                IsScanned = false,
                Signature = 210
            };

            var message = new GameEvent
            {
                Type = GameEventTypes.AnomalyFound,
                CelestialObjectId = newCelestialObject.Id,
                IsOpenWindow = true,
                IsPause = true
            };

            gameSession.AddCelestialObject(newCelestialObject);

            gameSession.AddEvent(message);
        }
    }
}
