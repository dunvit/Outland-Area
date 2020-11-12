using System;
using System.Collections.Generic;
using System.Drawing;
using Engine.Layers.Tactical;
using Engine.Tools;


namespace Engine.Management.Server.DataProcessing
{
    public class Coordinates
    {
        //private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static Point MoveObject(Point currentLocation, int speed, double angleInGraduses)
        {
            var angleInRadians = (angleInGraduses - 90) * (Math.PI) / 180; // (Math.PI / 180) * angleInGraduses;

            var x = (int)(currentLocation.X + speed * Math.Cos(angleInRadians));
            var y = (int)(currentLocation.Y + speed * Math.Sin(angleInRadians));

            return new Point(x, y);
        }

        public static Point MoveObject(Point currentLocation, Point targetLocation, int speed)
        {
            float startX = currentLocation.X;
            float startY = currentLocation.Y;
            float endX = targetLocation.X;
            float endY = targetLocation.Y;
            
            float internalSpeed = speed;
            float elapsed = 0.01f;

            // On starting movement
            double distance = Math.Sqrt(Math.Pow(endX - startX, 2) + Math.Pow(endY - startY, 2));
            double directionX = (endX - startX) / distance;
            double directionY = (endY - startY) / distance;

            var x = startX + directionX * speed;// * elapsed;
            var y = startY + directionY * speed;// * elapsed;


            return new Point((int)x, (int)y);
        }

        public static PointF Vector(PointF from, PointF to, int speed)
        {
            float startX = from.X;
            float startY = from.Y;
            float endX = to.X;
            float endY = to.Y;

            float internalSpeed = speed;
            var elapsed = 0.01f;

            // On starting movement
            var distance = Math.Sqrt(Math.Pow(endX - startX, 2) + Math.Pow(endY - startY, 2));
            var directionX = (endX - startX) / distance;
            var directionY = (endY - startY) / distance;

            var x = (float) (startX + directionX * speed);// * elapsed;
            var y = (float) (startY + directionY * speed);// * elapsed;


            return new PointF(x, y);
        }

        public CelestialMap Recalculate(CelestialMap spaceMap)
        {
            var result = spaceMap.DeepClone();

            foreach (var celestialObject in result.CelestialObjects)
            {
                // TODO: Replace method to MoveObject from this class.
                var position = Common.MoveCelestialObjects(
                    new Point(celestialObject.PositionX, celestialObject.PositionY),
                    celestialObject.Speed, 
                    celestialObject.Direction);

                //Logger.Debug($"Object {celestialObject.Name} moved from {celestialObject.GetLocation()} to {position}");

                celestialObject.PositionX = position.X;
                celestialObject.PositionY = position.Y;
            }

            return result;
        }

        public static List<ObjectLocation> GetTrajectoryOrbit(Point currentLocation, Point targetLocation, double currentDirection, int speed, int iterations)
        {
            var result = GetTrajectoryApproach(currentLocation, targetLocation, currentDirection, speed, iterations);

            var previousIteration = result[result.Count - 1];

            ObjectLocation linearMotionStartPoint = null;

            // TODO: Orbit steps

            return result;
        }

        public static List<ObjectLocation> GetTrajectoryApproach(Point currentLocation, Point targetLocation, double currentDirection, int speed, int iterations)
        {
            var result = new List<ObjectLocation>();

            var initial = new ObjectLocation
            {
                Distance = GetDistance(targetLocation, currentLocation), 
                Direction = currentDirection,
                Coordinates = new Point(currentLocation.X, currentLocation.Y)
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
                    Coordinates = MoveObject(previousIteration.Coordinates, speed, previousIteration.Direction)
                };

                if (IsLinearMotion(iterationResult, targetLocation))
                {
                    var resultLinearMotion = new Trajectory.Line().Calculate(iterationResult.Coordinates, targetLocation, iterationResult.Direction, speed);

                    foreach (var objectLocation in resultLinearMotion)
                    {
                        result.Add(objectLocation);
                    }

                    return result;
                }

                
                iterationResult.Direction = GetRotationAngle(iterationResult.Coordinates, targetLocation, previousIteration.Direction, 5);
                iterationResult.IsLinearMotion = false;
                iterationResult.Distance = GetDistance(targetLocation, iterationResult.Coordinates);

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

            result.Add(new ObjectLocation { Distance  = 0, Direction = direction, IsLinearMotion = true, Iteration = result.Count, Coordinates = targetLocation});

            return result;
        }

        public static bool IsLinearMotion(ObjectLocation currentLocation, Point targetLocation)
        {
            if (currentLocation.IsLinearMotion)
                return true;

            var vectorToTarget = GetRotation(targetLocation, currentLocation.Coordinates);

            return ((int)Math.Abs(vectorToTarget - currentLocation.Direction) < 5);
        }

        

        public static double GetDistance(Point p1, Point p2)
        {
            double xDelta = p1.X - p2.X;
            double yDelta = p1.Y - p2.Y;

            return Math.Sqrt(Math.Pow(xDelta, 2) + Math.Pow(yDelta, 2));
        }

