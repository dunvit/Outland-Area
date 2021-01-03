using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Engine.Common.Geometry;
using Engine.Configuration;
using Engine.Gui;
using Engine.Management.Server;
using Engine.ScreenDrawing;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaCommon.Universe.Objects.Spaceships;
using ObjectLocation = OutlandAreaCommon.Server.DataProcessing.ObjectLocation;

namespace OutlandArea.Tools
{
    public class DrawTacticalMap
    {
        private const int DrawSpaceshipInformationLenght = 40;
        private const int DrawSpaceshipInformationShelfLenght = 90;
        public static void DrawMissile(ICelestialObject celestialObject, PointF location, Graphics graphics, ScreenParameters screenParameters)
        {
            // Convert celestial object coordinates to screen coordinates
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, location);

            graphics.FillEllipse(new SolidBrush(Color.DarkOliveGreen), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);
        }

        public static void DrawSpaceship(ICelestialObject spaceShip, PointF location, Graphics graphics, ScreenParameters screenParameters)
        {
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(location.X, location.Y));

            var ship = (Spaceship) spaceShip;
            var color = Color.Black;

            switch (ship.Classification)
            {
                case 200:
                    color = Color.DarkOliveGreen;
                    break;

                case 201:
                    color = Color.DarkGray;
                    break;

                case 202:
                    color = Color.DarkRed;
                    break;

                case 203:
                    color = Color.SeaGreen;
                    break;
            }

