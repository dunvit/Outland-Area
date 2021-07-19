using System.Collections.Generic;
using EngineCore.Events;
using EngineCore.Scenario;
using EngineCore.Universe.Model;

namespace EngineCore.Session
{
    public interface ISessionData
    {
        int Turn { get; }
        bool IsPause { get; }
        string ScenarioName { get; }
        Rules Rules { get; }
        List<GameEvent> GameEvents { get; }
        List<HistoryMessage> TurnHistory { get; }
        List<ICelestialObject> CelestialObjects { get; }
    }
}