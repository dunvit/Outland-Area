
using System.Drawing;

namespace Engine.UserControls
{
    internal class ScreenParameters
    {
        public Point Center { get; }
        public int Width { get; }
        public int Height { get; }

        public ScreenParameters(int width, int height)
        {
            Center = new Point(width/2, height/2);

            Width = width;
            Height = height;
        }
    }
}
