using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OutlandAreaXYZ
{
    public class RouteCalculator
    {
        public List<PointF> Execute(CelestialObject objectA, CelestialObject objectB, double orbitRadius)
        {

            var routeCalculator = new GenericCalculation
            {
                ObjectLocation = objectA.Location,
                ObjectAgility = objectA.Agility,
                ObjectDirection = objectA.Direction,
                TargetLocation = objectB.Location,
                Orbit = orbitRadius
            };

            var result = routeCalculator.Execute();

            return result;

        }
    }
}
