using EngineCore.Session;
using Newtonsoft.Json;
using System;

namespace EngineCore.Universe.Equipment
{
    public class ModuleCommand
    {
        public static string ToJson(GameSession gameSession, Func<dynamic> action)
        {
            var commandJObject = action();

            commandJObject.TypeId = commandJObject.TypeId;
            commandJObject.Turn = gameSession.Turn;

            return commandJObject.ToString(Formatting.None);
        }

        public static string ToJson(GameSession gameSession, Func<int, int, int, dynamic> action, int targetId, int moduleId)
        {
            var commandJObject = action(gameSession.GetPlayerSpaceShip().Id, targetId, moduleId);

            commandJObject.TypeId = commandJObject.TypeId;
            commandJObject.Turn = gameSession.Turn;

            return commandJObject.ToString(Formatting.None);
        }
    }
}
