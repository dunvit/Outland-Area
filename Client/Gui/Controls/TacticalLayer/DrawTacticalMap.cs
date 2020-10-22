using System.Drawing;
using System.Drawing.Drawing2D;
using Engine.Configuration;
using Engine.Gui;
using Engine.Layers.Tactical;
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

            var bmpSpacecraft = UI.RotateImage(UI.LoadImage(mainIcon), celestialObject.Direction);

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

        public static void DrawCelestialObjectCoordinates(CelestialMap celestialMap, Graphics graphics, ScreenParameters screenParameters)
        {
            foreach (var celestialObject in celestialMap.CelestialObjects)
            {
                var screenCoordinates = UI.ToScreenCoordinates(screenParameters,
                    new Point(celestialObject.PositionX - 25, celestialObject.PositionY + 5));

                using (var font = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel))
                {
                    graphics.DrawString($"({celestialObject.PositionX} : {celestialObject.PositionY})", font, new SolidBrush(Color.DimGray), new PointF(screenCoordinates.X - 15, screenCoordinates.Y));
                }

            }
        }

        public static void DrawCelestialObjectDirections(CelestialMap celestialMap, Graphics graphics, ScreenParameters screenParameters)
        {
            float[] dashValues = { 2, 2, 2, 2 };
            var blackPen = new Pen(Color.Black, 1) { DashPattern = dashValues };

            foreach (var celestialObject in celestialMap.CelestialObjects)
            {
                var additionalLenght = 0;

                var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new Point(celestialObject.PositionX, celestialObject.PositionY));

                if (celestialObject.Classification == 2)
                {
                    additionalLenght = UI.RotateImage(UI.LoadImage("PlayerSpaceship"), celestialObject.Direction).Width / 2;
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
        }

        
    }
}
