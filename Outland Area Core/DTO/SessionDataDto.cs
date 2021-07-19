using System.Collections.Generic;
using EngineCore.Events;
using EngineCore.Scenario;
using EngineCore.Session;
using EngineCore.Universe.Model;

namespace EngineCore.DTO
{
    public struct SessionDataDto
    {
        public int Turn { get; set; }

        public bool IsPause { get; set; }

        public string ScenarioName { get; set; }

        public Rules Rules { get; set; }

        public List<GameEvent> GameEvents { get; set; }

        public List<HistoryMessage> TurnHistory { get; set; }

        public List<ICelestialObject> CelestialObjects { get; set; }

    }
}
