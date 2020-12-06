using System.Collections.Generic;
using OutlandAreaCommon;
using OutlandAreaCommon.Equipment.Weapon;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaCommon.Universe.Objects.Spaceships;

namespace OutlandAreaLocalServer
{
    public class Commands
    {
        public GameSession Execute(GameSession gameSession)
        {
            var result = gameSession.DeepClone();

            // Clear history log for each turn
            result.History = new List<string>();

            if (gameSession.Commands == null)
            {
                // Commands pool is empty. No need execute action.
                return result;
            }

            // Clear commands pool
            result.Commands = new List<Command>();

            foreach (var command in gameSession.Commands)
            {
                switch (command.Type)
                {
                    case CommandTypes.Explosion:

                        var executeExplosion = new CommandsExecute.Explosion().Execute(result, command);

                        if (executeExplosion.IsResume)
                        {
                            result.Commands.Add(executeExplosion.Command.DeepClone());
                        }
                        else
                        {
                            var explosion = (Explosion)gameSession.GetCelestialObject(command.CelestialObjectId);

                            result.RemoveCelestialObject(explosion);
                        }

                        break;

                    case CommandTypes.AlignTo:
                        var executeAlignToResult = new CommandsExecute.AlignTo().Execute(result, command);

                        if (executeAlignToResult.IsResume)
                        {
                            result.Commands.Add(executeAlignToResult.Command.DeepClone());
                        }
                        break;

                    case CommandTypes.Fire:
                        var executeFireResult = new CommandsExecute.ExecuteFire().Execute(result, command);

                        if (executeFireResult.IsResume)
                        {
                            result.Commands.Add(executeFireResult.Command.DeepClone());
                        }
                        else
                        {
                            // Replace missile align to operation to explosive object
                            var celestialObject = gameSession.GetCelestialObject(command.CelestialObjectId);
                            var missileTarget = gameSession.GetCelestialObject(command.TargetCelestialObjectId);

                            var missile = gameSession.GetCelestialObject(command.CelestialObjectId).ToMissile();

                            result.RemoveCelestialObject(missileTarget);

                            var explosionObject = new Explosion
                            {
                                Classification = 800,
                                Damage = missile.Damage,
                                Name = celestialObject.Name,
                                PositionX = missileTarget.PositionX,
                                PositionY = missileTarget.PositionY,
                                Radius = missile.ExplosionRadius,
                                Speed = 0,
                                Direction = 0
                            };

                            result.AddCelestialObject(explosionObject);

                            var explosionCommand = new Command
                            {
                                TargetCelestialObjectId = explosionObject.Id,
                                Type = CommandTypes.Explosion,
                                CelestialObjectId = explosionObject.Id
                            };
                            result.Commands.Add(explosionCommand);
                        }
                        break;

                    case CommandTypes.ReloadWeapon:

                        foreach (var celestialObjects in result.SpaceMap.CelestialObjects)
                        {
                            if (celestialObjects.Id ==command.CelestialObjectId)
                            {
                                var spaceship = celestialObjects.ToSpaceship();

                                foreach (var module in spaceship.Modules)
                                {
                                    if (module.Id == command.TargetCelestialObjectId)
                                    {
                                        var moduleWeapon = (IWeaponModule)module;

                                        ((IWeaponModule)module).Reloading = 0;

                                        moduleWeapon.Reloading = 0;
                                    }
                                }
                            }
                        }

                        break;
                }
            }

            return result;
        }





        
    }
}
