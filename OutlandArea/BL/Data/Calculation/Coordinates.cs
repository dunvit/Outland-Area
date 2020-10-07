using System;
using System.Collections.Generic;
using System.Drawing;
using OutlandArea.Map;
using OutlandArea.Tools;

namespace OutlandArea.BL.Data.Calculation
{
    public class Coordinates
    {
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

        public CelestialMap Recalculate(CelestialMap spaceMap)
        {
            var result = spaceMap.DeepClone();

            //var random = new Random((int)DateTime.UtcNow.Ticks);

            foreach (var celestialObject in result.CelestialObjects)
            {
                var position = Common.MoveCelestialObjects(
                    new Point(celestialObject.PositionX, celestialObject.PositionY),
                    celestialObject.Speed, 
                    celestialObject.Direction);

                celestialObject.PositionX = position.X;
                celestialObject.PositionY = position.Y;
            }

            return result;
        }

        public static List<ObjectLocation> GetTrajectoryApproach(Point currentLocation, Point targetLocation, int currentDirection, int speed, int iterations)
        {
            var result = new List<ObjectLocation>();

            var previousIterationLocation = currentLocation;
            double previousIterationDirection = currentDirection;
            var previousIterationDistance = GetDistance(targetLocation, currentLocation);

            var initial = new ObjectLocation
            {
                Distance = GetDistance(targetLocation, currentLocation), Direction = currentDirection
            };

            initial.Coordinates = MoveObject(new Point(currentLocation.X, currentLocation.Y), speed, initial.Direction);

            result.Add(initial);

            ObjectLocation previousIterationResult = null;

            ObjectLocation linearMotionStartPoint = null;

            for (var iteration = 0; iteration < iterations; iteration++)
            {
                


                if (previousIterationDistance > 10)
                {

                    ObjectLocation iterationResult;

                    if (previousIterationResult != null && previousIterationResult.IsLinearMotion)
                    {
                        //Linear motion 
                        iterationResult = new ObjectLocation
                        {
                            IsLinearMotion = true,
                            Direction = previousIterationResult.Direction,
                            VectorToTarget = previousIterationResult.VectorToTarget
                        };

                        //var oldCoordinatesCalculation = MoveObject(previousIterationResult.Coordinates, speed, previousIterationResult.Direction);

                        //iterationResult.Coordinates = MoveObject(previousIterationResult.Coordinates, targetLocation, speed);

                        iterationResult.Coordinates = MoveObject(linearMotionStartPoint.Coordinates, targetLocation, 
                            (iteration - linearMotionStartPoint.Iteration) * speed);

                        iterationResult.Iteration = iteration;
                        iterationResult.Distance = GetDistance(targetLocation, iterationResult.Coordinates);
                    }
                    else
                    {
                        //Rotate motion
                        iterationResult = RecalculateLocation(previousIterationLocation, targetLocation, previousIterationDirection, speed);

                        iterationResult.Iteration = iteration;

                        if (iterationResult.IsLinearMotion)
                        {
                            linearMotionStartPoint = iterationResult;
                        }
                    }

                    

                    result.Add(iterationResult);

                    

                    previousIterationLocation = iterationResult.Coordinates;
                    previousIterationDirection = iterationResult.Direction;
                    previousIterationDistance = iterationResult.Distance;
                    previousIterationResult = iterationResult;
                }

                

            }

            return result;
        }

        public static ObjectLocation RecalculateLocation(Point currentLocation, Point targetLocation, double currentDirection, int speed)
        {
            var distance = GetDistance(targetLocation, currentLocation);

            var vectorToTarget = GetRotation(targetLocation, currentLocation);

            var iterationObjectLocation = new ObjectLocation
            {
                Distance = distance, 
                VectorToTarget = vectorToTarget, 
                Direction = currentDirection,
                Coordinates = currentLocation,
                IsLinearMotion = false
            };

            if ((int)vectorToTarget != (int)currentDirection)
            {
                iterationObjectLocation.Direction = GetRotationAngle(currentLocation, targetLocation, currentDirection, 5);
            }
            else
            {
                iterationObjectLocation.IsLinearMotion = true;
            }
            
            iterationObjectLocation.Coordinates = MoveObject(new Point(currentLocation.X, currentLocation.Y), speed, iterationObjectLocation.Direction);

            return iterationObjectLocation;
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



        private static double ToDegrees(double angle) => (angle * 180 / Math.PI);
    }
}
