using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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

        public Point GetPlayerSpacecraftLocation()
        {
            foreach (var spacecraft in CelestialObjects.Where(celestialObject => celestialObject is BaseSpacecraft))
            {
                if (((BaseSpacecraft)spacecraft).IsPlayerSpacecraft)
                {
                    return spacecraft.Location;
                }
            }

            throw new Exception("Player spacecraft not found in battle celestial objects collection.");
        }
    }
}