            graphics.FillEllipse(new SolidBrush(color), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);
            graphics.DrawEllipse(new Pen(color), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);
        }

        public static void DrawSpaceshipInformation(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(celestialObject.PositionX, celestialObject.PositionY));

            var drawSpaceshipInformationAngle = 0;
            var drawSpaceshipInformationShelf = 0;

            var pen = new Pen(Color.DimGray, 2);

            if (celestialObject.Direction >= 0 && celestialObject.Direction < 90)
            {
                drawSpaceshipInformationAngle = 135;
                drawSpaceshipInformationShelf = 90;
            }

            if (celestialObject.Direction >= 90 && celestialObject.Direction < 180)
            {
                drawSpaceshipInformationAngle = 45;
                drawSpaceshipInformationShelf = 90;
            }

            if (celestialObject.Direction >= 180 && celestialObject.Direction < 270)
            {
                drawSpaceshipInformationAngle = 135;
                drawSpaceshipInformationShelf = 90;
            }

            if (celestialObject.Direction >= 270 && celestialObject.Direction < 360)
            {
                drawSpaceshipInformationAngle = 45;
                drawSpaceshipInformationShelf = 90;
            }

            var footCoordinates = OutlandAreaCommon.Tools.MoveCelestialObjects(screenCoordinates, DrawSpaceshipInformationLenght, drawSpaceshipInformationAngle);


            graphics.DrawLine(pen, screenCoordinates.X, screenCoordinates.Y, footCoordinates.X, footCoordinates.Y);

            
            var shelfCoordinates = OutlandAreaCommon.Tools.MoveCelestialObjects(footCoordinates, DrawSpaceshipInformationShelfLenght, drawSpaceshipInformationShelf);

            graphics.DrawLine(pen, footCoordinates.X, footCoordinates.Y, shelfCoordinates.X, shelfCoordinates.Y);

            var pointInformationBase = new PointF(footCoordinates.X + 3, footCoordinates.Y);

            #region Detail information

            graphics.FillRectangle(new SolidBrush(Color.Chartreuse), new RectangleF(pointInformationBase.X, pointInformationBase.Y - 13, 10, 10) );

            using (var font = new Font("Times New Roman", 10, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                graphics.DrawString($"{celestialObject.Name}", font, new SolidBrush(Color.WhiteSmoke), new PointF(pointInformationBase.X + 15, pointInformationBase.Y - 13));
            }

            // TODO: Check size string for draw line length

            #endregion
        }

        public static void DrawAsteroid(ICelestialObject celestialObject, PointF location, Graphics graphics, ScreenParameters screenParameters)
        {
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(location.X, location.Y));

            graphics.FillEllipse(new SolidBrush(Color.Gray), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);
        }

        public static void DrawActiveCelestialObject(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            if(celestialObject == null) return;

            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(celestialObject.PositionX, celestialObject.PositionY));

            graphics.FillEllipse(new SolidBrush(Color.WhiteSmoke), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);

            graphics.FillEllipse(new SolidBrush(Color.WhiteSmoke), screenCoordinates.X - 5, screenCoordinates.Y - 5, 10, 10);

        }

        public static void DrawCelestialObjectCoordinates(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters,
                new PointF(celestialObject.PositionX - 25, celestialObject.PositionY + 10));

            using (var font = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel))
            {
                graphics.DrawString($"({celestialObject.PositionX} : {celestialObject.PositionY})", font, new SolidBrush(Color.DimGray), new PointF(screenCoordinates.X - 15, screenCoordinates.Y));
            }
        }

        public static void DrawCelestialObjectDirection(ICelestialObject celestialObject, PointF location, Graphics graphics, ScreenParameters screenParameters)
        {
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(location.X, location.Y));

            if ((CelestialObjectTypes)celestialObject.Classification == CelestialObjectTypes.Explosion) return;

            var move = SpaceMapTools.Move(screenCoordinates, 8, 6, celestialObject.Direction);
            SpaceMapGraphics.DrawArrow(graphics, move, Color.DimGray);
        }

        public static void DrawTrajectory(GameSession gameSession, ICelestialObject spaceShip, ICelestialObject targetObject, Graphics graphics, ScreenParameters screenParameters)
        {

            var pointCurrentLocation = new PointF(spaceShip.PositionX, spaceShip.PositionY);
            var pointTargetLocation = new PointF(targetObject.PositionX, targetObject.PositionY);
            var pointCenterTargetLocation = new PointF(targetObject.PositionX, targetObject.PositionY);
            var prevPointCurrentLocation = new PointF(spaceShip.PositionX, spaceShip.PositionY);

            List<ObjectLocation> result = null;

            var movementType = gameSession.GetMovementType(spaceShip.Id);

            if (movementType == CommandTypes.Orbit)
            {
                var trajectoryOrbit = AllIn.GetRadiusPoint(spaceShip.GetLocation(), pointTargetLocation, 50, spaceShip.Direction, spaceShip.Speed);

                pointTargetLocation = new Point((int) trajectoryOrbit.StartPoint.X, (int) trajectoryOrbit.StartPoint.Y);
                
                result = AllIn.GetTrajectoryOrbit(pointCurrentLocation, pointTargetLocation, spaceShip.Direction, spaceShip.Speed, 200);
            }

            if (movementType == CommandTypes.AlignTo)
            {
                result = AllIn.GetTrajectoryApproach(pointCurrentLocation, pointTargetLocation, spaceShip.Direction, spaceShip.Speed, 200);
            }


            int temp = 0;
            int iteration = 0;

            var screenCurrentObjectLocation = new PointF(0, 0);
            var screenPreviousObjectLocation = new PointF(0, 0);

            bool isDrawConnectionLine = true;

            var points = new List<PointF>(); ;

            foreach (var objectLocation in result)
            {
                screenCurrentObjectLocation = UI.ToScreenCoordinates(screenParameters, objectLocation.Coordinates);

                points.Add(new PointF(screenCurrentObjectLocation.X, screenCurrentObjectLocation.Y));
            }


            if (points.Count < 2)
                return;

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // Draw arc to screen.
            graphics.DrawLines(new Pen(Color.FromArgb(18, 18, 18), 4), points.ToArray());
            graphics.DrawLines(new Pen(Color.FromArgb(22, 22, 22), 2), points.ToArray());
            graphics.DrawLines(new Pen(Color.FromArgb(28, 28, 28), 1), points.ToArray());

            var pen = new Pen(Color.Red, 1);// { StartCap = LineCap.ArrowAnchor };

            foreach (var objectLocation in result)
            {
                iteration++;

                screenCurrentObjectLocation = UI.ToScreenCoordinates(screenParameters, objectLocation.Coordinates);
                screenPreviousObjectLocation = UI.ToScreenCoordinates(screenParameters, prevPointCurrentLocation);

                PointF[] linePoints =
                {
                    new PointF(screenCurrentObjectLocation.X, screenCurrentObjectLocation.Y),
                    new PointF(screenPreviousObjectLocation.X, screenPreviousObjectLocation.Y)
                };

                graphics.DrawLines(pen, linePoints);

                prevPointCurrentLocation = new PointF(objectLocation.Coordinates.X, objectLocation.Coordinates.Y);

                //temp++;
                //if (temp == 1)
                //{
                //    temp = 0;
                //    graphics.FillEllipse(new SolidBrush(Color.DarkOliveGreen), screenCurrentObjectLocation.X - 1, screenCurrentObjectLocation.Y - 1, 3, 3);
                //}

                if (objectLocation.IsLinearMotion && isDrawConnectionLine)
                {
                    //graphics.FillEllipse(new SolidBrush(Color.Yellow), screenCurrentObjectLocation.X - 1, screenCurrentObjectLocation.Y - 1, 3, 3);

                    //isDrawConnectionLine = false;
                }

                //Logger.Debug($"iteration = {iteration} Coordinates = {objectLocation.Coordinates} IsLinearMotion = {objectLocation.IsLinearMotion} VectorToTarget = {objectLocation.VectorToTarget} Direction = {objectLocation.Direction} ScanRange = {objectLocation.ScanRange}");
            }



            if (movementType == CommandTypes.Orbit)
            {
                var trajectoryOrbit = AllIn.GetRadiusPoint(spaceShip.GetLocation(), pointTargetLocation, 50, spaceShip.Direction, spaceShip.Speed);

                var orbitRadius = 50;

                var lastPoint = points[points.Count - 1];

                var pointTargetCenter = UI.ToScreenCoordinates(screenParameters, pointCenterTargetLocation);

                //graphics.DrawLine(pen, lastWeyPointLocation.X, lastWeyPointLocation.Y, pointTargetCenter.X, pointTargetCenter.Y);
                graphics.DrawEllipse(pen, pointTargetCenter.X - orbitRadius, pointTargetCenter.Y - orbitRadius, orbitRadius * 2, orbitRadius * 2);

                var pointOrbitPoint = UI.ToScreenCoordinates(screenParameters, pointCenterTargetLocation);

                graphics.DrawEllipse(new Pen(new SolidBrush(Color.Coral), 1), pointOrbitPoint.X - 1, pointOrbitPoint.Y - 1, 5, 5);
                graphics.DrawEllipse(new Pen(new SolidBrush(Color.Goldenrod), 1), lastPoint.X - 1, lastPoint.Y - 1, 5, 5);

                var lastPointCoordinates = UI.ToMapCoordinates(screenParameters, lastPoint);

                var angleFirstOrbitPoint = Coordinates.GetRotation(lastPointCoordinates, pointCenterTargetLocation);

                for(int i = 0; i < 15; i++)
                {
                    var secondOrbitPoint = Coordinates.RotatePoint(pointCenterTargetLocation, orbitRadius, angleFirstOrbitPoint + trajectoryOrbit.Direction * i * 10);
                    
                    var secondOrbitPointCoordinates = UI.ToScreenCoordinates(screenParameters, secondOrbitPoint);

                    graphics.DrawEllipse(new Pen(new SolidBrush(Color.GreenYellow), 1), secondOrbitPointCoordinates.X - 1, secondOrbitPointCoordinates.Y - 1, 5, 5);

                }


                //var thirdOrbitPointCoordinates = UI.ToScreenCoordinates(screenParameters, thirdOrbitPoint);



                ////double theta = Math.Tan(Math.atan2(y - cy, x - cx));
                //var X = thirdOrbitPointCoordinates.X + 100 * Math.Cos(angleFirstOrbitPoint);
                //var Y = thirdOrbitPointCoordinates.Y + 100 * Math.Sin(angleFirstOrbitPoint);

                //graphics.DrawEllipse(new Pen(new SolidBrush(Color.BlueViolet), 1), (int)(X - 1), (int)(Y - 1), 5, 5);
            }


        }

        public static void DrawPreTarget(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(celestialObject.PositionX, celestialObject.PositionY));

            var radarLinePen = new Pen(Color.FromArgb(60, 60, 60), 1);

            graphics.DrawEllipse(radarLinePen, screenCoordinates.X - 12, screenCoordinates.Y - 12, 24, 24);

            graphics.DrawEllipse(radarLinePen, screenCoordinates.X - 22, screenCoordinates.Y - 22, 44, 44);

            graphics.DrawEllipse(radarLinePen, screenCoordinates.X - 32, screenCoordinates.Y - 32, 64, 64);
            

            graphics.DrawLine(radarLinePen, screenCoordinates.X - 45, screenCoordinates.Y, screenCoordinates.X + 45, screenCoordinates.Y);

            graphics.DrawLine(radarLinePen, screenCoordinates.X, screenCoordinates.Y - 45, screenCoordinates.X, screenCoordinates.Y + 45);

            graphics.FillEllipse(new SolidBrush(Color.Black), screenCoordinates.X - 10, screenCoordinates.Y - 10, 20, 20);

        }

        public static void DrawPointInSpace(ICelestialObject celestialObject, ICelestialObject spaceShip, Graphics graphics, ScreenParameters screenParameters)
        {
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(celestialObject.PositionX, celestialObject.PositionY));

            var radarLinePen = new Pen(Color.FromArgb(60, 60, 60), 1);

            graphics.DrawLine(radarLinePen, screenCoordinates.X - 15, screenCoordinates.Y, screenCoordinates.X + 15, screenCoordinates.Y);

            graphics.DrawLine(radarLinePen, screenCoordinates.X, screenCoordinates.Y - 15, screenCoordinates.X, screenCoordinates.Y + 15);

            graphics.FillEllipse(new SolidBrush(Color.Black), screenCoordinates.X - 5, screenCoordinates.Y - 5, 10, 10);
        }
    }
}
