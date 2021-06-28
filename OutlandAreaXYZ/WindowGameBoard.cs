using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Engine.Configuration;
using Engine.Tools;
using Engine.UI.DrawEngine;
using Engine.UI.Model;
using EngineCore.DataProcessing;
using EngineCore.Geometry;
using EngineCore.Tools;

namespace OutlandAreaXYZ
{
    public partial class WindowGameBoard : Form
    {
        private Mode CurrentMode = Mode.Regular;
        PointF SpacecraftLocation = new PointF(300, 300);
        PointF TargetLocation = new PointF(800, 300);
        PointF MouseCoordinates = new PointF(0, 0);
        private int _orbitRadius = 50;

        public WindowGameBoard()
        {
            InitializeComponent();

            txtSpacecraftX.Text = "N/A";
            txtSpacecraftY.Text = "N/A";
            txtSpacecraftDirection.Text = "55";

            Scheduler.Instance.ScheduleTask(100, 50, TimerTick, null);
        }

        private void TimerTick()
        {
            this.PerformSafely(RefreshControl);
        }

        private void RefreshControl()
        {
            txtMouseX.Text = MouseCoordinates.X + "";
            txtMouseY.Text = MouseCoordinates.Y + "";

            if (SpacecraftLocation != PointF.Empty)
            {
                txtSpacecraftX.Text = SpacecraftLocation.X + "";
                txtSpacecraftY.Text = SpacecraftLocation.Y + "";
            }

            if (TargetLocation != PointF.Empty)
            {
                txtTargetX.Text = TargetLocation.X + "";
                txtTargetY.Text = TargetLocation.Y + "";
            }

            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            var screenParameters =
                new ScreenParameters(Width, Height, Width / 2, Height / 2)
                {
                    GraphicSurface = graphics
                };

            DrawTacticalMap.DrawBackGround(screenParameters);

            if (isStarted)
            {
                DrawCalculationSteps(screenParameters);

                DrawSpacecraft(screenParameters);

                DrawTargetPoint(screenParameters);
            }

            
            

            if (CurrentMode == Mode.SetSpaceShipLocation)
            {
                var color = Color.DarkOliveGreen;

                screenParameters.GraphicSurface.FillEllipse(new SolidBrush(color), MouseCoordinates.X - 2, MouseCoordinates.Y - 2, 4, 4);
                screenParameters.GraphicSurface.DrawEllipse(new Pen(color), MouseCoordinates.X - 4, MouseCoordinates.Y - 4, 8, 8);
            }

            if (CurrentMode == Mode.SetTargetLocation)
            {
                var color = Color.Maroon;

                screenParameters.GraphicSurface.FillEllipse(new SolidBrush(color), MouseCoordinates.X - 2, MouseCoordinates.Y - 2, 4, 4);
                screenParameters.GraphicSurface.DrawEllipse(new Pen(color), MouseCoordinates.X - 4, MouseCoordinates.Y - 4, 8, 8);
            }

            BackgroundImage = image;
        }

        public void DrawCalculationSteps(IScreenInfo screenInfo)
        {
            if (SpacecraftLocation == PointF.Empty) return;
            if (TargetLocation == PointF.Empty) return;

            var pointA = new CelestialObject
            {
                Agility = float.Parse(txtAgility.Text),
                Direction = float.Parse(txtSpacecraftDirection.Text),
                Location = SpacecraftLocation,
                Speed = 10
            };

            var pointB = new CelestialObject
            {
                Agility = 0,
                Direction = 90,
                Location = TargetLocation,
                Speed = 0
            };

            foreach (var pointF in new RouteCalculator().Execute(pointA, pointB, 50))
            {
                screenInfo.GraphicSurface.FillEllipse(new SolidBrush(Color.GreenYellow),
                    pointF.X - 1, pointF.Y - 1, 2, 2);
            }
        }

