using log4net;
using System.Drawing;
using System.Reflection;
using EngineCore.Geometry;
using EngineCore.Session;
using EngineCore.Universe.Objects;

namespace EngineCore.DataProcessing
{
    public class Coordinates
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public GameSession Recalculate(GameSession gameSession, EngineSettings settings)
        {
            foreach (var celestialObject in gameSession.Data.CelestialObjects)
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

            return gameSession;
        }
    }
}
