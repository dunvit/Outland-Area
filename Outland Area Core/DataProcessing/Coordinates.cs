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
                RecalculateGeneralObjectLocation(gameSession, celestialObject, settings);
            }

            return gameSession;
        }

        private void RecalculateGeneralObjectLocation(GameSession gameSession, ICelestialObject celestialObject, EngineSettings settings)
        {
            var speedInTick = celestialObject.Speed / settings.UnitsPerSecond;

            var position = GeometryTools.MoveObject(
                new PointF(celestialObject.PositionX, celestialObject.PositionY),
                speedInTick,
                celestialObject.Direction);


            if (celestialObject is Missile missile)
            {
                var target = gameSession.GetCelestialObject(missile.TargetId).ToSpaceship();

                var direction = GeometryTools.Azimuth(target.GetLocation(), missile.GetLocation());

                position = GeometryTools.MoveObject( new PointF(celestialObject.PositionX, celestialObject.PositionY), speedInTick, direction);
            }

            Logger.Debug($"Object '{celestialObject.Name}' id='{celestialObject.Id}' moved from {celestialObject.GetLocation()} to {position}");

            celestialObject.PreviousPositionX = celestialObject.PositionX;
            celestialObject.PreviousPositionY = celestialObject.PositionY;

            celestialObject.PositionX = position.X;
            celestialObject.PositionY = position.Y;
        }
    }
}
