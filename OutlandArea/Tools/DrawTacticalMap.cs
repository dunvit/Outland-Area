using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting.Messaging;
using OutlandArea.BL.Data;
using OutlandArea.Map;
using OutlandArea.TacticalBattleLayer;
using ICelestialObject = OutlandArea.Map.ICelestialObject;

namespace OutlandArea.Tools
{
    public class DrawTacticalMap
    {
        public static void DrawSpaceship(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            var mainColor = Color.DarkRed;
            var mainIcon = "EnemySpaceship";

            //if (isPlayerSpacecraft)
            //{
            mainIcon = "PlayerSpaceship";
            //}
            // Convert celestial object coordinates to screen coordinates
            var screenCoordinates = Common.ToScreenCoordinates(screenParameters, new Point(celestialObject.PositionX, celestialObject.PositionY));

            var bmpSpacecraft = UI.RotateImage(UI.LoadImage(mainIcon), celestialObject.Direction);

            graphics.DrawImage(bmpSpacecraft, new PointF(screenCoordinates.X - bmpSpacecraft.Width / 2, screenCoordinates.Y - bmpSpacecraft.Height / 2));

        }

        public static void DrawAsteroid(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            // Convert celestial object coordinates to screen coordinates
            var screenCoordinates = Common.ToScreenCoordinates(screenParameters, new Point(celestialObject.PositionX, celestialObject.PositionY));

            graphics.FillEllipse(new SolidBrush(Color.WhiteSmoke), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);
        }

        public static void DrawActiveCelestialObject(ICelestialObject celestialObject, Graphics graphics, ScreenParameters screenParameters)
        {
            if(celestialObject == null) return;

            var screenCoordinates = Common.ToScreenCoordinates(screenParameters, new Point(celestialObject.PositionX, celestialObject.PositionY));

            graphics.FillEllipse(new SolidBrush(Color.WhiteSmoke), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);

            graphics.FillEllipse(new SolidBrush(Color.WhiteSmoke), screenCoordinates.X - 5, screenCoordinates.Y - 5, 10, 10);

        }

        public static void DrawCelestialObjectCoordinates(CelestialMap celestialMap, Graphics graphics, ScreenParameters screenParameters)
        {
            foreach (var celestialObject in celestialMap.CelestialObjects)
            {
                var screenCoordinates = Common.ToScreenCoordinates(screenParameters,
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

                var screenCoordinates = Common.ToScreenCoordinates(screenParameters,
                    new Point(celestialObject.PositionX, celestialObject.PositionY));

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
