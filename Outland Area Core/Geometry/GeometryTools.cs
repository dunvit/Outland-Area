using System;
using System.Collections.Generic;
using System.Drawing;

namespace EngineCore.Geometry
{
    public class GeometryTools
    {
        public static PointF ToRelativeCoordinates(PointF mouseLocation, PointF centerPosition)
        {
            var relativeX = (mouseLocation.X - centerPosition.X);
            var relativeY = (mouseLocation.Y - centerPosition.Y);

            return new PointF(relativeX, relativeY);
        }

        public static PointF ToTacticalMapCoordinates(PointF currentMouseCoordinates, PointF centerPosition)
        {
            var relativeX = (centerPosition.X + currentMouseCoordinates.X);
            var relativeY = (centerPosition.Y + currentMouseCoordinates.Y);

            return new PointF(relativeX, relativeY);
        }

        public static PointF MoveObject(PointF currentLocation, double speed, double angleInGraduses)
        {
            var angleInRadians = (angleInGraduses - 90) * (Math.PI) / 180; // (Math.PI / 180) * angleInGraduses;

            var x = (float)(currentLocation.X + speed * Math.Cos(angleInRadians));
            var y = (float)(currentLocation.Y + speed * Math.Sin(angleInRadians));

            return new PointF(x, y);
        }

        public static double Distance(PointF p1, PointF p2)
        {
            double xDelta = p1.X - p2.X;
            double yDelta = p1.Y - p2.Y;

            return Math.Sqrt(Math.Pow(xDelta, 2) + Math.Pow(yDelta, 2));
        }

        public static double Azimuth(PointF destination, PointF center)
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

        public static List<PointF> GetRadiusPoint(PointF from, PointF to, int radius)
        {
            var results = new List<PointF>();

            var rotation = Azimuth(to, from);

            var firstPointDirection = rotation + 90;
            var secondPointDirection = rotation - 90;

            if (firstPointDirection > 360) firstPointDirection = firstPointDirection - 360;
            if (secondPointDirection < 0) secondPointDirection = 360 + secondPointDirection;

            var firstPointCoordinates = MoveObject(to, radius, firstPointDirection);
            var secondPointCoordinates = MoveObject(to, radius, secondPointDirection);

            var rotationLeft = Azimuth(from, firstPointCoordinates);
            var rotationRight = Azimuth(from, secondPointCoordinates);

            var distanceToFirstPoint = Distance(from, firstPointCoordinates);
            var distanceToSecondPoint = Distance(from, secondPointCoordinates);

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

        public static PointF GetCentreLine(PointF from, PointF to)
        {
            return GetCentreLine(new Line(from, to));
        }

        public static PointF GetCentreLine(Line line)
        {
            return new PointF( (line.To.X + line.From.X) / 2, (line.To.Y + line.From.Y) / 2);
        }

        public static bool IsLineIntersectCircle(PointF centre, float radius, Line line)
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
