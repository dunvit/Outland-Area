using System.Collections.Generic;
using System.Reflection;
using EngineCore.Events;
using EngineCore.Geometry;
using EngineCore.Session;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;
using log4net;

namespace EngineCore.DataProcessing
{
    public class MissilesActivation
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly List<ICelestialObject> _explodedMissiles = new List<ICelestialObject>();
        private readonly List<ICelestialObject> _addedExplosions = new List<ICelestialObject>();

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
                // TODO: Refactor it - create Remove Celestial object method on Game Session level
                gameSession.CelestialObjects.Remove(explodedMissile);
            }

            foreach (var explosion in _addedExplosions)
            {
                // TODO: Refactor it - create Add Celestial object method on Game Session level
                gameSession.CelestialObjects.Add(explosion);
            }

            // Remove overdue explosion
            foreach (var explodedExplosion in ExplosionsRemove(gameSession))
            {
                // TODO: Refactor it - create Remove Celestial object method on Game Session level
                gameSession.CelestialObjects.Remove(explodedExplosion);
            }

            return gameSession;
        }

        private IEnumerable<ICelestialObject> ExplosionsRemove(GameSession gameSession)
        {
            var result = new List<ICelestialObject>();

            foreach (var celestialObject in gameSession.GetCelestialObjects())
            {
                if (!(celestialObject is Explosion explosion)) continue;

                if (explosion.RemoveTurn < gameSession.Turn)
                {
                    result.Add(celestialObject);
                }
            }

            return result;
        }

        private void ExplosionCalculate(ICelestialObject celestialObject, GameSession gameSession, EngineSettings settings)
        {
            if (!(celestialObject is Missile missile)) return;

            Logger.Debug($"Missile {missile.Id} from spaceship {missile.OwnerId}");

            var target = gameSession.GetCelestialObject(missile.TargetId).ToSpaceship();

            var distance = GeometryTools.Distance(celestialObject.GetLocation(), target.GetLocation());

            if (!(distance < celestialObject.Speed)) return;

            Logger.Info($"Missile {missile.Id} from spaceship {missile.OwnerId} hit to spaceship {target.Id}");

            target.Damage(missile.Damage);

            _explodedMissiles.Add(celestialObject);

            var explosion = new Explosion(gameSession.Turn, target.Id)
            {
                OwnerId = celestialObject.OwnerId,
                PositionX = target.PositionX,
                PositionY = target.PositionY
            };

            _addedExplosions.Add(explosion);

            var newGameEvent = new GameEvent
            {
                Type = GameEventTypes.ExplosionResult,
                Turn = gameSession.Turn + 1,
                IsPause = true,
                IsOpenWindow = true
            };

            newGameEvent.GenericObjects.Add(new GameEventParameter(GameEventParameterTypes.OwnerId, missile.OwnerId));
            newGameEvent.GenericObjects.Add(new GameEventParameter(GameEventParameterTypes.TargetId, missile.TargetId));
            newGameEvent.GenericObjects.Add(new GameEventParameter(GameEventParameterTypes.ModuleId, missile.ModuleId));
            newGameEvent.GenericObjects.Add(new GameEventParameter(GameEventParameterTypes.ActionId, missile.ActionId));
            newGameEvent.GenericObjects.Add(new GameEventParameter(GameEventParameterTypes.Dice, missile.Dice));
            newGameEvent.GenericObjects.Add(new GameEventParameter(GameEventParameterTypes.Damage, missile.Damage));
            newGameEvent.GenericObjects.Add(new GameEventParameter(GameEventParameterTypes.Chance, missile.Chance));

            if ((int)missile.Damage == 0)
            {
                newGameEvent.GenericObjects.Add(new GameEventParameter(GameEventParameterTypes.Result, "MISS"));
            }

            if (missile.Damage > 0)
            {
                newGameEvent.GenericObjects.Add(target.Shields > 0 ? new GameEventParameter(GameEventParameterTypes.Result, "HIT")
                    : new GameEventParameter(GameEventParameterTypes.Result, "DESTROYED"));
            }

            gameSession.AddEvent(newGameEvent);
        }
    }
}
