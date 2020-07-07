using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OutlandArea.TacticalBattleLayer
{
    public class Manager
    {
        public event Action<Turn> OnStartNewTurn;

        public event Action OnChangeCommandsQueue;

        private Turn CurrentTurn { get; set; }

        private Battle Battle { get; }

        public TacticalMap Map { get; }

        private Action<string> _logger;

        public Manager()
        {
            Map = new TacticalMap {PlayerShip = new Point(10, 10)};

            Battle = Data.Battle.Generator.GetBasicBattle(Logger);
        }

        public List<ICommand> GetCurrentTurnCommands()
        {
            return CurrentTurn.Commands.ToList();
        }

        public long GetSpacecraftId()
        {
            return Battle.Spacecraft.Id;
        }

        public void SetLogger(Action<string> logger)
        {
            _logger = logger;

            Logger("Add logger successful.");
        }

        private void Logger(string message)
        {
            _logger(" " + message);
        }

        public void EndTurn()
        {
            Battle.EndTurn(CurrentTurn.Commands);

            CurrentTurn = new Turn(Battle.CelestialObjects){Number = Battle.Turn};

            OnStartNewTurn?.Invoke(CurrentTurn);
        }

        public void FinishInitialization()
        {
            CurrentTurn = new Turn(Battle.CelestialObjects) { Number = Battle.Turn };

            OnStartNewTurn?.Invoke(CurrentTurn);
        }

        public bool AddCommand(ICommand command)
        {
            Logger($"[Manager] Add command to queue. Ship Id = {command.SpacecraftId}. Command {command.Description}");

            CurrentTurn.Commands.Add(command);

            OnChangeCommandsQueue?.Invoke();

            return true;
        }

    }
}
