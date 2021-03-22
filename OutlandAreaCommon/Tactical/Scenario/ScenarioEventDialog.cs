using System;
using System.Collections.Generic;
using OutlandAreaCommon.Tactical.Model;
using OutlandAreaCommon.Tactical.Scenario;

namespace OutlandAreaCommon.Tactical
{
    [Serializable]
    public class ScenarioEventDialog : ScenarioEventBase, IScenarioEvent
    {
        public int DialogId { get; set; }

        public ScenarioEventDialog(int dialogId)
        {
            DialogId = dialogId;
        }

        public List<string> Execute(GameSession session)
        {
            IsEnabled = false;

            return new List<string>();
        }
    }
}