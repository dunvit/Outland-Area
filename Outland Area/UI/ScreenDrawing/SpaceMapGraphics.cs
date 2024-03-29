﻿using System.Drawing;
using System.Drawing.Drawing2D;
using Engine.UI.Model;
using EngineCore.DataProcessing;
using EngineCore.Geometry;
using EngineCore.Universe.Model;

namespace Engine.UI.ScreenDrawing
{
    public class SpaceMapGraphics
    {
        public static void DrawArrow(Graphics graphics, SpaceMapVector line, Color color, int arrowSize = 4)
        {
            // Base arrow line
            graphics.DrawLine(new Pen(color), line.PointFrom.X, line.PointFrom.Y, line.PointTo.X, line.PointTo.Y);

            // Arrow left line
            var leftArrowLine = GeometryTools.MoveObject(line.PointTo, arrowSize, line.Direction + 150);
            graphics.DrawLine(new Pen(color), line.PointTo.X, line.PointTo.Y, leftArrowLine.X, leftArrowLine.Y);

            // Arrow right line
            var rightArrowLine = GeometryTools.MoveObject(line.PointTo, arrowSize, line.Direction - 150);
            graphics.DrawLine(new Pen(color), line.PointTo.X, line.PointTo.Y, rightArrowLine.X, rightArrowLine.Y);

        }

        public static void DrawArrow(IScreenInfo screenInfo, ICelestialObject currentObject, Color color, int arrowSize = 4)
        {
            var screenCoordinates = UITools.ToScreenCoordinates(screenInfo, new PointF(currentObject.PositionX, currentObject.PositionY));

            var endArrowPoint = GeometryTools.MoveObject(screenCoordinates, 12, currentObject.Direction);

            DrawArrow(screenInfo.GraphicSurface, new SpaceMapVector(screenCoordinates, endArrowPoint, currentObject.Direction), color, arrowSize);
        }

        public static void DrawLongLine(IScreenInfo screenInfo, ICelestialObject currentObject, Color color)
        {
            var screenCoordinates = UITools.ToScreenCoordinates(screenInfo, new PointF(currentObject.PositionX, currentObject.PositionY));

            var line = new SpaceMapVector(
                screenCoordinates, 
                GeometryTools.MoveObject(screenCoordinates, 4000, currentObject.Direction), 
                currentObject.Direction);

            using var dashedPen = new Pen(color, 2) {DashStyle = DashStyle.DashDot};

            screenInfo.GraphicSurface.DrawLine(dashedPen, line.PointFrom.X, line.PointFrom.Y, line.PointTo.X, line.PointTo.Y);
        }
    }
}