        public static double GetRotation(Point destination, Point center)
        {
            var relativeDestination = new Point(destination.X - center.X, destination.Y - center.Y);

            var cos = relativeDestination.Y / Math.Sqrt(relativeDestination.X * relativeDestination.X + relativeDestination.Y * relativeDestination.Y);

            var angle = Math.Acos(cos);

            if (relativeDestination.X > 0)
                angle = 2 * Math.PI - angle;

            var temp = ToDegrees(angle) + 180;

            if (temp >= 360)
            {
                temp -= 360;
            }

            return temp;
        }

        public static Point RotatePoint(Point centerPoint, int radius, double angleInDegrees)
        {
            var angleInRadians = (angleInDegrees - 90) * (Math.PI) / 180;

            var xOnCircle = centerPoint.X + radius * Math.Cos(angleInRadians);
            var yOnCircle = centerPoint.Y + radius * Math.Sin(angleInRadians);

            return new Point((int)xOnCircle, (int)yOnCircle);

        }


        public static double GetRotationAngle(Point currentLocation, Point destination, double direction, int directionDelta)
        {
            double newDirection;
            var isPositive = false;

            var baseRotation = GetRotation(destination, currentLocation);

            if (baseRotation == direction)
            {
                return direction;
            }

            if (Math.Abs(baseRotation - direction) < 5)
            {
                directionDelta = 1;
            }

            var positiveMinBorder = baseRotation;
            var positiveMaxBorder = baseRotation + 180;

            if (direction > positiveMinBorder && direction <= positiveMaxBorder)
            {
                isPositive = true;
            }

            if (positiveMaxBorder > 360)
            {
                if (direction > positiveMinBorder)
                {
                    isPositive = true;
                }

                if (direction < positiveMaxBorder - 360)
                {
                    isPositive = true;
                }
            }


            if (baseRotation == direction)
            {
                var a = "";
            }

            if (isPositive)
            {
                
                newDirection = direction - directionDelta;
            }
            else
            {
                newDirection = direction + directionDelta;
            }

            if (newDirection < 0)
            {
                newDirection = 360 + newDirection;
            }

            if (newDirection > 360)
            {
                newDirection = newDirection - 360;
            }

            return newDirection;
        }

        public static SortedDictionary<int, PointF> GetWayPoints(Point from, Point to, float steps)
        {
            var deltaX = (to.X - from.X) / steps;
            var deltaY = (to.Y - from.Y) / steps;

            var result = new SortedDictionary<int, PointF>();

            for (var i = 0; i <= steps; i++)
            {
                result.Add(i, new PointF(from.X + i * deltaX, from.Y + i * deltaY));
            }

            return result;
        }

        public static Orbit GetRadiusPoint(Point from, Point to, int radius, double direction, int speed)
        {
            var rotation = GetRotation(to, from);

            var firstPointDirection = rotation + 90;
            var secondPointDirection = rotation - 90;

            if (firstPointDirection > 360) firstPointDirection = firstPointDirection - 360;
            if (secondPointDirection < 0) secondPointDirection = 360 + secondPointDirection;

            var firstPointCoordinates = MoveObject(to, radius, firstPointDirection);
            var secondPointCoordinates = MoveObject(to, radius, secondPointDirection);

            var firstMovement = GetTrajectoryApproach(from, firstPointCoordinates, direction, speed, 200).Count;
            var secondMovement = GetTrajectoryApproach(from, secondPointCoordinates, direction, speed, 200).Count;

            if (firstMovement > secondMovement)
            {
                return new Orbit{StartPoint = new PointF(secondPointCoordinates.X, secondPointCoordinates.Y) , Direction = 1};
            }

            return new Orbit { StartPoint = new PointF(firstPointCoordinates.X, firstPointCoordinates.Y), Direction = -1 };
        }

        public static PointF GetRadiusPoint(Point from, Point to, int radius)
        {
            var rotation = GetRotation(to, from);

            var firstPointDirection = rotation + 90;
            var secondPointDirection = rotation - 90;

            if (firstPointDirection > 360) firstPointDirection = firstPointDirection - 360;
            if (secondPointDirection < 0) secondPointDirection = 360 + secondPointDirection;

            var firstPointCoordinates = MoveObject(to, radius, firstPointDirection);
            var secondPointCoordinates = MoveObject(to, radius, secondPointDirection);

            var rotationLeft = GetRotation(from, firstPointCoordinates);
            var rotationRight = GetRotation(from, secondPointCoordinates);

            var distanceToFirstPoint = GetDistance(from, firstPointCoordinates);
            var distanceToSecondPoint = GetDistance(from, secondPointCoordinates);

            if (rotationLeft < rotationRight)
            {
                return new PointF(secondPointCoordinates.X, secondPointCoordinates.Y);
            }

            return new PointF(firstPointCoordinates.X, firstPointCoordinates.Y);
        }


        private static double ToDegrees(double angle) => (angle * 180 / Math.PI);



        



    }
}
