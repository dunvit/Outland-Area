using System;
using System.Collections.Generic;
using EngineCore.Events;
using EngineCore.Session;
using EngineCore.Universe.Model;

namespace EngineCore.Scenario
{
    [Serializable]
    public class ScenarioEventDialog : ScenarioEventBase, IScenarioEvent
    {
        public int DialogId { get; set; }

        public ScenarioEventDialog(int dialogId)
        {
            DialogId = dialogId;
        }

        public List<GameEventDecision> Decisions { get; set; }

        public List<string> Execute(GameSession session)
        {
            IsEnabled = false;

            return new List<string>();
        }
    }
}