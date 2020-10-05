using System;
using System.Collections.Generic;
using System.Drawing;
using OutlandArea.Map;
using OutlandArea.Tools;

namespace OutlandArea.BL.Data.Calculation
{
    public class Coordinates
    {
        public static Point MoveObject(Point currentLocation, int speed, int angleInGraduses)
        {
            var angleInRadians = (angleInGraduses - 90) * (Math.PI) / 180; // (Math.PI / 180) * angleInGraduses;

            var x = (int)(currentLocation.X + speed * Math.Cos(angleInRadians));
            var y = (int)(currentLocation.Y + speed * Math.Sin(angleInRadians));

            return new Point(x, y);
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
            var previousIterationDirection = currentDirection;
            var previousIterationDistance = GetDistance(targetLocation, currentLocation);

            for (var iteration = 0; iteration < iterations; iteration++)
            {
                if (previousIterationDistance > 10)
                {
                    var iterationResult = RecalculateLocation(previousIterationLocation, targetLocation, previousIterationDirection, speed);

                    previousIterationLocation = iterationResult.Coordinates;
                    previousIterationDirection = iterationResult.Direction;
                    previousIterationDistance = iterationResult.Distance;
                
                    result.Add(iterationResult);
                }
                
            }

            return result;
        }

        public static ObjectLocation RecalculateLocation(Point currentLocation, Point targetLocation, int currentDirection, int speed)
        {
            var distance = GetDistance(targetLocation, currentLocation);

            var iterationObjectLocation = new ObjectLocation {Distance = distance};

            var vectorToTarget = GetRotation(targetLocation, currentLocation);

            iterationObjectLocation.Direction = currentDirection;

            if (vectorToTarget != currentDirection)
            {
                iterationObjectLocation.Direction = GetRotationAngle(currentLocation, targetLocation, currentDirection, 5);
            }

            iterationObjectLocation.Coordinates = Common.MoveCelestialObjects(new Point(currentLocation.X, currentLocation.Y), speed, iterationObjectLocation.Direction);

            return iterationObjectLocation;
        }

        public static double GetDistance(Point p1, Point p2)
        {
            double xDelta = p1.X - p2.X;
            double yDelta = p1.Y - p2.Y;

            return Math.Sqrt(Math.Pow(xDelta, 2) + Math.Pow(yDelta, 2));
        }

        public static int GetRotation(Point destination, Point center)
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

        public static int GetRotationAngle(Point currentLocation, Point destination, int direction, int directionDelta)
        {
            int newDirection;
            var isPositive = false;

            var baseRotation = GetRotation(destination, currentLocation);

            if (baseRotation == direction)
            {
                return direction;
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



        private static int ToDegrees(double Angle) => (int)(Angle * 180 / Math.PI);
    }
}
