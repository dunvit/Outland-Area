using System;

namespace EngineCore.Scenario
{
    [Serializable]
    public class Rules
    {
        public bool IsEventsEnabled { get; set; } = true;

        public SpawnRules Spawn { get; set; } = new SpawnRules();
    }
}
