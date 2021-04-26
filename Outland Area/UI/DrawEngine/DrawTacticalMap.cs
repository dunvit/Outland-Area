using System;
using System.Drawing;
using Engine.UI.Model;

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
    }
}
