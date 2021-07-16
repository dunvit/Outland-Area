using System;
using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Equipment;
using EngineCore.Universe.Equipment.Ammunition.Missiles;
using EngineCore.Universe.Objects;
using log4net;
using Newtonsoft.Json.Linq;

namespace EngineCore.DataProcessing.CommandsExecution
{
    public class Shots
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GameSession Execution(GameSession gameSession, EngineSettings settings, Command command, Action<int, string> addCommand)
        {
            var spaceship = gameSession.GetCelestialObject(command.CelestialObjectId).ToSpaceship();

            Logger.Debug($"[{GetType().Name}][Execution] Execution Shot command - {command.Type} turn '{gameSession.Turn}'");

            var jObject = JObject.Parse(command.Body);

            var targetId = (int)jObject["TargetId"];
            var objectId = (int)jObject["ObjectId"];
            var moduleId = (int)jObject["ModuleId"];
            var actionId = (int)jObject["ActionId"];

            var currentModule = spaceship.GetModule(moduleId);

            // TODO: Check is module reloaded
            if (currentModule.IsReloaded == false && settings.DebugProperties.IsAlwaysSuccessful == false)
            {
                Logger.Debug($"[{GetType().Name}][Execution] Module not reloaded. {currentModule.Reloading}/{currentModule.ReloadTime} turn '{gameSession.Turn}'");
                return gameSession;
            }

            var commandPrediction = Prediction(gameSession, command.Type, objectId, moduleId, targetId);

            var shotResult = RandomGenerator.GetDouble(100);


            float damage = 0;
            
            if (commandPrediction.Max > shotResult || settings.DebugProperties.IsAlwaysSuccessful)
            {
                // Hit
                // TODO: Move hit calculation to separate class

                var ammoId = spaceship.GetModule(moduleId).ToWeapon().AmmoId;

                damage = AmmoFactory.GetAmmo(ammoId).Damage;

            }

            var module = spaceship.GetWeaponModule(moduleId);

            var celestialObject = new Missile
            {
                Id = RandomGenerator.GetId(),
                Chance = commandPrediction.Max,
                Damage = damage,
                ModuleId = moduleId,
                ActionId = actionId,
                Dice = (int)shotResult,
                OwnerId = spaceship.Id,
                TargetId = targetId,
                PositionX = spaceship.PositionX,
                PositionY = spaceship.PositionY,
                Classification = CelestialObjectTypes.Missile.ToInt(),
                Direction = 0,
                Speed = 50,
                Name = module.AmmoId.ToString()
            };

            // TODO: Refactor it - create Add Celestial object method on Game Session level
            gameSession.CelestialObjects.Add(celestialObject);

            // Reload module
            gameSession.GetCelestialObject(objectId).ToSpaceship().GetModule(moduleId).Reload();

            return gameSession;
        }

        public ActionResult Prediction(GameSession gameSession, CommandTypes type, int objectId, int moduleId, int targetId)
        {
            var result = new ActionResult();

            switch (type)
            {
                case CommandTypes.Shot:
                    //var x = gameSession.Distance(objectId, targetId);
                    var weaponModule = gameSession.GetCelestialObject(objectId).ToSpaceship().GetModule(moduleId).ToWeapon();
                    //var usedWith = weaponModule.UsedWith;
                    //var ammoId = gameSession.GetCelestialObject(objectId).ToSpaceship().GetModule(moduleId).ToWeapon().AmmoId;
                    //var ammo = AmmoFactory.GetAmmo(ammoId);

                    // TODO: Add formula get hit change by distance and weapon and ammo properties + pilot skills.
                    result.Min = 45;
                    result.Max = weaponModule.BaseAccuracy;
                    break;
            }

            return result;
        }


    }
}