        public void DrawCalculationSteps_Old(IScreenInfo screenInfo)
        {
            if (SpacecraftLocation == PointF.Empty) return;
            if (TargetLocation == PointF.Empty) return;

            var color = Color.DimGray;

            var calculationData = new CalculationData
            {
                ObjectLocation = SpacecraftLocation, 
                ObjectDirection = double.Parse(txtSpacecraftDirection.Text),
                TargetLocation = TargetLocation,
                Orbit = _orbitRadius
            };

            if (Coordinates.FindLineCircleIntersections(TargetLocation, (float)calculationData.Orbit, calculationData.ObjectLine))
            {

                var data = new CalculationDataCrossOrbit
                {
                    ObjectLocation = SpacecraftLocation,
                    ObjectDirection = double.Parse(txtSpacecraftDirection.Text),
                    TargetLocation = TargetLocation,
                    Orbit = _orbitRadius
                };

                var middlePoint = Coordinates.GetCentrePoint(data.ObjectLocation, data.TargetLocation);

                screenInfo.GraphicSurface.FillEllipse(new SolidBrush(Color.Chocolate),
                    middlePoint.X - 2, middlePoint.Y - 2, 4, 4);

                

                #region Draw move vector

                screenInfo.GraphicSurface.DrawLine(new Pen(color), data.ObjectLine.From, data.ObjectLine.To);

                #endregion

                #region Ship - Target line

                screenInfo.GraphicSurface.DrawLine(new Pen(color), data.ObjectLocation.X, data.ObjectLocation.Y, data.TargetLocation.X, data.TargetLocation.Y);

                #endregion

                var points = Coordinates.GetRadiusPoint(middlePoint, data.TargetLocation, (int)data.Orbit);

                foreach (var pointF in points)
                {
                    screenInfo.GraphicSurface.FillEllipse(new SolidBrush(Color.Chocolate),
                        pointF.X - 2, pointF.Y - 2, 4, 4);

                    var upCrossPoint = Coordinates.GetCrossLineToLinePoint(data.ObjectLine, new Line(middlePoint, pointF));

                    var _route = new List<PointF>();

                    _route.Add(data.ObjectLocation);
                    _route.Add(Coordinates.MoveObject(data.ObjectLocation, 5, data.ObjectDirection));
                    _route.Add(upCrossPoint);
                    _route.Add(pointF);

                    screenInfo.GraphicSurface.DrawBeziers(new Pen(Color.Bisque), _route.ToArray());
                }

                

                return;
            }

            #region Draw move vector

            screenInfo.GraphicSurface.DrawLine(new Pen(color), calculationData.ObjectLine.From, calculationData.ObjectLine.To);

            #endregion

            #region Ship - Target line

            screenInfo.GraphicSurface.DrawLine(new Pen(color), calculationData.ObjectLocation.X, calculationData.ObjectLocation.Y, calculationData.TargetLocation.X, calculationData.TargetLocation.Y);

            #endregion

            #region Target Radius Perpendicular


            var nearestPointOnCircle = calculationData.NearestPointOnCircle;

            screenInfo.GraphicSurface.DrawLine(new Pen(color), calculationData.TargetLocation.X, calculationData.TargetLocation.Y, nearestPointOnCircle.X, nearestPointOnCircle.Y);

            screenInfo.GraphicSurface.FillEllipse(new SolidBrush(Color.Chocolate), nearestPointOnCircle.X - 2, nearestPointOnCircle.Y - 2, 4, 4);

            #endregion

            #region Tangent line to circles

            var tangentLine = calculationData.TangentLine;

            screenInfo.GraphicSurface.DrawLine(new Pen(color), tangentLine.To.X, tangentLine.To.Y, tangentLine.From.X, tangentLine.From.Y);
            #endregion


            #region Point B cross lines movement and tangent to circle

            var crossPoint = Coordinates.GetCrossLineToLinePoint(calculationData.ObjectLine, calculationData.TangentLine);

            if (crossPoint != PointF.Empty)
            {
                screenInfo.GraphicSurface.FillEllipse(new SolidBrush(Color.Chocolate),
                    crossPoint.X - 2, crossPoint.Y - 2, 4, 4);
            }


            #endregion

            #region Draw navigation Beziers

            var arr = new List<PointF>();

            arr.Add(calculationData.Route[0]); 
            arr.Add(calculationData.Route[2]); 
            arr.Add(calculationData.Route[3]);

            //screenInfo.GraphicSurface.DrawBeziers(new Pen(Color.Bisque), calculationData.Route);

            #endregion


            var rrrr = calculationData.Route;

            var allPoint = new List<PointF>();

            //allPoint.Add(rrrr[0]);

            //double length = 0;

            //var prevPoint = rrrr[0];

            //for (var t = 0.01; t <= 1.0; t += 0.1)
            //{
            //    var point = calculationData.GetDetailData(rrrr[0], rrrr[2], rrrr[3], t);

            //    //var pointCast = calculationData.GetDetailDataCastR(arr.ToArray(), t, 2, 0);

            //    allPoint.Add(point);

            //    length += Coordinates.GetDistance(point, prevPoint);

            //    prevPoint = point;

            //    screenInfo.GraphicSurface.DrawEllipse(new Pen(new SolidBrush(Color.Chartreuse)), point.X, point.Y, 1, 1);
            //    //screenInfo.GraphicSurface.DrawEllipse(new Pen(new SolidBrush(Color.Magenta)), pointCast.X, pointCast.Y, 1, 1);
            //}

            //screenInfo.GraphicSurface.FillEllipse(new SolidBrush(Color.Red), rrrr[0].X - 5, rrrr[0].Y - 5, 10, 10);

            //screenInfo.GraphicSurface.FillEllipse(new SolidBrush(Color.Yellow), rrrr[2].X - 5, rrrr[2].Y - 5, 10, 10);

            //screenInfo.GraphicSurface.FillEllipse(new SolidBrush(Color.Aquamarine), rrrr[3].X - 2, rrrr[3].Y - 5, 10, 10);



            // Generic calculation
            //----------------------------------------------------------------------------------------------------------------------
            var routeCalculator = new GenericCalculation
            {
                ObjectLocation = SpacecraftLocation,
                ObjectAgility = 5,
                ObjectDirection = double.Parse(txtSpacecraftDirection.Text),
                TargetLocation = TargetLocation,
                Orbit = _orbitRadius
            };

            foreach (var pointF in routeCalculator.Execute())
            {
                screenInfo.GraphicSurface.FillEllipse(new SolidBrush(Color.GreenYellow),
                    pointF.X - 1, pointF.Y - 1, 2, 2);
            }

            screenInfo.GraphicSurface.DrawLine(
                new Pen(Color.Red), routeCalculator.NearestPointOnCircle,
                Coordinates.MoveObject(routeCalculator.NearestPointOnCircle, 200, routeCalculator.AttackAngle)
            );


            screenInfo.GraphicSurface.FillEllipse(new SolidBrush(Color.GreenYellow),
                routeCalculator.RotatePoint.X - 5, routeCalculator.RotatePoint.Y - 5, 10, 10);

            screenInfo.GraphicSurface.FillEllipse(new SolidBrush(Color.Orange),
                routeCalculator.StartTurnPoint.X - 5, routeCalculator.StartTurnPoint.Y - 5, 10, 10);


            
        }

