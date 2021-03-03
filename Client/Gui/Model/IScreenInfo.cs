using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Gui.Model
{
    public interface IScreenInfo
    {
        Point Center { get; }
        int Width { get; }
        int Height { get; }
        int DrawInterval { get; set; }
        Point CenterScreenOnMap { get; set; }

        IMapDrawSettings Settings { get; set; }
    }
}
