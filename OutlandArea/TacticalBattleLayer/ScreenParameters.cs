using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandArea.TacticalBattleLayer
{
    internal class ScreenParameters
    {
        public Point Center { get; }
        public int Width { get; }
        public int Height { get; }

        public ScreenParameters(int width, int height)
        {
            Center = new Point(width / 2, height / 2);

            Width = width;
            Height = height;
        }
    }
}
