using System.Drawing;
using Engine.Gui.Model;
using Engine.Layers.Tactical;

namespace Engine.Configuration
{
    public class ScreenParameters : IScreenInfo
    {
        public Point Center { get; }
        public int Width { get; }
        public int Height { get; }
        public int DrawInterval { get; set; }
        public Point CenterScreenOnMap { get; set; }
        public IMapDrawSettings Settings { get; set; } = new MapSettings();

        public ScreenParameters(int width, int height, int centerScreenX = 10000, int centerScreenY = 10000)
        {
            Center = new Point(width / 2, height / 2);

            // Start player ship coordinates in each battle (10000, 10000)
            CenterScreenOnMap = new Point(centerScreenX, centerScreenY);

            Width = width;
            Height = height;
        }

        public Rectangle VisibleScreen()
        {
            return new Rectangle(CenterScreenOnMap.X - Width / 2,
                CenterScreenOnMap.Y - Height / 2,
                Width, Height);
        }

        public bool PointInVisibleScreen(float x, float y)
        {
            return VisibleScreen().Contains((int) x, (int) y);
        }

        public bool PointInVisibleScreen(PointF point)
        {
            return VisibleScreen().Contains((int)point.X, (int)point.Y);
        }
    }
}
