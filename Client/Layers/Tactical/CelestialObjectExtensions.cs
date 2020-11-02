using System.Drawing;
using System.Reflection;
using log4net;

namespace Engine.Layers.Tactical
{
    public static class CelestialObjectExtensions
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static Point GetLocation(this ICelestialObject celestialObject)
        {
            return new Point(celestialObject.PositionX, celestialObject.PositionY);
        }

    }
}
