using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Engine.Configuration;
using Engine.Gui;
using Engine.Layers.Tactical;
using Engine.Management.Server.DataProcessing;
using Engine.Tools;

namespace OutlandArea.Tools
{
    public class DrawTacticalMap
    {
        private const int drawSpaceshipInformationLenght = 40;
        private const int drawSpaceshipInformationShelfLenght = 90;


        public static void DrawSpaceship(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            var mainColor = Color.DarkRed;
            var mainIcon = "EnemySpaceship";

            //if (isPlayerSpacecraft)
            //{
            mainIcon = "PlayerSpaceship";
            //}
            // Convert celestial object coordinates to screen coordinates
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new Point(celestialObject.PositionX, celestialObject.PositionY));

            var bmpSpacecraft = UI.RotateImage(UI.LoadImage(mainIcon), (float) celestialObject.Direction);

            graphics.DrawImage(bmpSpacecraft, new PointF(screenCoordinates.X - bmpSpacecraft.Width / 2, screenCoordinates.Y - bmpSpacecraft.Height / 2));

        }

        public static void DrawSpaceshipInformation(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new Point(celestialObject.PositionX, celestialObject.PositionY));

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

            var footCoordinates = Common.MoveCelestialObjects(screenCoordinates, drawSpaceshipInformationLenght, drawSpaceshipInformationAngle);


            graphics.DrawLine(pen, screenCoordinates.X, screenCoordinates.Y, footCoordinates.X, footCoordinates.Y);

            
            var shelfCoordinates = Common.MoveCelestialObjects(footCoordinates, drawSpaceshipInformationShelfLenght, drawSpaceshipInformationShelf);

            graphics.DrawLine(pen, footCoordinates.X, footCoordinates.Y, shelfCoordinates.X, shelfCoordinates.Y);

            var pointInformationBase = new Point(footCoordinates.X + 3, footCoordinates.Y);

            #region Detail information

            graphics.FillRectangle(new SolidBrush(Color.Chartreuse), new Rectangle(pointInformationBase.X, pointInformationBase.Y - 13, 10, 10) );

            using (var font = new Font("Times New Roman", 10, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                graphics.DrawString($"{celestialObject.Name}", font, new SolidBrush(Color.WhiteSmoke), new PointF(pointInformationBase.X + 15, pointInformationBase.Y - 13));
            }

            // TODO: Check size string for draw line length

            #endregion
        }

        public static void DrawAsteroid(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            // Convert celestial object coordinates to screen coordinates
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new Point(celestialObject.PositionX, celestialObject.PositionY));

