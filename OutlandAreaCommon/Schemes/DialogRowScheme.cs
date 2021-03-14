using System;
using System.Collections.Generic;
using OutlandAreaCommon.Tactical.Scenario.Dialog;

namespace OutlandAreaCommon.Schemes
{
    [Serializable]
    public class DialogRowScheme
    {
        public long Id { get; set; }

        public string Message { get; set; }

        public long CharacterId { get; set; }

        public Align Align { get; set; }

        public List<DialogExitScheme> Exits = new List<DialogExitScheme>();
    }
}
