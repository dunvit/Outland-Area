using System.Collections.Generic;
using System.Drawing;

namespace Engine.Management.Server.DataProcessing.Trajectory
{
    public class Line
    {
        public List<ObjectLocation> Calculate(Point from, Point to, double direction, int speed, int maxIterations = 200)
        {
            var result = new List<ObjectLocation>();

            var previousIteration = new ObjectLocation{
                Direction = direction, 
                Coordinates = from, 
                Point = new PointF(from.X, from.Y), 
                Iteration = 0, IsLinearMotion = true};

            for (var iteration = 1; iteration < maxIterations; iteration++)
            {
                var iterationResult = new ObjectLocation
                {
                    IsLinearMotion = true,
                    Direction = direction,
                    Iteration = iteration,
                    Coordinates = Coordinates.MoveObject(from, to, iteration * speed),
                    Point = Coordinates.Vector(previousIteration.Point, to, speed)
                };

                iterationResult.Distance = Coordinates.GetDistance(to, iterationResult.Coordinates);

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

            return result;
        }
    }
}
