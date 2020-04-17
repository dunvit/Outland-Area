using System.Collections.Generic;

namespace OutlandAreaLogic.DialogSystems.Schemes
{
    public class DialogRowScheme
    {
        public long Id { get; set; }

        public string Message { get; set; }

        public string Background { get; set; }

        public long CharacterId { get; set; }

        public Alignment Align { get; set; }

        public List<DialogExitScheme> Exits = new List<DialogExitScheme>();
    }
}
