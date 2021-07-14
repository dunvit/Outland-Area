using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using EngineCore.Geometry;
using EngineCore.Session;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;
using log4net;

namespace EngineCore.DataProcessing
{
    public class Explosions
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly List<ICelestialObject> _explodedMissiles = new List<ICelestialObject>();

        public GameSession Execute(GameSession gameSession, EngineSettings settings)
        {
            
            foreach (var celestialObject in gameSession.GetCelestialObjects())
            {
                if (celestialObject is Missile)
                {
                    ExplosionCalculate(celestialObject, gameSession, settings);
                }
            }

            foreach (var explodedMissile in _explodedMissiles)
            {
                // TODO: Refactor it - create Add Celestial object method on Game Session level
                gameSession.CelestialObjects.Remove(explodedMissile);
            }

            return gameSession;
        }

        private void ExplosionCalculate(ICelestialObject celestialObject, GameSession gameSession, EngineSettings settings)
        {
            var missile = celestialObject as Missile;

            if (missile is null) return;

            Logger.Debug($"Missile {missile.Id} from spaceship {missile.OwnerId}");

            var speedInTick = celestialObject.Speed / settings.UnitsPerSecond;

            var target = gameSession.GetCelestialObject(missile.TargetId).ToSpaceship();

            var direction = GeometryTools.Azimuth(target.GetLocation(), celestialObject.GetLocation());

            var position = GeometryTools.MoveObject(
                new PointF(celestialObject.PositionX, celestialObject.PositionY),
                speedInTick,
                direction);

            Logger.Debug($"Missile '{celestialObject.Name}' id='{celestialObject.Id}' moved from {celestialObject.GetLocation()} to {position}");

            celestialObject.PreviousPositionX = celestialObject.PositionX;
            celestialObject.PreviousPositionY = celestialObject.PositionY;
            celestialObject.Direction = direction;
            celestialObject.PositionX = position.X;
            celestialObject.PositionY = position.Y;

            var distance = GeometryTools.Distance(celestialObject.GetLocation(), target.GetLocation());

            if (distance < celestialObject.Speed)
            {
                Logger.Info($"Missile {missile.Id} from spaceship {missile.OwnerId} hit to spaceship {target.Id}");

                target.Damage(missile.Damage);

                _explodedMissiles.Add(celestialObject);
            }
        }
    }
}
