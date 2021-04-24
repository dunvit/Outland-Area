using System;
using System.Drawing;
using System.Numerics;

namespace EngineCore.Geometry
{
    public static class Extensions
    {
        public static Vector2 ToVector2(this PointF point)
        {
            return new Vector2(point.X, point.Y);
        }

        public static Vector2 ToVector2(this Point point)
        {
            return new Vector2(point.X, point.Y);
        }

        public static Point ToPoint(this Vector2 point)
        {
            return new Point((int)point.X, (int)point.Y);
        }

        public static PointF ToPointF(this Vector2 point)
        {
            return new PointF(point.X, point.Y);
        }



        public static PointF ToPointF(this Point point)
        {
            return new PointF(point.X, point.Y);
        }

        public static double ToDegrees(this double angle) => (angle * 180 / Math.PI);

        public static double To360Degrees(this double angle)
        {
            if (angle > 360) angle = angle - 360;
            if (angle < 0) angle = 360 + angle;

            return angle;
        }
    }
}
