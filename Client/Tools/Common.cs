using System;
using System.Drawing;
using Engine.Configuration;

namespace Engine.Tools
{
    public class Common
    {
        public static Point MoveCelestialObjects(Point currentLocation, int speed, int angleInGraduses)
        {
            var angleInRadians = (angleInGraduses - 90) * (Math.PI) / 180; // (Math.PI / 180) * angleInGraduses;

            var x = (int)(currentLocation.X + speed * Math.Cos(angleInRadians));
            var y = (int)(currentLocation.Y + speed * Math.Sin(angleInRadians));

            return new Point(x, y);
        }

        public static bool IsEven(int a)
        {
            return (a % 2) == 0;
        }
        public static Point ToRelativeCoordinates(Point mouseLocation, Point centerPosition)
        {
            var relativeX = (mouseLocation.X - centerPosition.X);
            var relativeY = (mouseLocation.Y - centerPosition.Y);

            return new Point(relativeX, relativeY);
        }

        public static Point ToTacticalMapCoordinates(Point currentMouseCoordinates, Point centerPosition)
        {
            var relativeX = (centerPosition.X + currentMouseCoordinates.X);
            var relativeY = (centerPosition.Y + currentMouseCoordinates.Y);

            return new Point(relativeX, relativeY);
        }

        public static Point ToAbsoluteCoordinates(Point centerRadarLocation, Point centerPosition, Point celestialObjectPosition)
        {
            var relativeX = (celestialObjectPosition.X - centerRadarLocation.X);
            var relativeY = (celestialObjectPosition.Y - centerRadarLocation.Y);

            return new Point(centerPosition.X + relativeX, centerPosition.Y + relativeY);
        }

        

        
    }

    
}
