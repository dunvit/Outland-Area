using System;
using System.Collections.Generic;
using System.Drawing;
using EngineCore.DataProcessing;
using EngineCore.Geometry;
using EngineCore.Tools;
using LanguageExt;
using Microsoft.VisualBasic;

namespace OutlandAreaXYZ
{
    public class CalculationRoute
    {
        public PointF ObjectLocation { get; set; }

        public double ObjectDirection { get; set; }

        public double ObjectAgility { get; set; }

        public PointF TargetLocation { get; set; }

        public double Orbit { get; set; }

        protected List<PointF> _route = new List<PointF>();

        protected Line _tangentLine = null;
        protected Line _objectLine = null;

        protected readonly object _lock = new object();

        public PointF[] Route => _route.DeepClone().ToArray();

        public Line ObjectLine
        {
            get
            {
                _objectLine = new Line(
                    GeometryTools.MoveObject(ObjectLocation, 10000, ObjectDirection),
                    GeometryTools.MoveObject(ObjectLocation, 10000, (ObjectDirection - 180).To360Degrees())
                );

                return _objectLine;
            }
        }

        
    }

    public class CalculationDataCrossOrbit : CalculationRoute
    {

    }

    public class GenericCalculation : CalculationRoute
    {
        public double AttackAngle = 0;

        public List<PointF> Execute()
        {
            var result = new List<PointF>();

            _objectLine = new Line(
                GeometryTools.MoveObject(ObjectLocation, 10000, ObjectDirection),
                GeometryTools.MoveObject(ObjectLocation, 10000, (ObjectDirection - 180).To360Degrees())
            );

            result.Add(ObjectLocation);

            

            var perpendicularDirection = GeometryTools.Azimuth(TargetLocation, ObjectLocation);

            perpendicularDirection = (perpendicularDirection - 90).To360Degrees();

            var upRadiusPoint = GeometryTools.MoveObject(TargetLocation, Orbit, perpendicularDirection);

            AttackAngle = GeometryTools.Azimuth(TargetLocation, ObjectLocation);

            perpendicularDirection = (perpendicularDirection - 180).To360Degrees();

            var downRadiusPoint = GeometryTools.MoveObject(TargetLocation, Orbit, perpendicularDirection);

            #region Up line

            var upLeftTangent = GeometryTools.MoveObject(
                upRadiusPoint,
                10000,
                (GeometryTools.Azimuth(TargetLocation, ObjectLocation) - 180).To360Degrees()
            );

            var upLightTangent = GeometryTools.MoveObject(
                upRadiusPoint,
                10000,
                (GeometryTools.Azimuth(TargetLocation, ObjectLocation)).To360Degrees()
            );

            var upCrossPoint = GeometryTools.GetCrossLineToLinePoint(_objectLine, new Line(upLeftTangent, upLightTangent));

            var upDistance = GeometryTools.Distance(upRadiusPoint, upCrossPoint);
            #endregion


            #region Up line

            var downLeftTangent = GeometryTools.MoveObject(
                downRadiusPoint,
                10000,
                (GeometryTools.Azimuth(TargetLocation, ObjectLocation) - 180).To360Degrees()
            );

            var downLightTangent = GeometryTools.MoveObject(
                downRadiusPoint,
                10000,
                (GeometryTools.Azimuth(TargetLocation, ObjectLocation)).To360Degrees()
            );

            var downCrossPoint = GeometryTools.GetCrossLineToLinePoint(_objectLine, new Line(downLeftTangent, downLightTangent));

            var downDistance = GeometryTools.Distance(downRadiusPoint, downCrossPoint);

            #endregion

            _nearestPointOnCircle = upDistance < downDistance ? upRadiusPoint : downRadiusPoint;

            var rotationTime = (AttackAngle - ObjectDirection) / ObjectAgility ;

            var turnPoint = (ObjectDirection - 180).To360Degrees();

            if (upDistance < downDistance)
            {
                _nearestPointOnCircle = upRadiusPoint;
                _farPointOnCircle = downRadiusPoint;
                _rotatePoint = upCrossPoint;
            }
            else
            {
                _nearestPointOnCircle = downRadiusPoint;
                _farPointOnCircle = upRadiusPoint;
                _rotatePoint = downCrossPoint;
            }

            _startTurnPoint = GeometryTools.MoveObject(_rotatePoint, 5 * rotationTime, (ObjectDirection - 180).To360Degrees());

            
            ////Set loop before distance < than > GeometryTools.Distance(ObjectLocation, _rotatePoint)
            //DateAndTime start turn

            int maxIterations = 2000;

            var currentLocation = ObjectLocation;
            var currentDirection = ObjectDirection;
            var isTurnStarted = false;

            for (var iteration = 0; iteration < maxIterations; iteration++)
            {
                var newPosition = GeometryTools.MoveObject(currentLocation, 5, currentDirection);

                //var distance = GeometryTools.Distance(newPosition, _rotatePoint);

                //if (distance < 5)
                //{
                //    currentDirection = AttackAngle;

                //    //result.Add(GeometryTools.MoveObject(currentLocation, 500, currentDirection));

                //    //return result;
                //}

                var distance = GeometryTools.Distance(newPosition, _startTurnPoint);

                if (distance < 5 || isTurnStarted)
                {
                    currentDirection = currentDirection + 5;
                    isTurnStarted = true;

                    if (Math.Abs(AttackAngle - currentDirection) < 5)
                    {
                        isTurnStarted = false;
                        currentDirection = AttackAngle;
                    }
                }

                currentLocation = newPosition;

                result.Add(newPosition);
            }

            return result;
        }

