using System;
using System.Collections.Generic;

namespace OutlandArea.Battle
{
    public static class Manager
    {
        public static event Action<Turn> OnStartNewTurn;
        private static Turn CurrentTurn { get; set; } = new Turn{Number = 1};


        public static void EndTurn(List<ICommand> commands)
        {
            CurrentTurn = new Turn{Number = CurrentTurn.Number+1};

            OnStartNewTurn?.Invoke(CurrentTurn);
        }

    }
}
