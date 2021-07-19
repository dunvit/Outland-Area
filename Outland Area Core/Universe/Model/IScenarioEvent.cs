
using System.Collections.Generic;
using EngineCore.Events;
using EngineCore.Session;

namespace EngineCore.Universe.Model
{
    public interface IScenarioEvent
    {
        int Id { get; set; }
        int Scene { get; set; }

        int Turn { get; set; }

        bool IsEnabled { get; set; }

        GameEventTypes Type { get; set; }

        List<GameEventDecision> Decisions { get; set; }

        List<GameEventParameter> Execute(GameSession session);
    }
}
