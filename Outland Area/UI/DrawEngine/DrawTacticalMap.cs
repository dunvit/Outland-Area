using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Engine.Layers.Tactical;
using Engine.UI.Model;
using Engine.UI.ScreenDrawing;
using EngineCore.Geometry;
using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;

namespace Engine.UI.DrawEngine
{
    public class DrawTacticalMap
    {
        public static void DrawBackGround(IScreenInfo screenInfo)
        {
            try
            {
                screenInfo.GraphicSurface.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, screenInfo.Width, screenInfo.Height));

            }
            catch 
            {
                
            }
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

        
        public static void DrawActiveCelestialObjects(IScreenInfo screenInfo, TacticalEnvironment environment)
        {
            var activeObject = environment.GetActiveObject();

            if (activeObject is null) return;

            var pen = new Pen(Color.Gray);

            var spaceshipScreenLocation = UITools.ToScreenCoordinates(screenInfo, activeObject.GetLocation());

            screenInfo.GraphicSurface.DrawEllipse(pen, spaceshipScreenLocation.X - 20, spaceshipScreenLocation.Y - 20, 40, 40);

            var mouseScreenLocation = UITools.ToScreenCoordinates(screenInfo, environment.GetMouseCoordinates());

            var distance = GeometryTools.Distance(spaceshipScreenLocation, mouseScreenLocation);
            var direction = GeometryTools.Azimuth(spaceshipScreenLocation, mouseScreenLocation);

            var destinationPoint = GeometryTools.MoveObject(mouseScreenLocation, distance - 20, direction);

            if(distance  > 20)
                screenInfo.GraphicSurface.DrawLine(pen, mouseScreenLocation.X, mouseScreenLocation.Y, destinationPoint.X, destinationPoint.Y);
        }

        public static void DrawCelestialObjects(IScreenInfo screenInfo, TacticalEnvironment environment)
        {
            foreach (var currentObject in environment.Session.GetCelestialObjects())
            {
                switch ((CelestialObjectTypes)currentObject.Classification)
                {
                    case CelestialObjectTypes.Missile:
                        break;
                    case CelestialObjectTypes.SpaceshipPlayer:
                        DrawSpaceship(screenInfo, currentObject);
                        break;
                    case CelestialObjectTypes.SpaceshipNpcNeutral:
                        DrawSpaceship(screenInfo, currentObject);
                        break;
                    case CelestialObjectTypes.SpaceshipNpcEnemy:
                        DrawSpaceship(screenInfo, currentObject);
                        break;
                    case CelestialObjectTypes.SpaceshipNpcFriend:
                        DrawSpaceship(screenInfo, currentObject);
                        break;
                    case CelestialObjectTypes.Asteroid:
                        DrawAsteroid(screenInfo, currentObject);
                        break;
                    case CelestialObjectTypes.Explosion:
                        break;
                }

            }
        }

        private static void DrawAsteroid(IScreenInfo screenInfo, ICelestialObject spaceShip)
        {
            var screenCoordinates = UITools.ToScreenCoordinates(screenInfo, new PointF(spaceShip.PositionX, spaceShip.PositionY));

            var color = Color.Gray;

            screenInfo.GraphicSurface.FillEllipse(new SolidBrush(color), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);
            screenInfo.GraphicSurface.DrawEllipse(new Pen(color), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);
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

        public static void DrawDirections(IScreenInfo screenInfo, TacticalEnvironment environment)
        {
            var color = Color.DimGray;

            foreach (var currentObject in environment.Session.GetCelestialObjects())
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
                        color = Color.DimGray;
                        break;
                    case CelestialObjectTypes.Explosion:
                        break;
                }

                SpaceMapGraphics.DrawArrow(screenInfo, currentObject, color);
            }
        }

        public static void DrawHistoryTrajectory(IScreenInfo screenInfo, TacticalEnvironment environment, Hashtable history)
        {
            foreach (var currentObject in environment.Session.GetCelestialObjects())
            {
                if (!history.ContainsKey(currentObject.Id)) continue;

                var results = ((FixedSizedQueue<PointF>)history[currentObject.Id]).GetData();

                var points = new List<PointF>();

                foreach (var position in results)
                {
                    var screenCoordinates = UITools.ToScreenCoordinates(screenInfo, position);

                    points.Add(new PointF(screenCoordinates.X, screenCoordinates.Y));
                }

                var pen = new Pen(Color.FromArgb(77, 77, 77)){DashStyle = DashStyle.Dot};

                screenInfo.GraphicSurface.DrawCurve(pen, points.ToArray());
            }
        }

        private static void DrawSelectingTarget(IScreenInfo screenInfo, TacticalEnvironment environment)
        {
            var pen = new Pen(Color.BurlyWood);

            var spaceshipScreenLocation = UITools.ToScreenCoordinates(screenInfo, environment.Session.GetPlayerSpaceShip().GetLocation());
            var mouseScreenLocation = UITools.ToScreenCoordinates(screenInfo, environment.MouseLocation);

            screenInfo.GraphicSurface.DrawLine(pen, spaceshipScreenLocation.X, spaceshipScreenLocation.Y, mouseScreenLocation.X, mouseScreenLocation.Y);
        }

        private static void DrawSelectingTargetWithActive(IScreenInfo screenInfo, TacticalEnvironment environment)
        {
            var pen = new Pen(Color.DarkOliveGreen);

            var spaceshipScreenLocation = UITools.ToScreenCoordinates(screenInfo, environment.Session.GetPlayerSpaceShip().GetLocation());
            var mouseScreenLocation = UITools.ToScreenCoordinates(screenInfo, environment.GetActiveObject().GetLocation());

            var distance = GeometryTools.Distance(spaceshipScreenLocation, mouseScreenLocation);
            var direction = GeometryTools.Azimuth(mouseScreenLocation, spaceshipScreenLocation);

            var destinationPoint = GeometryTools.MoveObject(spaceshipScreenLocation, distance - 15, direction);

            screenInfo.GraphicSurface.DrawLine(pen, spaceshipScreenLocation.X, spaceshipScreenLocation.Y, destinationPoint.X, destinationPoint.Y);

            screenInfo.GraphicSurface.DrawEllipse(pen, mouseScreenLocation.X - 15, mouseScreenLocation.Y - 15, 30, 30);
        }

        public static void DrawAction(IScreenInfo screenInfo, TacticalEnvironment environment)
        {
            switch (environment.Mode)
            {
                case TacticalMode.General:
                    break;
                case TacticalMode.SelectingSpaceObject:
                    DrawSelectingTarget(screenInfo, environment);
                    break;
                case TacticalMode.SelectingSpaceObjectWithActive:
                    DrawSelectingTargetWithActive(screenInfo, environment);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
