using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EngineCore.DataProcessing
{
    public class Convert
    {
        //TODO: Replace constant to value from settings.
        const double historyRange = 5;

        //TODO: Replace constant to value from player spacecraft sonars.
        const double SonarRange = 1000;


        public static GameSession ToClient(GameSession gameSession)
        {
            var gameSessionForClient = gameSession.DeepClone();

            gameSessionForClient.CelestialObjects = VisibilityAreaFilter(gameSession);

            gameSessionForClient.ScenarioEvents = ScenarioEventsFilter(gameSession);

            return gameSessionForClient;
        }

        private static List<IScenarioEvent> ScenarioEventsFilter(GameSession gameSession)
        {
            

            var result = gameSession.ScenarioEvents.
                Where(e => e.Turn > gameSession.Turn - historyRange).
                ToList();

            return result;
        }

        private static List<ICelestialObject> VisibilityAreaFilter(GameSession gameSession)
        {
            var objectsInScreen = gameSession.CelestialObjects.Map(celestialObject => (celestialObject,
                    Coordinates.GetDistance(
                        gameSession.GetPlayerSpaceShip().GetLocation(),
                        celestialObject.GetLocation())
                )).
                Where(e =>  e.Item2 < SonarRange).
                OrderBy(e => e.Item2).Map(e => e.celestialObject).
                ToList();

            return objectsInScreen;
        }


    }
}
