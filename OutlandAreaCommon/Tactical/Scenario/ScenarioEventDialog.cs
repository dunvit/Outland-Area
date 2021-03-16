using System;
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

        public void Execute(GameSession session)
        {
            IsEnabled = false;
        }
    }
}