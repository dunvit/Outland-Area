using System;
using System.Collections.Generic;
using OutlandArea.Tools;

namespace OutlandArea.Map
{
    [Serializable]
    public class CelestialMap
    {
        public string Id { get; set; }
        public int Turn { get; set; }
        public bool IsEnabled { get; set; }
        public List<ICelestialObject> CelestialObjects { get; set; } = new List<ICelestialObject>();

        public ICelestialObject GetPlayerSpaceShip()
        {
            foreach (var celestialObject in CelestialObjects)
            {
                // TODO: Add player space ship type
                if (celestialObject.Id == 5005)
                {
                    return celestialObject.DeepClone();
                }
            }

            return null;
        }

    }
}
