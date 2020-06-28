using System.Collections.Generic;

namespace OutlandArea.Battle
{
    public class Turn
    {
        public int Number { get; set; }

        public bool IsFinished { get; set; }

        public List<ICommand> Commands { get; set; } = new List<ICommand>();
    }
}