        private PointF _nearestPointOnCircle = PointF.Empty;
        private PointF _farPointOnCircle = PointF.Empty;
        private PointF _rotatePoint = PointF.Empty;
        private PointF _startTurnPoint = PointF.Empty;

        public PointF StartTurnPoint
        {
            get
            {

                return _startTurnPoint;
            }
        }

        public PointF RotatePoint
        {
            get
            {

                return _rotatePoint;
            }
        }

        public PointF NearestPointOnCircle
        {
            get
            {
                Execute();

                return _nearestPointOnCircle;
            }
        }
    }

    public class CalculationData: CalculationRoute
    {

        public Line TangentLine
        {
            get
            {
                Calculation();

                return _tangentLine;
            }
        }
        private void Calculation()
        {
            lock (_lock)
            {
                _route = new List<PointF>();

                _objectLine = new Line(
                    GeometryTools.MoveObject(ObjectLocation, 10000, ObjectDirection),
                    GeometryTools.MoveObject(ObjectLocation, 10000, (ObjectDirection - 180).To360Degrees())
                );

                var perpendicularDirection = GeometryTools.Azimuth(TargetLocation, ObjectLocation);

                perpendicularDirection = (perpendicularDirection - 90).To360Degrees();

                var upRadiusPoint = GeometryTools.MoveObject(TargetLocation, Orbit, perpendicularDirection);

                perpendicularDirection = (perpendicularDirection - 180).To360Degrees();

                var downRadiusPoint = GeometryTools.MoveObject(TargetLocation, Orbit, perpendicularDirection);


                #region Up line

                var upLeftTangent = GeometryTools.MoveObject(
                    upRadiusPoint,
                    10000,
                    (GeometryTools.Azimuth(TargetLocation, ObjectLocation) - 180).To360Degrees()
                );

                var upLightTangent = GeometryTools.MoveObject(
                    upRadiusPoint,
                    10000,
                    (GeometryTools.Azimuth(TargetLocation, ObjectLocation)).To360Degrees()
                );

                var upCrossPoint = GeometryTools.GetCrossLineToLinePoint(_objectLine, new Line(upLeftTangent, upLightTangent));

                var upDistance = GeometryTools.Distance(upRadiusPoint, upCrossPoint);
                #endregion


                #region Up line

                var downLeftTangent = GeometryTools.MoveObject(
                    downRadiusPoint,
                    10000,
                    (GeometryTools.Azimuth(TargetLocation, ObjectLocation) - 180).To360Degrees()
                );

                var downLightTangent = GeometryTools.MoveObject(
                    downRadiusPoint,
                    10000,
                    (GeometryTools.Azimuth(TargetLocation, ObjectLocation)).To360Degrees()
                );

                var downCrossPoint = GeometryTools.GetCrossLineToLinePoint(_objectLine, new Line(downLeftTangent, downLightTangent));

                var downDistance = GeometryTools.Distance(downRadiusPoint, downCrossPoint);

                #endregion

                _nearestPointOnCircle = upDistance < downDistance ? upRadiusPoint : downRadiusPoint;

                if (upDistance < downDistance)
                {
                    _nearestPointOnCircle = upRadiusPoint;
                    _farPointOnCircle = downRadiusPoint;
                }
                else
                {
                    _nearestPointOnCircle = downRadiusPoint;
                    _farPointOnCircle = upRadiusPoint;
                }

                var leftTangent = GeometryTools.MoveObject(
                    _nearestPointOnCircle,
                    10000,
                    (GeometryTools.Azimuth(TargetLocation, ObjectLocation) - 180).To360Degrees()
                );

                var rightTangent = GeometryTools.MoveObject(
                    _nearestPointOnCircle,
                    10000,
                    (GeometryTools.Azimuth(TargetLocation, ObjectLocation)).To360Degrees()
                );

                

                _tangentLine = new Line(leftTangent, rightTangent);

                var crossPoint = GeometryTools.GetCrossLineToLinePoint(_objectLine, _tangentLine);

                _route.Add(ObjectLocation);
                _route.Add(GeometryTools.MoveObject(ObjectLocation, 5, ObjectDirection));
                _route.Add(crossPoint);
                _route.Add(_nearestPointOnCircle);
            }


        }

        private PointF _nearestPointOnCircle = PointF.Empty;
        private PointF _farPointOnCircle = PointF.Empty;


        public PointF GetDetailData(PointF start, PointF apogeus, PointF finish, double time)
        {
            var resultX = start.X * Math.Pow(1 - time, 2) + 2 * apogeus.X * time * (1 - time) + finish.X * Math.Pow(time, 2);

            var resultY =  start.Y * Math.Pow(1 - time, 2) + 2 * apogeus.Y * time * (1 - time) + finish.Y * Math.Pow(time, 2);

            return new PointF((float)resultX, (float)resultY);
        }

        public PointF GetDetailDataCastR(PointF[] p, double t, int n, int m)
        {
            if (n == 0)
                return p[m];
            else
                return Lin1(GetDetailDataCastR(p, t, n - 1, m), GetDetailDataCastR(p, t, n - 1, m + 1), t);
        }

        PointF Lin1(PointF p1, PointF p2, double t)
        {
            PointF q = new PointF();
            q.X = System.Convert.ToSingle(p2.X * t + p1.X * (1 - t));
            q.Y = System.Convert.ToSingle(p2.Y * t + p1.Y * (1 - t));
            return q;
        }


        public PointF NearestPointOnCircle
        {
            get
            {
                Calculation();

                return _nearestPointOnCircle;
            }
        }
    }
}
