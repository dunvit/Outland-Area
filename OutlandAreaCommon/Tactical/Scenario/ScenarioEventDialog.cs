using System;
using OutlandAreaCommon.Tactical.Model;

namespace OutlandAreaCommon.Tactical
{
    [Serializable]
    public class ScenarioEventDialog : IScenarioEvent
    {
        public int Id { get; set; }
        public int Scene { get; set; }
        public int Turn { get; set; }
        public bool IsEnabled { get; set; } = true;
        public int DialogId { get; set; }
        public GameEventTypes Type { get; set; }

        public ScenarioEventDialog(int dialogId)
        {
            DialogId = dialogId;
        }

        public void Execute(GameSession session)
        {
            IsEnabled = false;
        }

        //IEnumerable<IScenarioEvent>

        
    }
}