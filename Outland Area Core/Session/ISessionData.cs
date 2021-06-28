using System.Collections.Generic;
using EngineCore.Events;
using EngineCore.Scenario;
using EngineCore.Universe.Model;

namespace EngineCore.Session
{
    public interface ISessionData
    {
        Rules Rules { get; set; }
        List<GameEvent> GameEvents { get; set; }
        List<HistoryMessage> TurnHistory { get; set; }
        List<ICelestialObject> CelestialObjects { get; set; }
    }
}