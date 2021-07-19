using System;
using System.Collections.Generic;
using System.Drawing;
using EngineCore.DataProcessing;

namespace EngineCore.Geometry.Trajectory
{
    public class Approach
    {
        public static Result Calculate(PointF currentLocation, PointF targetLocation, double direction, double speed, int maxIterations = 2000)
        {
            const int agility = 5;

            var result = new Result();

            // In this case first iteration - start position for calculation.
            var previousIteration = new SpaceMapObjectLocation
            {
                Distance = Coordinates.GetDistance(targetLocation, currentLocation),
                Direction = direction,
                Status = MovementType.Default,
                Coordinates = new PointF(currentLocation.X, currentLocation.Y)
            };

            var currentStepInTurn = speed;

            for (var iteration = 0; iteration < maxIterations; iteration++)
            {
                var location = Coordinates.MoveObject(previousIteration.Coordinates, 1, previousIteration.Direction);

                var iterationResult = new SpaceMapObjectLocation
                {
                    Direction = previousIteration.Direction,
                    Iteration = iteration,
                    Coordinates = location,
                    Distance = Coordinates.GetDistance(targetLocation, location)
                };

                // 0 - 360 degree 
                var attackAzimuth = Coordinates.GetRotation(location, targetLocation);
                // Turn angle
                var attackAngle = Coordinates.GetRotateDirection(iterationResult.Direction, attackAzimuth);

                var currentAgility = 0;

                if ((int)speed == (int)currentStepInTurn)
                {
                    currentAgility = agility;

                    if (Math.Abs(attackAngle) < agility)
                    {
                        attackAngle = 0;
                        iterationResult.Direction = attackAzimuth;
                    }
                }

                currentStepInTurn++;

                if (currentStepInTurn > speed) currentStepInTurn = 0;

                switch (attackAngle)
                {
                    case var _ when attackAngle > 1:
                        // > 0 left turn
                        iterationResult.Direction -= currentAgility;
                        iterationResult.Status = MovementType.Turn;
                        break;

                    case var _ when attackAngle < -1:
                        // < 0 right turn
                        iterationResult.Direction += currentAgility;
                        iterationResult.Status = MovementType.Turn;
                        break;

                    case var _ when attackAngle == 0:
                        // = 0 forward
                        iterationResult.Status = MovementType.Linear;
                        break;
                    case var _ when attackAngle == 1:
                        // = 0 forward
                        iterationResult.Status = MovementType.Linear;
                        break;
                }

                if (iterationResult.Distance >= 2)
                {
                    result.Trajectory.Add(iterationResult);
                }
                else
                {
                    result.Trajectory.Add(iterationResult);
                    break;
                }

                iterationResult.Direction = iterationResult.Direction.To360Degrees();

                result.Trajectory.Add(iterationResult);

                previousIteration = iterationResult;

                if (iterationResult.Status == MovementType.Linear)
                {
                    var linearIteration = 0;

                    foreach (var points in LinearMovement(iterationResult.Coordinates, targetLocation))
                    {
                        linearIteration++;

                        result.Trajectory.Add(new SpaceMapObjectLocation
                        {
                            Coordinates = points,
                            Distance = Coordinates.GetDistance(targetLocation, points),
                            Direction = iterationResult.Direction.To360Degrees(),
                            Status = MovementType.Linear,
                            Iteration = iterationResult.Iteration + linearIteration
                        });
                    }

                    break;
                }
            }


            return result;
        }

        public static List<PointF> LinearMovement(PointF currentLocation, PointF targetLocation)
        {
            var result = new List<PointF>();

            var distance = Coordinates.GetDistance(currentLocation, targetLocation);

            for (var i = 0; i < distance; i++)
            {
                var x = (float) (currentLocation.X * (1 - (i / distance)) + targetLocation.X * (i / distance));
                var y = (float) (currentLocation.Y * (1 - (i / distance)) + targetLocation.Y * (i / distance));

                result.Add(new PointF(x, y));
            }

            return result;
        }

        public static List<SpaceMapObjectLocation> CalculateIteration(PointF currentLocation, PointF targetLocation, double direction, double speed, int maxIterations = 2000)
        {
            const int agility = 5;

            var result = new List<SpaceMapObjectLocation>();

            // In this case first iteration - start position for calculation.
            var previousIteration = new SpaceMapObjectLocation
            {
                Distance = Coordinates.GetDistance(targetLocation, currentLocation),
                Direction = direction,
                Status = MovementType.Default,
                Coordinates = new PointF(currentLocation.X, currentLocation.Y)
            };

            var currentStepInTurn = speed;

            for (var iteration = 0; iteration < maxIterations; iteration++)
            {
                var location = Coordinates.MoveObject(previousIteration.Coordinates, 1, previousIteration.Direction);

                var iterationResult = new SpaceMapObjectLocation
                {
                    Direction = previousIteration.Direction,
                    Iteration = iteration,
                    Coordinates = location,
                    Distance = Coordinates.GetDistance(targetLocation, location)
                };

                // 0 - 360 degree 
                var attackAzimuth = Coordinates.GetRotation(location, targetLocation);
                // Turn angle
                var attackAngle = (int)Coordinates.GetRotateDirection(iterationResult.Direction, attackAzimuth);

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

            //result.Add(new SpaceMapObjectLocation { ScanRange = 0, Direction = direction, Iteration = result.Count, Coordinates = targetLocation });

            return result;
        }
    }
}
