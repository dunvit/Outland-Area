using System.Drawing;
using Engine.Gui.Model;

namespace Engine.UI.Model
{
    public interface IScreenInfo
    {
        PointF Center { get; }
        float Width { get; }
        float Height { get; }
        int DrawInterval { get; set; }
        PointF CenterScreenOnMap { get; set; }

        Graphics GraphicSurface { get; set; }

        IMapDrawSettings Settings { get; set; }
    }
}
