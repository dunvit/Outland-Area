using System.Drawing;
using Engine.Layers.Tactical;

namespace Engine.Configuration
{
    public class ScreenParameters
    {
        public Point Center { get; }
        public int Width { get; }
        public int Height { get; }
        public int DrawInterval { get; set; }
        public Point CenterScreenOnMap { get; set; }
        public MapSettings Settings { get; } = new MapSettings();

        public ScreenParameters(int width, int height, int centerScreenX = 10000, int centerScreenY = 10000)
        {
            Center = new Point(width / 2, height / 2);

            // Start player ship coordinates in each battle (10000, 10000)
            CenterScreenOnMap = new Point(centerScreenX, centerScreenY);

            Width = width;
            Height = height;
        }
    }
}
