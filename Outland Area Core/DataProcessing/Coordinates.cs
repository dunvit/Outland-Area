using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using EngineCore.Geometry;
using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Objects;
using log4net;

namespace EngineCore.DataProcessing
{
    public class Coordinates
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static PointF MoveObject(PointF currentLocation, double speed, double angleInGraduses)
        {
            var angleInRadians = (angleInGraduses - 90) * (Math.PI) / 180; // (Math.PI / 180) * angleInGraduses;

            var x = (int)(currentLocation.X + speed * Math.Cos(angleInRadians));
            var y = (int)(currentLocation.Y + speed * Math.Sin(angleInRadians));

            return new PointF(x, y);
        }

        public static PointF MoveObject(PointF currentLocation, PointF targetLocation, int speed)
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


            return new PointF((int)x, (int)y);
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

        public GameSession Recalculate(GameSession gameSession, EngineSettings settings)
        {
            foreach (var celestialObject in gameSession.Data.CelestialObjects)
            {
                var speedInTick = celestialObject.Speed / settings.UnitsPerSecond;

                var position = SpaceMapTools.Move(
                    new PointF(celestialObject.PositionX, celestialObject.PositionY),
                    speedInTick,
                    celestialObject.Direction).PointTo;

                Logger.Debug($"Object '{celestialObject.Name}' id='{celestialObject.Id}' moved from {celestialObject.GetLocation()} to {position}");

                celestialObject.PreviousPositionX = celestialObject.PositionX;
                celestialObject.PreviousPositionY = celestialObject.PositionY;

                celestialObject.PositionX = position.X;
                celestialObject.PositionY = position.Y;
            }

            return gameSession;
        }

        public static bool IsLinearMotion(ObjectLocation currentLocation, PointF targetLocation)
        {
            if (currentLocation.IsLinearMotion)
                return true;

            var vectorToTarget = GetRotation(targetLocation, currentLocation.Coordinates);

            return ((int)Math.Abs(vectorToTarget - currentLocation.Direction) < 5);
        }

        

        public static double GetDistance(PointF p1, PointF p2)
        {
            double xDelta = p1.X - p2.X;
            double yDelta = p1.Y - p2.Y;

            return Math.Sqrt(Math.Pow(xDelta, 2) + Math.Pow(yDelta, 2));
        }

        public static double GetRotation(PointF destination, PointF center)
        {
            var relativeDestination = new PointF(destination.X - center.X, destination.Y - center.Y);

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

        public static PointF RotatePoint(PointF centerPoint, int radius, double angleInDegrees)
        {
            var angleInRadians = (angleInDegrees - 90) * (Math.PI) / 180;

            var xOnCircle = centerPoint.X + radius * Math.Cos(angleInRadians);
            var yOnCircle = centerPoint.Y + radius * Math.Sin(angleInRadians);

            return new PointF((int)xOnCircle, (int)yOnCircle);

        }


        public static double GetRotationAngle(PointF currentLocation, PointF destination, double direction, int directionDelta)
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

        public static SortedDictionary<int, PointF> GetWayPoints(PointF from, PointF to, float steps)
        {
            var deltaX = (to.X - from.X) / steps;
            var deltaY = (to.Y - from.Y) / steps;

            var result = new SortedDictionary<int, PointF>();

            for (var i = 0; i < steps; i++)
            {
                result.Add(i, new PointF(from.X + i * deltaX, from.Y + i * deltaY));
            }

            return result;
        }

        

        public static List<PointF> GetRadiusPoint(PointF from, PointF to, int radius)
        {
            var results = new List<PointF>();

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

            results.Add(new PointF(secondPointCoordinates.X, secondPointCoordinates.Y));

            results.Add(new PointF(firstPointCoordinates.X, firstPointCoordinates.Y));

            return results;
        }


        private static double ToDegrees(double angle) => (angle * 180 / Math.PI);



        private static PointF Cross(double a1, double b1, double c1, double a2, double b2, double c2)
        {
            return new PointF(
                (float)((b1 * c2 - b2 * c1) / (a1 * b2 - a2 * b1)),
                (float)((a2 * c1 - a1 * c2) / (a1 * b2 - a2 * b1))
                );
        }

        public static PointF GetCrossLineToLinePoint(Line line1, Line line2)
        {
            var pABDot1 = line1.From;
            var pABDot2 = line1.To;

            var pCDDot1 = line2.From;
            var pCDDot2 = line2.To;

            double a1 = pABDot2.Y - pABDot1.Y;
            double b1 = pABDot1.X - pABDot2.X;
            double c1 = -pABDot1.X * pABDot2.Y + pABDot1.Y * pABDot2.X;

            double a2 = pCDDot2.Y - pCDDot1.Y;
            double b2 = pCDDot1.X - pCDDot2.X;
            double c2 = -pCDDot1.X * pCDDot2.Y + pCDDot1.Y * pCDDot2.X;

            if ((a1 * b2 - a2 * b1) == 0)
            {

                return PointF.Empty;
            }

            var pCross = Cross(a1, b1, c1, a2, b2, c2);

            if ((a1 * a2 + b1 * b2) == 0)
            {

                return pCross;
            }

            return pCross;

        }

        public static PointF GetCentrePoint(PointF from, PointF to)
        {
            return GetCentrePoint(new Line(from, to));
        }

        public static PointF GetCentrePoint(Line line)
        {
            return new PointF( (line.To.X + line.From.X) / 2, (line.To.Y + line.From.Y) / 2);
        }

        public static bool FindLineCircleIntersections(PointF centre, float radius, Line line)
        {
            float dx, dy, A, B, C, det, t;

            dx = line.To.X - line.From.X;
            dy = line.To.Y - line.From.Y;

            A = dx * dx + dy * dy;
            B = 2 * (dx * (line.From.X - centre.X) + dy * (line.From.Y - centre.Y));
            C = (line.From.X - centre.X) * (line.From.X - centre.X) +
                (line.From.Y - centre.Y) * (line.From.Y - centre.Y) -
                radius * radius;

            det = B * B - 4 * A * C;
            if ((A <= 0.0000001) || (det < 0))
            {
                // No real solutions.
                //intersection1 = new PointF(float.NaN, float.NaN);
                //intersection2 = new PointF(float.NaN, float.NaN);
                return false;
            }

            if (det == 0)
            {
                // One solution.
                //t = -B / (2 * A);
                //intersection1 = new PointF(line.From.X + t * dx, line.From.Y + t * dy);
                //intersection2 = new PointF(float.NaN, float.NaN);
                return true;
            }

            // Two solutions.
            //t = (float)((-B + Math.Sqrt(det)) / (2 * A));
            //intersection1 = new PointF(line.From.X + t * dx, line.From.Y + t * dy);
            //t = (float)((-B - Math.Sqrt(det)) / (2 * A));
            //intersection2 = new PointF(line.From.X + t * dx, line.From.Y + t * dy);
            return true;
        }
    }
}
