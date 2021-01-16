using System;
using System.Drawing;

namespace OutlandAreaCommon
{
    public class Tools
    {
        private static readonly Random RandomBase = new Random();

        public static double Randomize(double minimum, double maximum)
        {
            return RandomBase.NextDouble() * (maximum - minimum) + minimum;
        }

        public static int RandomizeInt(int minimum, int maximum)
        {
            return RandomBase.Next(minimum, maximum);
        }

        public static double RandomizeDice100()
        {
            return RandomBase.NextDouble() * 100;
        }

        public static PointF MoveCelestialObjects(PointF currentLocation, int speed, double angleInGraduses)
        {
            var angleInRadians = (angleInGraduses - 90) * (Math.PI) / 180; // (Math.PI / 180) * angleInGraduses;

            var x = (int)(currentLocation.X + speed * Math.Cos(angleInRadians));
            var y = (int)(currentLocation.Y + speed * Math.Sin(angleInRadians));

            return new PointF(x, y);
        }

        public static bool IsEven(int a)
        {
            return (a % 2) == 0;
        }
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

        public static PointF ToAbsoluteCoordinates(PointF centerRadarLocation, PointF centerPosition, PointF celestialObjectPosition)
        {
            var relativeX = (celestialObjectPosition.X - centerRadarLocation.X);
            var relativeY = (celestialObjectPosition.Y - centerRadarLocation.Y);

            return new PointF(centerPosition.X + relativeX, centerPosition.Y + relativeY);
        }

        

        
    }

    
}
