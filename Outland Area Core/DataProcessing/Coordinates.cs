using System.Drawing;
using System.Reflection;
using EngineCore.Geometry;
using EngineCore.Session;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;
using log4net;

namespace EngineCore.DataProcessing
{
    public class Coordinates
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public GameSession Recalculate(GameSession gameSession, EngineSettings settings)
        {
            foreach (var celestialObject in gameSession.GetCelestialObjects())
            {
                RecalculateGeneralObjectLocation(celestialObject, settings);
            }

            return gameSession;
        }

        private void RecalculateGeneralObjectLocation(ICelestialObject celestialObject, EngineSettings settings)
        {
            var speedInTick = celestialObject.Speed / settings.UnitsPerSecond;

            var position = GeometryTools.MoveObject(
                new PointF(celestialObject.PositionX, celestialObject.PositionY),
                speedInTick,
                celestialObject.Direction);

            Logger.Debug($"Object '{celestialObject.Name}' id='{celestialObject.Id}' moved from {celestialObject.GetLocation()} to {position}");

            celestialObject.PreviousPositionX = celestialObject.PositionX;
            celestialObject.PreviousPositionY = celestialObject.PositionY;

            celestialObject.PositionX = position.X;
            celestialObject.PositionY = position.Y;
        }
    }
}
