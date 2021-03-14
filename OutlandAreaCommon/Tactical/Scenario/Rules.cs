using System;

namespace OutlandAreaCommon.Tactical.Scenario
{
    [Serializable]
    public class Rules
    {
        public bool IsEventsEnabled { get; set; } = true;

        public SpawnRules Spawn { get; set; } = new SpawnRules();
    }
}