        public void DrawTargetPoint(IScreenInfo screenInfo)
        {
            if (TargetLocation == PointF.Empty) return;

            var color = Color.Maroon;

            screenInfo.GraphicSurface.FillEllipse(new SolidBrush(color), TargetLocation.X - 2, TargetLocation.Y - 2, 4, 4);
            screenInfo.GraphicSurface.DrawEllipse(new Pen(color), TargetLocation.X - 4, TargetLocation.Y - 4, 8, 8);


            color = Color.DarkGray;
            screenInfo.GraphicSurface.DrawEllipse(new Pen(color), TargetLocation.X - _orbitRadius, TargetLocation.Y - _orbitRadius, _orbitRadius * 2, _orbitRadius * 2);
        }

        public void DrawSpacecraft(IScreenInfo screenInfo)
        {
            if (SpacecraftLocation == PointF.Empty) return;

            var color = Color.DarkOliveGreen;

            screenInfo.GraphicSurface.FillEllipse(new SolidBrush(color), SpacecraftLocation.X - 2, SpacecraftLocation.Y - 2, 4, 4);
            screenInfo.GraphicSurface.DrawEllipse(new Pen(color), SpacecraftLocation.X - 4, SpacecraftLocation.Y - 4, 8, 8);

            DrawArrow(screenInfo, color);
        }

        private void WindowGameBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CurrentMode = Mode.Regular;
            }

            switch (CurrentMode)
            {
                case Mode.Regular:
                    break;
                case Mode.SetTargetLocation:
                    TargetLocation = new PointF(e.X, e.Y);
                    CurrentMode = Mode.Regular;
                    break;
                case Mode.SetSpaceShipLocation:
                    SpacecraftLocation = new PointF(e.X, e.Y);
                    CurrentMode = Mode.Regular;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void WindowGameBoard_MouseMove(object sender, MouseEventArgs e)
        {
            MouseCoordinates = new PointF(e.X, e.Y);
        }


        #region Events
        private void Event_SetTargetLocation(object sender, EventArgs e)
        {
            CurrentMode = Mode.SetTargetLocation;
        }

        private void Event_SetSpacecraftLocation(object sender, EventArgs e)
        {
            CurrentMode = Mode.SetSpaceShipLocation;
        }

        #endregion

        public void DrawArrow(IScreenInfo screenInfo, Color color, int arrowSize = 4)
        {
            var direction = int.Parse(txtSpacecraftDirection.Text);

            var endArrowPoint = Coordinates.MoveObject(SpacecraftLocation, 12, direction);

            DrawArrow(screenInfo.GraphicSurface, new SpaceMapVector(SpacecraftLocation, endArrowPoint, direction), color, arrowSize);
        }

        public static void DrawArrow(Graphics graphics, SpaceMapVector line, Color color, int arrowSize = 4)
        {
            // Base arrow line
            graphics.DrawLine(new Pen(color), line.PointFrom.X, line.PointFrom.Y, line.PointTo.X, line.PointTo.Y);

            // Arrow left line
            var leftArrowLine = SpaceMapTools.Move(line.PointTo.ToVector2(), arrowSize, line.Direction + 150);
            graphics.DrawLine(new Pen(color), leftArrowLine.PointFrom.X, leftArrowLine.PointFrom.Y, leftArrowLine.PointTo.X, leftArrowLine.PointTo.Y);

            // Arrow right line
            var rightArrowLine = SpaceMapTools.Move(line.PointTo.ToVector2(), arrowSize, line.Direction - 150);
            graphics.DrawLine(new Pen(color), rightArrowLine.PointFrom.X, rightArrowLine.PointFrom.Y, rightArrowLine.PointTo.X, rightArrowLine.PointTo.Y);

        }

        private bool isStarted = false;
        private void cmdExecute_Click(object sender, EventArgs e)
        {
            if (isStarted)
            {
                cmdExecute.Text = "Draw";
                isStarted = false;
            }
            else
            {
                cmdExecute.Text = "Clear";
                isStarted = true;
            }
        }
    }

    public enum Mode
    {
        Regular,
        SetTargetLocation,
        SetSpaceShipLocation
    }
}
