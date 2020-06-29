using System.Collections.Generic;

namespace OutlandArea.TacticalBattleLayer
{
    public class Turn
    {
        public int Number { get; set; }

        public bool IsFinished { get; set; }

        public List<ICommand> Commands { get; set; } = new List<ICommand>();

        public List<ICelestialObject> CelestialObjects { get; }

        public Turn(List<ICelestialObject> celestialObjects)
        {
            CelestialObjects = celestialObjects;
        }
    }
}
