using Newtonsoft.Json.Linq;
using System;

namespace EngineCore
{
    [Serializable]
    public class Command
    {
        public CommandTypes Type { get; set; }
        public long CelestialObjectId { get; set; }
        public string Body { get; set; }

        public bool IsAlwaysSuccessful { get; private set; }

        public Command(string commandBody, bool isAlwaysSuccessful = false)
        {
            CelestialObjectId = (long)JObject.Parse(commandBody)["OwnerId"];

            Type = (CommandTypes)(int)JObject.Parse(commandBody)["TypeId"];

            Body = commandBody;

            IsAlwaysSuccessful = isAlwaysSuccessful;
        }
    }
}
