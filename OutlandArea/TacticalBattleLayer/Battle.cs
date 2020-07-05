using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OutlandArea.Tools;

namespace OutlandArea.TacticalBattleLayer
{
    public class Battle
    {
        public Action<string> Logger;

        public event Action OnChangeInformation;

        public int Turn { get; private set; }

        public State State { get; private set; }

        public ICelestialObject Spacecraft { get; private set; }

        public List<ICelestialObject> CelestialObjects { get; private set; }

        public Battle()
        {
            Initialization();
        }

        private void Initialization()
        {
            Turn = 0;
            State = State.Preparation;
            CelestialObjects = new List<ICelestialObject>();
        }

        public void InitializationCoreSpacecraft(ICelestialObject spacecraft)
        {
            Spacecraft = spacecraft;
        }
        public void AddCelestialObjects(ICelestialObject celestialObject)
        {
            CelestialObjects.Add(celestialObject);
        }

        internal void EndTurn(List<ICommand> commands)
        {
            if (Turn > 0)
            {
                RecalculateCelestialObjectsPositions(commands);

                Logger?.Invoke($"[Battle] End turn. New turn is {Turn}");
            }
            else
            {
                Logger?.Invoke("[Battle] Everything is prepared to start the battle.");
            }

            Turn++;

            OnChangeInformation?.Invoke();
        }

        private void RecalculateCelestialObjectsPositions(List<ICommand> commands)
        {
            foreach (var spacecraft in CelestialObjects.Where(celestialObject => celestialObject is BaseSpacecraft))
            {
                spacecraft.LocationInLastTurn = spacecraft.Location;

                spacecraft.Location = Common.MoveCelestialObjects(spacecraft.Location, spacecraft.Velocity / 10, spacecraft.Direction);

                Logger?.Invoke($"[Battle] Spacecraft id='{spacecraft.Id}' moved from ({spacecraft.LocationInLastTurn.X},{spacecraft.LocationInLastTurn.Y}) to ({spacecraft.Location.X},{spacecraft.Location.Y})");
            }
        }

        
    }
}
