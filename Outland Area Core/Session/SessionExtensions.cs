using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EngineCore.Geometry;
using EngineCore.Tools;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;
using log4net;

namespace EngineCore.Session
{
    public static class SessionExtensions
    {
        public static Spaceship GetPlayerSpaceShip(this GameSession session)
        {
            foreach (var celestialObject in session.Data.CelestialObjects)
            {
                if (celestialObject.Classification == 200)
                {
                    return celestialObject.ToSpaceship();
                }
            }

            return null;
        }

        public static ICelestialObject GetCelestialObject(this GameSession gameSession, long id, bool isCopy = false)
        {
            if(isCopy)
                return (from celestialObjects in gameSession.Data.CelestialObjects where id == celestialObjects.Id select celestialObjects.DeepClone()).FirstOrDefault();

            return (from celestialObjects in gameSession.Data.CelestialObjects where id == celestialObjects.Id select celestialObjects).FirstOrDefault();
        }

        public static List<ICelestialObject> GetCelestialObjectsByDistance(this GameSession gameSession, System.Drawing.PointF coordinates, int range)
        {
            return gameSession.Data.CelestialObjects.Map(celestialObject => (celestialObject,
                        GeometryTools.Distance(
                            coordinates,
                            celestialObject.GetLocation())
                    )).
                Where(e => e.Item2 < range).
                OrderBy(e => e.Item2).
                Map(e => e.celestialObject).
                ToList();
        }
    }
}
