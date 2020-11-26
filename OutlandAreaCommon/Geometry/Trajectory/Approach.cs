using System.Collections.Generic;
using System.Drawing;
using OutlandAreaCommon.Geometry;

namespace Engine.Common.Geometry.Trajectory
{
    public class Approach
    {
        public static List<ObjectLocation> Calculate(PointF currentLocation, PointF targetLocation, double direction, double speed, int maxIterations = 2000)
        {
            const int agility = 5;

            var result = new List<ObjectLocation>();

            // In this case first iteration - start position for calculation.
            var previousIteration = new ObjectLocation
            {
                Distance = SpaceMapTools.GetDistance(targetLocation, currentLocation),
                Direction = direction,
                Status = MovementType.Default,
                Coordinates = new PointF(currentLocation.X, currentLocation.Y)
            };

            var currentStepInTurn = speed;

            for (var iteration = 0; iteration < maxIterations; iteration++)
            {
                var location = SpaceMapTools.Move(previousIteration.Coordinates.ToVector2(), 1, previousIteration.Direction);

                var iterationResult = new ObjectLocation
                {
                    Direction = previousIteration.Direction,
                    Iteration = iteration,
                    Coordinates = location.PointTo,
                    Distance = SpaceMapTools.GetDistance(targetLocation, location.PointTo)
                };

                // 0 - 360 degree 
                var attackAzimuth = SpaceMapTools.GetAngleBetweenPoints(location.PointTo.ToVector2(), targetLocation.ToVector2());
                // Turn angle
                var attackAngle = (int)SpaceMapTools.GetRotateDirection(iterationResult.Direction, attackAzimuth);

                var currentAgility = 0;

                if (speed == currentStepInTurn)
                {
                    currentAgility = agility;
                }

                currentStepInTurn++;

                if (currentStepInTurn > speed) currentStepInTurn = 0;

                switch (attackAngle)
                {
                    case var _ when attackAngle > 0:
                        // > 0 left turn
                        iterationResult.Direction -= currentAgility;
                        iterationResult.Status = MovementType.Turn;
                        break;

                    case var _ when attackAngle < 0:
                        // < 0 right turn
                        iterationResult.Direction += currentAgility;
                        iterationResult.Status = MovementType.Turn;
                        break;

                    case var _ when attackAngle == 0:
                        // = 0 forward
                        iterationResult.Status = MovementType.Linear;
                        break;
                }

                if (iterationResult.Distance >= 2)
                {
                    result.Add(iterationResult);
                }
                else
                {
                    result.Add(iterationResult);
                    break;
                }

                result.Add(iterationResult);

                previousIteration = iterationResult;
            }

            //result.Add(new ObjectLocation { Distance = 0, Direction = direction, Iteration = result.Count, Coordinates = targetLocation });

            return result;
        }
    }
}
