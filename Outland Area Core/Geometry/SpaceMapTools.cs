using System;
using System.Drawing;
using System.Numerics;
using EngineCore.Geometry.Trajectory;

namespace EngineCore.Geometry
{
    public class SpaceMapTools
    {
        #region Move
        public static SpaceMapVector Move(Vector2 from, int speed, double angle)
        {
            var angleInRadians = (angle - 90) * (Math.PI) / 180; 

            var x = (float)(from.X + speed * Math.Cos(angleInRadians));
            var y = (float)(from.Y + speed * Math.Sin(angleInRadians));

            return new SpaceMapVector(new PointF(from.X, from.Y), new PointF(x, y), angle);
        }

        public static SpaceMapVector Move(PointF from, int speed, double angle)
        {
            return Move(new Vector2(from.X, from.Y), speed, angle);
        }

        public static SpaceMapVector Move(Vector2 from, int speed, int offset, double angle)
        {
            var offsetVector = Move(from, offset, angle);

            return Move(offsetVector.PointTo.ToVector2(), speed, angle);
        }

        public static SpaceMapVector Move(PointF from, int speed, int offset, double angle)
        {
            var offsetVector = Move(from, offset, angle);

            return Move(offsetVector.PointTo.ToVector2(), speed, angle);
        }
        #endregion

        #region GetAngleBetweenPoints
        public static double GetAngleBetweenPoints(Vector2 destination, Vector2 center)
        {
            return GetAngleBetweenPoints(destination.ToPointF(), center.ToPointF());
        }

        public static double GetAngleBetweenPoints(PointF pointTo, PointF pointCenter)
        {
            var destination = new PointF(pointTo.X - pointCenter.X, pointTo.Y - pointCenter.Y);

            var cos = destination.Y / Math.Sqrt(destination.X * destination.X + destination.Y * destination.Y);

            var angle = Math.Acos(cos);

            if (destination.X > 0)
                angle = 2 * Math.PI - angle;

            var degrees = angle.ToDegrees();

            if (degrees >= 360)
            {
                degrees -= 360;
            }


            return degrees;
        }
        #endregion

        #region GetRotateDirection

        /// <summary>
        /// Positive speed means CW around the center, negative means CCW.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="azimuth"></param>
        /// <returns></returns>
        public static double GetRotateDirection(double direction, double azimuth)
        {
            var angle = direction - azimuth;

            if (angle > 180)
            {
                angle = angle - 360;
            }

            if (angle < -180)
            {
                angle = 360 + angle;
            }

            return angle;
        }
        #endregion

        #region GetDistance
        public static double GetDistance(PointF p1, PointF p2)
        {
            double xDelta = p1.X - p2.X;
            double yDelta = p1.Y - p2.Y;

            return Math.Sqrt(Math.Pow(xDelta, 2) + Math.Pow(yDelta, 2));
        }
        #endregion


        public static PointF GetTangentPointCoordinate(double X, double Y, double Xo, double Yo, double rad)
        {
            double dx = X - Xo; double dy = Y - Yo;
            double L = Math.Sqrt(dx * dx + dy * dy);
            double itg = rad / L;
            double jtg = Math.Sqrt(1 - itg * itg);
            double Xtg = -itg * dx * itg + itg * dy * jtg;
            double Ytg = -itg * dx * jtg - itg * dy * itg;
            return new PointF( (float) Xtg, (float) Ytg);
        }

        public static OrbitInformation GetRadiusPoint2(PointF from, PointF center, int radius, double direction)
        {
            var rotation = GetAngleBetweenPoints(from, center);
            // Turn angle
            var attackAngle = (int)GetRotateDirection(direction, rotation);

            var rightPointDirection = rotation + 90;
            var leftPointDirection = rotation - 90;

            if (rightPointDirection > 360) rightPointDirection = rightPointDirection - 360;
            if (leftPointDirection < 0) leftPointDirection = 360 + leftPointDirection;

            var rightPointCoordinates = Move(center, radius, rightPointDirection);
            var leftPointCoordinates = Move(center, radius, leftPointDirection);

            if (attackAngle < 0)
            {
                return new OrbitInformation
                {
                    StartLocation = new PointF(leftPointCoordinates.PointTo.X, leftPointCoordinates.PointTo.Y),
                    Rotation = OrbitRotation.Right
                };
            }

            return new OrbitInformation
            {
                StartLocation = new PointF(rightPointCoordinates.PointTo.X, rightPointCoordinates.PointTo.Y),
                Rotation = OrbitRotation.Left
            };
        }

