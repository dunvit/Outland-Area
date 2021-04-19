using System.Collections.Generic;
using System.Linq;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaCommon.Tactical
{
    public class SpaceMapActions
    {
        public static List<ICelestialObject> GetUnknownCelestialObjectsByDistance(GameSession gameSession)
        {
            return gameSession.SpaceMap.CelestialObjects.Map(celestialObject => (celestialObject,
                        Coordinates.GetDistance(
                            gameSession.GetPlayerSpaceShip().GetLocation(),
                            celestialObject.GetLocation())
                    )).
                OrderBy(e => e.Item2).Map(e => e.celestialObject).
                Where(celestialObject => celestialObject.Id != gameSession.GetPlayerSpaceShip().Id).
                Where(o => o.IsScanned == false).
                ToList();
        }

        public static List<ICelestialObject> GetSpaceshipsByDistance(GameSession gameSession)
        {
            return gameSession.SpaceMap.CelestialObjects.Map(celestialObject => (celestialObject,
                        Coordinates.GetDistance(
                            gameSession.GetPlayerSpaceShip().GetLocation(),
                            celestialObject.GetLocation())
                    )).
                OrderBy(e => e.Item2).Map(e => e.celestialObject).
                Where(celestialObject => celestialObject.Id != gameSession.GetPlayerSpaceShip().Id).
                //Where(o => o.IsScanned == false).
                ToList();
        }
    }
}
