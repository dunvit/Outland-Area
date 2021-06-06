using EngineCore.Session;
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

            return null;
        }


    }
}
