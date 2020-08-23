using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandArea.Map
{
    public class CelestialMap
    {
        public string Id { get; set; }
        public List<ICelestialObject> CelestialObjects { get; set; } = new List<ICelestialObject>();

        public void UpdateCelestialObjects(ICelestialObject replacedCelestialObject)
        {
            var isNeedAddToCelestialObjects = true;

            foreach (var celestialObject in CelestialObjects)
            {
                if (celestialObject.Name == replacedCelestialObject.Name)
                {
                    celestialObject.PositionX = celestialObject.PositionX;
                    celestialObject.PositionY = celestialObject.PositionY;

                    isNeedAddToCelestialObjects = false;
                }
               
            }

            if (isNeedAddToCelestialObjects)
            {
                CelestialObjects.Add(replacedCelestialObject);
            }
        }
    }
}
