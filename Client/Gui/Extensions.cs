using System.Drawing;
using Engine.Configuration;

namespace Engine.Gui
{
    public static class Extensions
    {
        public static PointF ToScreen(this PointF point, ScreenParameters screenParameters)
        {
            return UI.ToScreenCoordinates(screenParameters, point);
        }
    }
}
