
using System;

namespace EngineCore.Events
{
    [Serializable]
    public class GameEventDecision
    {
        public int DialogId { get; private set; }

        public string Label { get; private set; }

        public GameEventDecision(int dialogId, string label)
        {
            DialogId = dialogId;
            Label = label;
        }
    }
}
