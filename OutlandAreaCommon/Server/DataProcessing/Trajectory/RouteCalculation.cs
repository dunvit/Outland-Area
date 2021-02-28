using System.Collections.Generic;
using System.Drawing;

namespace OutlandAreaCommon.Server.DataProcessing.Trajectory
{
    public class RouteCalculation
    {
        public List<ObjectLocation> Execute(Point currentLocation, Point targetLocation, double currentDirection, int speed, int iterations)
        {
            var result = new List<ObjectLocation>();

            //var initial = new SpaceMapObjectLocation
            //{
            //    ScanRange = Coordinates.GetDistance(targetLocation, currentLocation),
            //    Direction = currentDirection,
            //    Coordinates = new Point(currentLocation.X, currentLocation.Y)
            //};

            //result.Add(initial);

            //var previousIteration = initial;

            //SpaceMapObjectLocation linearMotionStartPoint = null;

            //var direction = currentDirection;

            //for (var iteration = 0; iteration < iterations; iteration++)
            //{
            //    var iterationResult = new SpaceMapObjectLocation
            //    {
            //        IsLinearMotion = previousIteration.IsLinearMotion,
            //        Direction = previousIteration.Direction,
            //        VectorToTarget = previousIteration.VectorToTarget,
            //        Iteration = iteration,
            //        Coordinates = Coordinates.MoveObject(previousIteration.Coordinates, speed, previousIteration.Direction)
            //    };

            //    if (Coordinates.IsLinearMotion(iterationResult, targetLocation))
            //    {
            //        var resultLinearMotion = new Trajectory.Line().Calculate(iterationResult.Coordinates, targetLocation, iterationResult.Direction, speed);

            //        foreach (var objectLocation in resultLinearMotion)
            //        {
            //            result.Add(objectLocation);
            //        }

            //        return result;
            //    }


            //    iterationResult.Direction = Coordinates.GetRotationAngle(iterationResult.Coordinates, targetLocation, previousIteration.Direction, 5);
            //    iterationResult.IsLinearMotion = false;
            //    iterationResult.ScanRange = Coordinates.GetDistance(targetLocation, iterationResult.Coordinates);

            //    direction = iterationResult.Direction;

            //    if (iterationResult.ScanRange >= speed)
            //    {
            //        result.Add(iterationResult);
            //    }
            //    else
            //    {
            //        result.Add(iterationResult);
            //        break;
            //    }

            //    previousIteration = iterationResult;
            //}

            //result.Add(new SpaceMapObjectLocation { ScanRange = 0, Direction = direction, IsLinearMotion = true, Iteration = result.Count, Coordinates = targetLocation });

            return result;
        }
    }
}
