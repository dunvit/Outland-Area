using System.Drawing;
using Engine.Gui.Model;

namespace Engine.UI.Model
{
    public interface IScreenInfo
    {
        Point Center { get; }
        int Width { get; }
        int Height { get; }
        int DrawInterval { get; set; }
        Point CenterScreenOnMap { get; set; }

        Graphics GraphicSurface { get; set; }

        IMapDrawSettings Settings { get; set; }
    }
}
