using System.Collections.Generic;
using System.Drawing;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Server.DataProcessing.Trajectory;

namespace Engine.Management.Server
{
    public class AllIn
    {
        public static List<ObjectLocation> GetTrajectoryApproach(PointF currentLocation, PointF targetLocation, double currentDirection, int speed, int iterations)
        {
            var result = new List<ObjectLocation>();

            var initial = new ObjectLocation
            {
                Distance = Coordinates.GetDistance(targetLocation, currentLocation),
                Direction = currentDirection,
                Coordinates = new PointF(currentLocation.X, currentLocation.Y)
            };

            result.Add(initial);

            var previousIteration = initial;

            ObjectLocation linearMotionStartPoint = null;

            var direction = currentDirection;

            for (var iteration = 0; iteration < iterations; iteration++)
            {
                var iterationResult = new ObjectLocation
                {
                    IsLinearMotion = previousIteration.IsLinearMotion,
                    Direction = previousIteration.Direction,
                    VectorToTarget = previousIteration.VectorToTarget,
                    Iteration = iteration,
                    Coordinates = Coordinates.MoveObject(previousIteration.Coordinates, speed, previousIteration.Direction)
                };

                if (Coordinates.IsLinearMotion(iterationResult, targetLocation))
                {
                    var resultLinearMotion = new Line().Calculate(iterationResult.Coordinates, targetLocation, iterationResult.Direction, speed);

                    foreach (var objectLocation in resultLinearMotion)
                    {
                        result.Add(objectLocation);
                    }

                    return result;
                }


                iterationResult.Direction = Coordinates.GetRotationAngle(iterationResult.Coordinates, targetLocation, previousIteration.Direction, 5);
                iterationResult.IsLinearMotion = false;
                iterationResult.Distance = Coordinates.GetDistance(targetLocation, iterationResult.Coordinates);

                direction = iterationResult.Direction;

                if (iterationResult.Distance >= speed)
                {
                    result.Add(iterationResult);
                }
                else
                {
                    result.Add(iterationResult);
                    break;
                }

                previousIteration = iterationResult;
            }

            result.Add(new ObjectLocation { Distance = 0, Direction = direction, IsLinearMotion = true, Iteration = result.Count, Coordinates = targetLocation });

            return result;
        }

        public static List<ObjectLocation> GetTrajectoryOrbit(PointF currentLocation, PointF targetLocation, double currentDirection, int speed, int iterations)
        {
            var result = GetTrajectoryApproach(currentLocation, targetLocation, currentDirection, speed, iterations);

            var previousIteration = result[result.Count - 1];

            ObjectLocation linearMotionStartPoint = null;

            // TODO: Orbit steps

            return result;
        }

        public static Orbit GetRadiusPoint(PointF from, PointF to, int radius, double direction, int speed)
        {
            var rotation = Coordinates.GetRotation(to, from);

            var firstPointDirection = rotation + 90;
            var secondPointDirection = rotation - 90;

            if (firstPointDirection > 360) firstPointDirection = firstPointDirection - 360;
            if (secondPointDirection < 0) secondPointDirection = 360 + secondPointDirection;

            var firstPointCoordinates = Coordinates.MoveObject(to, radius, firstPointDirection);
            var secondPointCoordinates = Coordinates.MoveObject(to, radius, secondPointDirection);

            var firstMovement = GetTrajectoryApproach(from, firstPointCoordinates, direction, speed, 200).Count;
            var secondMovement = GetTrajectoryApproach(from, secondPointCoordinates, direction, speed, 200).Count;

            if (firstMovement > secondMovement)
            {
                return new Orbit { StartPoint = new PointF(secondPointCoordinates.X, secondPointCoordinates.Y), Direction = 1 };
            }

            return new Orbit { StartPoint = new PointF(firstPointCoordinates.X, firstPointCoordinates.Y), Direction = -1 };
        }
    }
}
