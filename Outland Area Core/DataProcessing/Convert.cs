using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using EngineCore.Geometry;

namespace EngineCore.DataProcessing
{
    public class Convert
    {
        //TODO: Replace constant to value from settings.
        const double historyRange = 5;

        //TODO: Replace constant to value from player spacecraft sonars.
        const double SonarRange = 1000;


        public static SessionDTO ToClient(GameSession gameSession)
        {
            var data = gameSession.Data.DeepClone();

            data.IsPause = gameSession.IsPause;
            data.CelestialObjects = VisibilityAreaFilter(gameSession);

            return data;
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
            var objectsInScreen = gameSession.Data.CelestialObjects.Map(celestialObject => (celestialObject,
                    GeometryTools.Distance(
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
