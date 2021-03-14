using System;
using System.Reflection;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class SessionEvents
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public GameSession Execute(GameSession gameSession)
        {
            gameSession.AddHistoryMessage($"SessionEvents started.", GetType().Name, true);

            var result = gameSession.DeepClone();

            if (gameSession.Rules.IsEventsEnabled == false)
            {
                gameSession.AddHistoryMessage("SessionEvents canceled by scenario configuration.", GetType().Name, true);

                return result;
            }

            foreach (var scenarioEvent in gameSession.GetScenarioEvents())
            {
                Logger.Debug($"Found scenario event (id={scenarioEvent.Id}.");

                var newGameEvent = new GameEvent
                {
                    Turn = gameSession.Turn + 1,
                    Type = GameEventTypes.OpenDialog,
                    IsPause = true,
                    IsOpenWindow = true,
                    DialogId = scenarioEvent.ToScenarioEventDialog().DialogId
                };

                result.AddEvent(newGameEvent);
            }

            return result;
        }


        private static void AddAsteroid(GameSession gameSession)
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
