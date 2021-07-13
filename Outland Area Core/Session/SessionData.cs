using EngineCore.Events;
using EngineCore.Scenario;
using EngineCore.Universe.Model;
using System;
using System.Collections.Generic;

namespace EngineCore.Session
{

    [Serializable]
    public class SessionData : ISessionData
    {
        public int Turn { get; set; }

        public bool IsPause { get; set; }

        public string ScenarioName { get; set; }

        public Rules Rules { get; set; } = new Rules();

        public List<GameEvent> GameEvents { get; set; } = new List<GameEvent>();

        public List<HistoryMessage> TurnHistory { get; set; } = new List<HistoryMessage>();

        public List<ICelestialObject> CelestialObjects { get; set; } = new List<ICelestialObject>();
    }
}
