using System;
using System.Collections.Generic;
using System.Drawing;

namespace OutlandArea.TacticalBattleLayer
{
    public static class Manager
    {
        public static event Action<Turn> OnStartNewTurn;
        private static Turn CurrentTurn { get; set; } 

        public static TacticalMap Map { get; }

        static Manager()
        {
            Map = new TacticalMap {PlayerShip = new Point(10, 10)};

            
        }

        public static void EndTurn(List<ICommand> commands)
        {
            //CurrentTurn = new Turn(new List<ICelestialObject>(
            //    new 
            //    )){Number = CurrentTurn.Number+1};

            OnStartNewTurn?.Invoke(CurrentTurn);
        }

        public static void FinishInitialization()
        {
            EndTurn(null);
        }

    }
}
