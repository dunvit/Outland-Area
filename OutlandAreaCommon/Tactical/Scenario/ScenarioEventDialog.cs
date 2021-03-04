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
        public ScenarioEventTypes Type { get; set; }
        public void Execute(GameSession session)
        {
            throw new System.NotImplementedException();
        }
    }
}