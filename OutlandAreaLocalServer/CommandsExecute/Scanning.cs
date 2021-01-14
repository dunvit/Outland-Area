using System;
using System.Reflection;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class Scanning
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public CommandExecuteResult Execute(GameSession gameSession, Command command)
        {
            gameSession.AddHistoryMessage("started.", GetType().Name, true);

            AddBuiltInEvents(gameSession);

            if (Tools.RandomizeDice100() > RandomGenerator.BaseAsteroidChance)
            {
                gameSession.AddCelestialObject(RandomGenerator.Asteroid(gameSession));
            }

            return new CommandExecuteResult { Command = command, IsResume = false };
        }

        private void AddBuiltInEvents(GameSession gameSession)
        {
            if (gameSession.Turn == 1)
            {
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

                var message = new Message
                {
                    Type = MessageTypes.AnomalyFound,
                    CelestialObjectId = newCelestialObject.Id
                };

                gameSession.AddCelestialObject(newCelestialObject);

                gameSession.AddMessage(message);
            }
        }

    }
}
