using System.Collections.Generic;
using System.Drawing;
using EngineCore.DataProcessing;
using EngineCore.Geometry.Trajectory.Prototypes;

namespace EngineCore.Geometry.Trajectory
{
    public class Orbit
    {
        public static List<SpaceMapObjectLocation> Calculate(PointF location, PointF center, double direction, int maxIterations = 500)
        {
            const int radius = 30;
            var result = new List<SpaceMapObjectLocation>();

            var orbitInformation = SpaceMapTools.GetRadiusPoint(location, center, radius, direction);

            var orbitPoint = orbitInformation.StartLocation;
            var movementRotation = orbitInformation.Rotation;

            var distance = Coordinates.GetDistance(center, location);

            var previousIteration = new SpaceMapObjectLocation
            {
                Distance = Coordinates.GetDistance(center, location),
                Direction = direction,
                Status = MovementType.Orbit,
                Coordinates = new PointF(location.X, location.Y)
            };
            result.Add(previousIteration);

            // Here we on orbit of celestial object
            for (var iteration = 0; iteration < 500; iteration++)
            {
                var currentIteration = result[result.Count - 1];
                distance = Coordinates.GetDistance(center, currentIteration.Coordinates);


                float speedOrbit = 1;
                var directionDelta = 0;

                switch (movementRotation)
                {
                    case OrbitRotation.Right:
                        speedOrbit = 0.5f;
                        directionDelta = +90;
                        break;

                    case OrbitRotation.Left:
                        speedOrbit = -0.5f;
                        directionDelta = -90;
                        break;
                }

                var r = OrbitPrototype.Execute(center.ToVector2(), currentIteration.Coordinates.ToVector2(), speedOrbit, 1);

                var attackAzimuth = Coordinates.GetRotation(center, r.ToPointF()) + directionDelta;

                if (attackAzimuth < 0) attackAzimuth = 360 + attackAzimuth;
                if (attackAzimuth > 360) attackAzimuth = attackAzimuth - 360;


                result.Add(new SpaceMapObjectLocation
                {
                    Distance = distance,
                    Direction = attackAzimuth,
                    Iteration = result.Count,
                    Coordinates = r.ToPointF()
                });
            }

            return result;
        }
    }
}