            graphics.FillEllipse(new SolidBrush(Color.WhiteSmoke), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);
        }

        public static void DrawActiveCelestialObject(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            if(celestialObject == null) return;

            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new Point(celestialObject.PositionX, celestialObject.PositionY));

            graphics.FillEllipse(new SolidBrush(Color.WhiteSmoke), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);

            graphics.FillEllipse(new SolidBrush(Color.WhiteSmoke), screenCoordinates.X - 5, screenCoordinates.Y - 5, 10, 10);

        }

        public static void DrawCelestialObjectCoordinates(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters,
                new Point(celestialObject.PositionX - 25, celestialObject.PositionY + 10));

            using (var font = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel))
            {
                graphics.DrawString($"({celestialObject.PositionX} : {celestialObject.PositionY})", font, new SolidBrush(Color.DimGray), new PointF(screenCoordinates.X - 15, screenCoordinates.Y));
            }
        }

        public static void DrawCelestialObjectDirection(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            float[] dashValues = { 2, 2, 2, 2 };
            var blackPen = new Pen(Color.Black, 1) { DashPattern = dashValues };

            
            var additionalLenght = 0;

            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new Point(celestialObject.PositionX, celestialObject.PositionY));

            if (celestialObject.Classification == 2)
            {
                additionalLenght = UI.RotateImage(UI.LoadImage("PlayerSpaceship"), (float)celestialObject.Direction).Width / 2;
            }

            var directionCoordinates = Common.MoveCelestialObjects(screenCoordinates, celestialObject.Speed + additionalLenght, celestialObject.Direction);

            var pen = new Pen(Color.DimGray, 1) { StartCap = LineCap.ArrowAnchor };

            using (var capPath = new GraphicsPath())
            {
                const int triangleSize = 4;
                // A triangle
                capPath.AddLine(-triangleSize, 0, triangleSize, 0);
                capPath.AddLine(-triangleSize, 0, 0, triangleSize);
                capPath.AddLine(0, triangleSize, triangleSize, 0);

                pen.CustomEndCap = new CustomLineCap(null, capPath);

                graphics.DrawLine(pen, screenCoordinates.X, screenCoordinates.Y, directionCoordinates.X, directionCoordinates.Y);
                graphics.DrawLine(blackPen, screenCoordinates.X, screenCoordinates.Y, directionCoordinates.X, directionCoordinates.Y);
            }


            
        }

        public static void DrawTrajectory(ICelestialObject spaceShip, ICelestialObject targetObject, Graphics graphics, ScreenParameters screenParameters)
        {
            var pointCurrentLocation = new Point(spaceShip.PositionX, spaceShip.PositionY);
            var pointTargetLocation = new Point(targetObject.PositionX, targetObject.PositionY);
            var prevPointCurrentLocation = new Point(spaceShip.PositionX, spaceShip.PositionY);

            var result = Coordinates.GetTrajectoryApproach(pointCurrentLocation, pointTargetLocation, spaceShip.Direction, spaceShip.Speed, 200);

            int temp = 0;
            int iteration = 0;

            var screenCurrentObjectLocation = new Point(0, 0);
            var screenPreviousObjectLocation = new Point(0, 0);

            bool isDrawConnectionLine = true;

            var points = new List<Point>(); ;

            foreach (var objectLocation in result)
            {
                screenCurrentObjectLocation = UI.ToScreenCoordinates(screenParameters, objectLocation.Coordinates);

                points.Add(new Point(screenCurrentObjectLocation.X, screenCurrentObjectLocation.Y));
            }


            if (points.Count < 2)
                return;

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // Draw arc to screen.
            graphics.DrawLines(new Pen(Color.FromArgb(18, 18, 18), 4), points.ToArray());
            graphics.DrawLines(new Pen(Color.FromArgb(22, 22, 22), 2), points.ToArray());
            graphics.DrawLines(new Pen(Color.FromArgb(28, 28, 28), 1), points.ToArray());

            foreach (var objectLocation in result)
            {
                iteration++;

                var pen = new Pen(Color.Black, 1);// { StartCap = LineCap.ArrowAnchor };

                screenCurrentObjectLocation = UI.ToScreenCoordinates(screenParameters, objectLocation.Coordinates);
                screenPreviousObjectLocation = UI.ToScreenCoordinates(screenParameters, prevPointCurrentLocation);

                Point[] linePoints =
                {
                    new Point(screenCurrentObjectLocation.X, screenCurrentObjectLocation.Y),
                    new Point(screenPreviousObjectLocation.X, screenPreviousObjectLocation.Y)
                };

                graphics.DrawLines(pen, linePoints);

                prevPointCurrentLocation = new Point(objectLocation.Coordinates.X, objectLocation.Coordinates.Y);

                temp++;
                if (temp == 1)
                {
                    temp = 0;
                    graphics.FillEllipse(new SolidBrush(Color.DarkOliveGreen), screenCurrentObjectLocation.X - 1, screenCurrentObjectLocation.Y - 1, 3, 3);
                }

                if (objectLocation.IsLinearMotion && isDrawConnectionLine)
                {
                    //graphics.FillEllipse(new SolidBrush(Color.Yellow), screenCurrentObjectLocation.X - 1, screenCurrentObjectLocation.Y - 1, 3, 3);

                    //isDrawConnectionLine = false;
                }

                //Logger.Debug($"iteration = {iteration} Coordinates = {objectLocation.Coordinates} IsLinearMotion = {objectLocation.IsLinearMotion} VectorToTarget = {objectLocation.VectorToTarget} Direction = {objectLocation.Direction} Distance = {objectLocation.Distance}");
            }
        }

        public static void DrawPreTarget(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new Point(celestialObject.PositionX, celestialObject.PositionY));

            var image = UI.LoadGenericImage("Targets/TargetOnMap");

            //graphics.DrawImage(image, new PointF(screenCoordinates.X - image.Width / 2, screenCoordinates.Y - image.Height / 2));

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
            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new Point(celestialObject.PositionX, celestialObject.PositionY));

            var radarLinePen = new Pen(Color.FromArgb(60, 60, 60), 1);

            var screenSpaceShipCoordinates = UI.ToScreenCoordinates(screenParameters, new Point(spaceShip.PositionX, spaceShip.PositionY));


            //graphics.DrawLine(radarLinePen, screenSpaceShipCoordinates.X, screenSpaceShipCoordinates.Y, screenCoordinates.X, screenCoordinates.Y);


            graphics.DrawLine(radarLinePen, screenCoordinates.X - 15, screenCoordinates.Y, screenCoordinates.X + 15, screenCoordinates.Y);

            graphics.DrawLine(radarLinePen, screenCoordinates.X, screenCoordinates.Y - 15, screenCoordinates.X, screenCoordinates.Y + 15);

            graphics.FillEllipse(new SolidBrush(Color.Black), screenCoordinates.X - 5, screenCoordinates.Y - 5, 10, 10);
        }
    }
}
