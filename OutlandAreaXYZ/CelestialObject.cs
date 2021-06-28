using System.Collections.Generic;
using System.Drawing;
using LanguageExt;

namespace OutlandAreaXYZ
{
    public class CelestialObject
    {
        public float Direction { get; set; } // Direction from 0 to 360 degrees. 0 - North,  90 - East, 180 - South, 270 - West

        public float Speed { get; set; } // Pixels in second

        public float Agility { get; set; } // Pixels in second

        public PointF Location { get; set; }
    }

    public class OrbitRouteCalculator
    {
        public List<PointF> Execute(CelestialObject objectA, CelestialObject objectB, double orbitRadius)
        {
            // Here route calculation
            return new List<PointF>();
        }
    }
}
