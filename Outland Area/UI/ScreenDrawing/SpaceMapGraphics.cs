using System.Drawing;
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
            var leftArrowLine = SpaceMapTools.Move(line.PointTo.ToVector2(), arrowSize, line.Direction + 150);
            graphics.DrawLine(new Pen(color), leftArrowLine.PointFrom.X, leftArrowLine.PointFrom.Y, leftArrowLine.PointTo.X, leftArrowLine.PointTo.Y);

            // Arrow right line
            var rightArrowLine = SpaceMapTools.Move(line.PointTo.ToVector2(), arrowSize, line.Direction - 150);
            graphics.DrawLine(new Pen(color), rightArrowLine.PointFrom.X, rightArrowLine.PointFrom.Y, rightArrowLine.PointTo.X, rightArrowLine.PointTo.Y);

        }

        public static void DrawArrow(IScreenInfo screenInfo, ICelestialObject currentObject, Color color, int arrowSize = 4)
        {
            var screenCoordinates = UITools.ToScreenCoordinates(screenInfo, new PointF(currentObject.PositionX, currentObject.PositionY));

            var endArrowPoint = Coordinates.MoveObject(screenCoordinates, 12, currentObject.Direction);

            DrawArrow(screenInfo.GraphicSurface, new SpaceMapVector(screenCoordinates, endArrowPoint, currentObject.Direction), color, arrowSize);

        }
    }
}
