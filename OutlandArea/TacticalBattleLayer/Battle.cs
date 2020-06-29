using System;
using System.Collections.Generic;

namespace OutlandArea.TacticalBattleLayer
{
    public class Battle
    {
        public Action<string> Logger;

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
            Turn = 1;
            State = State.Preparation;
            CelestialObjects = new List<ICelestialObject>();
        }
    }
}
