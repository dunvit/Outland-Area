using System;

namespace OutlandAreaCommon.Tactical.Scenario
{
    [Serializable]
    public class ScenarioEventBase
    {
        public int Id { get; set; }
        public int Scene { get; set; }
        public int Turn { get; set; }
        public bool IsEnabled { get; set; } = true;
        public GameEventTypes Type { get; set; }
    }
}
