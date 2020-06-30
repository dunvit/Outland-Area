using System.Drawing;

namespace OutlandArea.TacticalBattleLayer
{
    internal class ScreenParameters
    {
        public Point Center { get; }
        public int Width { get; }
        public int Height { get; }

        public Point CenterScreenOnMap { get; set; }

        public ScreenParameters(int width, int height)
        {
            Center = new Point(width / 2, height / 2);

            // Start player ship coordinates in each battle (10000, 10000)
            CenterScreenOnMap = new Point(10000, 10000);

            Width = width;
            Height = height;
        }
    }
}
