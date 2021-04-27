using System;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using Engine.Configuration;
using Engine.UI.Model;
using Engine.UI.ScreenDrawing;
using EngineCore.DataProcessing;
using EngineCore.Geometry;
using EngineCore.Session;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;

namespace Engine.UI.DrawEngine
{
    public class DrawTacticalMap
    {
        public static void DrawBackGround(IScreenInfo screenInfo)
        {
            screenInfo.GraphicSurface.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, screenInfo.Width, screenInfo.Height) );
        }

        public static void DrawGrid(IScreenInfo screenInfo)
        {
            double xLeftPosition = screenInfo.CenterScreenOnMap.X - screenInfo.Center.X;
            double yLeftPosition = screenInfo.CenterScreenOnMap.Y - screenInfo.Center.Y;

            DrawGridByStep(screenInfo, xLeftPosition, yLeftPosition, 10, Color.FromArgb(8, 8, 8));
            DrawGridByStep(screenInfo, xLeftPosition, yLeftPosition, 100, Color.FromArgb(18, 18, 18));
        }

        private static void DrawGridByStep(IScreenInfo screenInfo, double xLeftPosition, double yLeftPosition, int step, Color color)
        {
            var smallGridPen = new Pen(color);

            const int offsetX = 400;
            const int offsetY = 400;

            var leftCornerX = (int)Math.Round(xLeftPosition / step) * step - offsetX;
            var leftCornerY = (int)Math.Round(yLeftPosition / step) * step - offsetY;

            for (var i = leftCornerX;
                i < screenInfo.CenterScreenOnMap.X + screenInfo.Center.X + offsetX * 2;
                i += step)
            {
                var lineFrom = UITools.ToScreenCoordinates(screenInfo, new PointF(i, leftCornerY));
                var lineTo = UITools.ToScreenCoordinates(screenInfo, new PointF(i, leftCornerY + screenInfo.Height + offsetY));


                screenInfo.GraphicSurface.DrawLine(smallGridPen, lineFrom.X, lineFrom.Y, lineTo.X, lineTo.Y);
            }

            for (var i = leftCornerY;
                i < screenInfo.CenterScreenOnMap.Y + screenInfo.Center.Y + offsetY * 2;
                i += step)
            {
                var lineFrom = UITools.ToScreenCoordinates(screenInfo, new PointF(leftCornerX, i));
                var lineTo = UITools.ToScreenCoordinates(screenInfo, new PointF(leftCornerX + screenInfo.Width + offsetX * 2, i));


                screenInfo.GraphicSurface.DrawLine(smallGridPen, lineFrom.X, lineFrom.Y, lineTo.X, lineTo.Y);
            }
        }

        public static void DrawCelestialObjects(IScreenInfo screenInfo, GameSession gameSession)
        {
            foreach (var currentObject in gameSession.SpaceMap.CelestialObjects)
            {
                switch ((CelestialObjectTypes)currentObject.Classification)
                {
                    case CelestialObjectTypes.Missile:
                        break;
                    case CelestialObjectTypes.SpaceshipPlayer:
                        DrawSpaceship(screenInfo, currentObject);
                        break;
                    case CelestialObjectTypes.SpaceshipNpcNeutral:
                        break;
                    case CelestialObjectTypes.SpaceshipNpcEnemy:
                        break;
                    case CelestialObjectTypes.SpaceshipNpcFriend:
                        break;
                    case CelestialObjectTypes.Asteroid:
                        break;
                    case CelestialObjectTypes.Explosion:
                        break;
                }

            }
        }

        private static void DrawSpaceship(IScreenInfo screenInfo, ICelestialObject spaceShip)
        {
            var screenCoordinates = UITools.ToScreenCoordinates(screenInfo, new PointF(spaceShip.PositionX, spaceShip.PositionY));

            var ship = (Spaceship)spaceShip;
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

            screenInfo.GraphicSurface.FillEllipse(new SolidBrush(color), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);
            screenInfo.GraphicSurface.DrawEllipse(new Pen(color), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);
        }

        public static void DrawDirections(IScreenInfo screenInfo, GameSession gameSession)
        {
            var color = Color.DimGray;
            // TODO: Get color by space ship classification

            foreach (var currentObject in gameSession.SpaceMap.CelestialObjects)
            {
                switch ((CelestialObjectTypes)currentObject.Classification)
                {
                    case CelestialObjectTypes.Missile:
                        break;
                    case CelestialObjectTypes.SpaceshipPlayer:
                        color = Color.DarkOliveGreen;
                        break;
                    case CelestialObjectTypes.SpaceshipNpcNeutral:
                        color = Color.DarkGray;
                        break;
                    case CelestialObjectTypes.SpaceshipNpcEnemy:
                        color = Color.DarkRed;
                        break;
                    case CelestialObjectTypes.SpaceshipNpcFriend:
                        color = Color.SeaGreen;
                        break;
                    case CelestialObjectTypes.Asteroid:
                        break;
                    case CelestialObjectTypes.Explosion:
                        break;
                }

                SpaceMapGraphics.DrawArrow(screenInfo, currentObject, color);
            }
        }
    }
}
