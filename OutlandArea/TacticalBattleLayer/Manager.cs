using System;
using System.Collections.Generic;
using System.Drawing;

namespace OutlandArea.TacticalBattleLayer
{
    public static class Manager
    {
        public static event Action<Turn> OnStartNewTurn;
        private static Turn CurrentTurn { get; set; }

        private static Battle Battle { get; }

        public static TacticalMap Map { get; }

        static Manager()
        {
            Map = new TacticalMap {PlayerShip = new Point(10, 10)};

            Battle = Data.Battle.Generator.GetBasicBattle();
        }

        public static void EndTurn(List<ICommand> commands)
        {
            Battle.EndTurn();

            CurrentTurn = new Turn(Battle.CelestialObjects){Number = Battle.Turn};

            OnStartNewTurn?.Invoke(CurrentTurn);
        }

        public static void FinishInitialization()
        {
            EndTurn(null);
        }

    }
}
