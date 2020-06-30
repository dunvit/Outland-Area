using System;
using System.Collections.Generic;

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

        internal void EndTurn()
        {
            Turn++;

            RecalculateCelestialObjectsPositions();

            Logger?.Invoke($"[Battle] End turn. New turn is {Turn}");

            OnChangeInformation?.Invoke();
        }

        private void RecalculateCelestialObjectsPositions()
        {
            foreach (var item in CelestialObjects)
            {

            }
        }
    }
}
