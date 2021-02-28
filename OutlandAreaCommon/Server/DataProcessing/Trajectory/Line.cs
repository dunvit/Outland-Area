using System.Collections.Generic;
using System.Drawing;

namespace OutlandAreaCommon.Server.DataProcessing.Trajectory
{
    public class Line
    {
        public List<ObjectLocation> Calculate(PointF from, PointF to, double direction, int speed, int maxIterations = 200)
        {
            var result = new List<ObjectLocation>();

            //var previousIteration = new SpaceMapObjectLocation{
            //    Direction = direction, 
            //    Coordinates = from, 
            //    Point = new PointF(from.X, from.Y), 
            //    Iteration = 0, IsLinearMotion = true};

            //for (var iteration = 1; iteration < maxIterations; iteration++)
            //{
            //    var iterationResult = new SpaceMapObjectLocation
            //    {
            //        IsLinearMotion = true,
            //        Direction = direction,
            //        Iteration = iteration,
            //        Coordinates = Coordinates.MoveObject(from, to, iteration * speed),
            //        Point = Coordinates.Vector(previousIteration.Point, to, speed)
            //    };

            //    iterationResult.ScanRange = Coordinates.GetDistance(to, iterationResult.Coordinates);

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

            return result;
        }
    }
}