        public static OrbitInformation GetRadiusPoint(PointF from, PointF center, int radius, double direction)
        {
            var rightPointCoordinates = new PointF(-1, -1);
            var leftPointCoordinates = new PointF(-1, -1);

            var resultPointCoordinates = new PointF(-1, -1);

            FindTangents(center, radius, from, out rightPointCoordinates, out leftPointCoordinates);

            //var resultLeft = Approach.Calculate(from, leftPointCoordinates, direction);
            //var resultRight = Approach.Calculate(from, rightPointCoordinates, direction);


            //if (resultLeft.Count < resultRight.Count)
            //{
            //    return new OrbitInformation
            //    {
            //        StartLocation = new PointF(rightPointCoordinates.X, rightPointCoordinates.Y),
            //        Rotation = OrbitRotation.Left
            //    };
            //}


            return new OrbitInformation
            {
                StartLocation = new PointF(leftPointCoordinates.X, leftPointCoordinates.Y),
                Rotation = OrbitRotation.Right
            };



            var rotationRight = GetAngleBetweenPoints(rightPointCoordinates, center);
            //// Turn angle
            var attackAngleRight = (int)GetRotateDirection(direction, rotationRight);

            var attackAngle = 0;

            var rotationLeft = GetAngleBetweenPoints(leftPointCoordinates, center);
            var attackAngleLeft = (int)GetRotateDirection(direction, rotationLeft);

            if (Math.Abs(attackAngleRight) < Math.Abs(attackAngleLeft))
            {
                attackAngle = attackAngleLeft;
                resultPointCoordinates = leftPointCoordinates;
            }
            else
            {
                attackAngle = attackAngleRight;
                resultPointCoordinates = rightPointCoordinates;
            }

            if (attackAngle < 0)
            {
                return new OrbitInformation
                {
                    StartLocation = new PointF(resultPointCoordinates.X, resultPointCoordinates.Y),
                    Rotation = OrbitRotation.Right
                };
            }
           
            return new OrbitInformation
            {
                StartLocation = new PointF(resultPointCoordinates.X, resultPointCoordinates.Y),
                Rotation = OrbitRotation.Left
            };
        }

        private static bool FindTangents(PointF center, float radius,
            PointF external_point, out PointF pt1, out PointF pt2)
        {
            // Find the distance squared from the
            // external point center the circle's center.
            double dx = center.X - external_point.X;
            double dy = center.Y - external_point.Y;
            double D_squared = dx * dx + dy * dy;

            if (D_squared < radius * radius)
            {
                pt1 = new PointF(-1, -1);
                pt2 = new PointF(-1, -1);
                return false;
            }

            // Find the distance from the external point
            // center the tangent points.
            double L = Math.Sqrt(D_squared - radius * radius);

            // Find the points of intersection between
            // the original circle and the circle with
            // center external_point and radius dist.
            FindCircleCircleIntersections(
                center.X, center.Y, radius,
                external_point.X, external_point.Y, (float)L,
                out pt1, out pt2);

            return true;
        }

        private static int FindCircleCircleIntersections(
            float cx0, float cy0, float radius0,
            float cx1, float cy1, float radius1,
            out PointF intersection1, out PointF intersection2)
        {
            // Find the distance between the centers.
            float dx = cx0 - cx1;
            float dy = cy0 - cy1;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            // See how many solutions there are.
            if (dist > radius0 + radius1)
            {
                // No solutions, the circles are too far apart.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if (dist < Math.Abs(radius0 - radius1))
            {
                // No solutions, one circle contains the other.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if ((dist == 0) && (radius0 == radius1))
            {
                // No solutions, the circles coincide.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else
            {
                // Find a and h.
                double a = (radius0 * radius0 -
                    radius1 * radius1 + dist * dist) / (2 * dist);
                double h = Math.Sqrt(radius0 * radius0 - a * a);

                // Find P2.
                double cx2 = cx0 + a * (cx1 - cx0) / dist;
                double cy2 = cy0 + a * (cy1 - cy0) / dist;

                // GetInteger the points P3.
                intersection1 = new PointF(
                    (float)(cx2 + h * (cy1 - cy0) / dist),
                    (float)(cy2 - h * (cx1 - cx0) / dist));
                intersection2 = new PointF(
                    (float)(cx2 - h * (cy1 - cy0) / dist),
                    (float)(cy2 + h * (cx1 - cx0) / dist));

                // See if we have 1 or 2 solutions.
                if (dist == radius0 + radius1) return 1;
                return 2;
            }
        }
    }



}
