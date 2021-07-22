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
using EngineCore.Universe.Equipment;
using EngineCore.Universe.Equipment.Weapon;
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
                        DrawMissile(screenInfo, currentObject);
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

        private static void DrawMissile(IScreenInfo screenInfo, ICelestialObject celestialObject)
        {
            var screenCoordinates = UITools.ToScreenCoordinates(screenInfo, new PointF(celestialObject.PositionX, celestialObject.PositionY));

            var missile = celestialObject as Missile;

            var color = Color.Blue;

            screenInfo.GraphicSurface.FillEllipse(new SolidBrush(color), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);
            screenInfo.GraphicSurface.DrawEllipse(new Pen(color), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);
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
            foreach (var currentObject in environment.Session.GetCelestialObjects())
            {
                Color color;

                switch ((CelestialObjectTypes)currentObject.Classification)
                {
                    case CelestialObjectTypes.Missile:
                        break;
                    case CelestialObjectTypes.SpaceshipPlayer:
                        color = Color.DarkOliveGreen;
                        SpaceMapGraphics.DrawArrow(screenInfo, currentObject, color);
                        break;
                    case CelestialObjectTypes.SpaceshipNpcNeutral:
                        color = Color.DarkGray;
                        SpaceMapGraphics.DrawArrow(screenInfo, currentObject, color);
                        break;
                    case CelestialObjectTypes.SpaceshipNpcEnemy:
                        color = Color.DarkRed;
                        SpaceMapGraphics.DrawArrow(screenInfo, currentObject, color);
                        break;
                    case CelestialObjectTypes.SpaceshipNpcFriend:
                        color = Color.SeaGreen;
                        SpaceMapGraphics.DrawArrow(screenInfo, currentObject, color);
                        break;
                    case CelestialObjectTypes.Asteroid:
                        color = Color.DimGray;
                        SpaceMapGraphics.DrawArrow(screenInfo, currentObject, color);
                        break;
                    case CelestialObjectTypes.Explosion:
                        break;
                }
            }
        }

        public static void DrawHistoryTrajectory(IScreenInfo screenInfo, TacticalEnvironment environment, Hashtable history)
        {
            foreach (var currentObject in environment.Session.GetCelestialObjects())
            {
                if (!history.ContainsKey(currentObject.Id)) continue;

                if(currentObject is Missile) continue;

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

            if (environment.GetActiveObject() is null) return;
            
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
                case TacticalMode.SelectingSpaceObjectForShot:
                    DrawWeaponAffectedAreaBorder(screenInfo, environment);
                    DrawSelectingTarget(screenInfo, environment);
                    break;
                case TacticalMode.SelectingSpaceObject:
                    DrawWeaponAffectedAreaBorder(screenInfo, environment);
                    DrawSelectingTarget(screenInfo, environment);
                    break;
                case TacticalMode.SelectingSpaceObjectWithActive:
                case TacticalMode.OpenFireScreen:
                    DrawWeaponAffectedAreaBorder(screenInfo, environment);
                    DrawSelectingTargetWithActive(screenInfo, environment);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void DrawExplosions(IScreenInfo screenInfo, TacticalEnvironment environment)
        {
            foreach (var currentObject in environment.Session.GetCelestialObjects())
            {
                if (!(currentObject is Explosion missile)) continue;

                var screenCoordinates = UITools.ToScreenCoordinates(screenInfo, new PointF(currentObject.PositionX, currentObject.PositionY));

                var radius = missile.RemoveTurn - environment.Session.Turn + missile.Radius;

                screenInfo.GraphicSurface.FillEllipse(new SolidBrush(Color.OrangeRed), screenCoordinates.X - radius / 2, screenCoordinates.Y - radius / 2, radius, radius);
                screenInfo.GraphicSurface.DrawEllipse(new Pen(Color.Brown), screenCoordinates.X - radius / 2, screenCoordinates.Y - radius / 2, radius, radius);
            }
        }

        public static void DrawWeaponAffectedArea(IScreenInfo screenInfo, TacticalEnvironment environment)
        {
            if (environment.Action is null) return;
            if (environment.Action.ModuleId == 0) return;

            var activeModule = environment.Session.GetPlayerSpaceShip().GetWeaponModule(environment.Action.ModuleId);

            if (activeModule is null) return;
            if (activeModule is IWeaponModule)
            {
                if (activeModule is IRange x)
                {
                    var screenCoordinates = UITools.ToScreenCoordinates(screenInfo, environment.Session.GetPlayerSpaceShip().GetLocation());

                    var radius = x.Range;

                    screenInfo.GraphicSurface.FillEllipse(new SolidBrush(Color.FromArgb(4,4,4)), screenCoordinates.X - radius, screenCoordinates.Y - radius, radius  * 2, radius * 2);
                    screenInfo.GraphicSurface.DrawEllipse(new Pen(Color.DimGray), screenCoordinates.X - radius, screenCoordinates.Y - radius, radius * 2, radius * 2);

                }
            }
        }
        public static void DrawWeaponAffectedAreaBorder(IScreenInfo screenInfo, TacticalEnvironment environment)
        {
            if (environment.Action is null) return;

            var activeModule = environment.Session.GetPlayerSpaceShip().GetWeaponModule(environment.Action.ModuleId);

            if (activeModule is null) return;
            
            if (activeModule is IRange x)
            {
                var screenCoordinates = UITools.ToScreenCoordinates(screenInfo, environment.Session.GetPlayerSpaceShip().GetLocation());

                var radius = x.Range;

                screenInfo.GraphicSurface.DrawEllipse(new Pen(Color.DimGray), screenCoordinates.X - radius, screenCoordinates.Y - radius, radius * 2, radius * 2);

                var efficiency = (int)(x.Efficiency * x.Range);

                screenInfo.GraphicSurface.DrawEllipse(new Pen(Color.DimGray), screenCoordinates.X - efficiency, screenCoordinates.Y - efficiency, efficiency * 2, efficiency * 2);


                #region Efficiency Cross
                var efficiencyCrossLineColor = new Pen(Color.DimGray);

                screenInfo.GraphicSurface.DrawLine(efficiencyCrossLineColor,
                    GeometryTools.MoveObject(screenCoordinates, 12, 0),
                    GeometryTools.MoveObject(screenCoordinates, x.Range + 12, 0));

                screenInfo.GraphicSurface.DrawLine(efficiencyCrossLineColor,
                    GeometryTools.MoveObject(screenCoordinates, 12, 180),
                    GeometryTools.MoveObject(screenCoordinates, x.Range + 12, 180));

                screenInfo.GraphicSurface.DrawLine(efficiencyCrossLineColor,
                    GeometryTools.MoveObject(screenCoordinates, 12, 90),
                    GeometryTools.MoveObject(screenCoordinates, x.Range + 12, 90));

                screenInfo.GraphicSurface.DrawLine(efficiencyCrossLineColor,
                    GeometryTools.MoveObject(screenCoordinates, 12, 270),
                    GeometryTools.MoveObject(screenCoordinates, x.Range + 12, 270));

                #endregion


                #region Efficiency Labels

                var efficiencyLineColor = new Pen(Color.Orange);
                var efficiencyTextColor = Color.Orange;

                #region 0% EFFICIENCY

                #region 90 degree

                var point1 = GeometryTools.MoveObject(screenCoordinates, x.Range, 90);

                var point2 = GeometryTools.MoveObject(point1, 50, 135);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point1, point2);

                var point3 = GeometryTools.MoveObject(point2, 110, 90);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point2, point3);

                var pointLabel = new PointF(point2.X + 5, point2.Y - 15);

                using var font1 = new Font("Times New Roman", 10, FontStyle.Bold, GraphicsUnit.Pixel);

                screenInfo.GraphicSurface.DrawString("0% EFFICIENCY", font1, new SolidBrush(efficiencyTextColor), pointLabel);

                #endregion

                #region 180 degree

                point1 = GeometryTools.MoveObject(screenCoordinates, x.Range, 180);

                point2 = GeometryTools.MoveObject(point1, 50, 225);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point1, point2);

                point3 = GeometryTools.MoveObject(point2, 110, 270);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point2, point3);

                pointLabel = new PointF(point2.X - 105, point2.Y - 15);

                screenInfo.GraphicSurface.DrawString("0% EFFICIENCY", font1, new SolidBrush(efficiencyTextColor), pointLabel);

                #endregion

                #region 270 degree

                point1 = GeometryTools.MoveObject(screenCoordinates, x.Range, 270);

                point2 = GeometryTools.MoveObject(point1, 50, 225);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point1, point2);

                point3 = GeometryTools.MoveObject(point2, 110, 270);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point2, point3);

                pointLabel = new PointF(point2.X - 105, point2.Y - 15);

                screenInfo.GraphicSurface.DrawString("0% EFFICIENCY", font1, new SolidBrush(efficiencyTextColor), pointLabel);

                #endregion

                #region 0 degree

                point1 = GeometryTools.MoveObject(screenCoordinates, x.Range, 0);

                point2 = GeometryTools.MoveObject(point1, 50, 225);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point1, point2);

                point3 = GeometryTools.MoveObject(point2, 110, 270);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point2, point3);

                pointLabel = new PointF(point2.X - 105, point2.Y - 15);

                screenInfo.GraphicSurface.DrawString("0% EFFICIENCY", font1, new SolidBrush(efficiencyTextColor), pointLabel);

                #endregion

                #endregion

                #region 0% EFFICIENCY

                #region 90 degree

                point1 = GeometryTools.MoveObject(screenCoordinates, efficiency, 90);

                point2 = GeometryTools.MoveObject(point1, 50, 135);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point1, point2);

                point3 = GeometryTools.MoveObject(point2, 110, 90);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point2, point3);

                pointLabel = new PointF(point2.X + 5, point2.Y - 15);

                screenInfo.GraphicSurface.DrawString("100% EFFICIENCY", font1, new SolidBrush(efficiencyTextColor), pointLabel);

                #endregion

                #region 180 degree

                point1 = GeometryTools.MoveObject(screenCoordinates, efficiency, 180);

                point2 = GeometryTools.MoveObject(point1, 50, 225);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point1, point2);

                point3 = GeometryTools.MoveObject(point2, 110, 270);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point2, point3);

                pointLabel = new PointF(point2.X - 105, point2.Y - 15);

                screenInfo.GraphicSurface.DrawString("100% EFFICIENCY", font1, new SolidBrush(efficiencyTextColor), pointLabel);

                #endregion

                #region 270 degree

                point1 = GeometryTools.MoveObject(screenCoordinates, efficiency, 270);

                point2 = GeometryTools.MoveObject(point1, 50, 225);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point1, point2);

                point3 = GeometryTools.MoveObject(point2, 110, 270);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point2, point3);

                pointLabel = new PointF(point2.X - 105, point2.Y - 15);

                screenInfo.GraphicSurface.DrawString("100% EFFICIENCY", font1, new SolidBrush(efficiencyTextColor), pointLabel);

                #endregion

                #region 0 degree

                point1 = GeometryTools.MoveObject(screenCoordinates, efficiency, 0);

                point2 = GeometryTools.MoveObject(point1, 50, 225);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point1, point2);

                point3 = GeometryTools.MoveObject(point2, 110, 270);

                screenInfo.GraphicSurface.DrawLine(efficiencyLineColor, point2, point3);

                pointLabel = new PointF(point2.X - 105, point2.Y - 15);

                screenInfo.GraphicSurface.DrawString("100% EFFICIENCY", font1, new SolidBrush(efficiencyTextColor), pointLabel);

                #endregion

                #endregion

                #endregion


            }

        }
    }
}
