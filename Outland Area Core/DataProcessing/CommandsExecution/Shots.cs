using EngineCore.Session;
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

        public GameSession Execution(GameSession gameSession, TurnSettings settings, Command command)
        {
            var currentCelestialObject = gameSession.GetCelestialObject(command.CelestialObjectId, false);            

            Logger.Debug($"[{GetType().Name}][Execution] Execution Shot command - {command.Type} turn '{gameSession.Turn}'");

            var jObject = JObject.Parse(command.Body);

            var targetId = (int)jObject["TargetId"];
            var objectId = (int)jObject["ObjectId"];
            var moduleId = (int)jObject["ModuleId"];


            var currentModule = gameSession.GetCelestialObject(objectId).ToSpaceship().GetModule(moduleId);

            // TODO: Check is module reloaded
            if (currentModule.IsReloaded == false && settings.DebugProperties.IsAlwaysSuccessful == false)
            {
                Logger.Debug($"[{GetType().Name}][Execution] Module not reloaded. {currentModule.Reloading}/{currentModule.ReloadTime} turn '{gameSession.Turn}'");
                return gameSession;
            }

            var commandPrediction = Prediction(gameSession, command.Type, objectId, moduleId, targetId);

            var shotResult = Tools.RandomGenerator.GetDouble(100);

            if (commandPrediction.Max < shotResult  || settings.DebugProperties.IsAlwaysSuccessful)
            {
                // Hit
                // TODO: Move hit calculation to separate class
                var targetSpacecraft = gameSession.GetCelestialObject(targetId, false).ToSpaceship();

                var ammoId = gameSession.GetCelestialObject(objectId).ToSpaceship().GetModule(moduleId).ToWeapon().AmmoId;

                var ammo = AmmoFactory.GetAmmo(ammoId);

                targetSpacecraft.Damage(ammo.Damage);
            }
            else
            {
                // Miss
            }

            // Reload module
            gameSession.GetCelestialObject(objectId).ToSpaceship().GetModule(moduleId).Reload();

            // TODO: Add message to client

            return gameSession;
        }

        public ActionResult Prediction(GameSession gameSession, CommandTypes type, int objectId, int moduleId, int targetId)
        {
            var result = new ActionResult();

            switch (type)
            {
                case CommandTypes.Shot:
                    //var x = gameSession.GetDistance(objectId, targetId);
                    //var weaponModule = gameSession.GetCelestialObject(objectId).ToSpaceship().GetModule(moduleId).ToWeapon();
                    //var usedWith = weaponModule.UsedWith;
                    //var ammoId = gameSession.GetCelestialObject(objectId).ToSpaceship().GetModule(moduleId).ToWeapon().AmmoId;
                    //var ammo = AmmoFactory.GetAmmo(ammoId);

                    // TODO: Add formula get hit change by distance and weapon and ammo properties + pilot skills.
                    result.Min = 45;
                    result.Max = 57;
                    break;
            }

            return result;
        }


    }
}
