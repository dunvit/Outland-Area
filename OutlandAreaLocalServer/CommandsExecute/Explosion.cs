﻿using System.Collections.Generic;
using Engine.Common.Geometry;
using log4net;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class Explosion
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CommandExecuteResult Execute(GameSession gameSession, Command command)
        {
            Logger.Info($"[{GetType().Name}]\t Execute.");

            var explosion = gameSession.GetCelestialObject(command.CelestialObjectId).ToExplosion();

            var destroyedSpaceships = new List<ICelestialObject>();

            foreach (var celestialObject in gameSession.Map.CelestialObjects)
            {
                if (celestialObject.IsSpaceship() == false) continue;

                var spaceShip = celestialObject.ToSpaceship();

                var distance = SpaceMapTools.GetDistance(celestialObject.GetLocation(), explosion.GetLocation());

                if (distance < explosion.Radius * 2)
                {
                    spaceShip.Damage(explosion.Damage);

                    gameSession.History.Add($"Spaceship {spaceShip.Name} get damage '{explosion.Damage}' from '{explosion.Name}'");

                    if (spaceShip.IsDestroyed)
                    {
                        destroyedSpaceships.Add(celestialObject);
                    }
                }

                foreach (var destroyedSpaceship in destroyedSpaceships)
                {
                    gameSession.RemoveCelestialObject(destroyedSpaceship);

                    gameSession.History.Add($"Spaceship {destroyedSpaceship.Name} destroyed.");
                }
            }

            return new CommandExecuteResult { Command = command, IsResume = false };
        }
    }
}
