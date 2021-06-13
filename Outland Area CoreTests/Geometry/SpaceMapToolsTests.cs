using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Engine.Configuration;

namespace EngineCore.Geometry.Tests
{
    [TestClass()]
    public class SpaceMapToolsTests
    {
        private readonly Point _centerScreenPosition = new Point(10000, 10000);

        private ScreenParameters GetScreen()
        {
            return
                new ScreenParameters(1920, 1080, _centerScreenPosition.X, _centerScreenPosition.Y)
                {
                    GraphicSurface = null
                };
        }

        [TestMethod()]
        public void ToRelativeCoordinatesTest()
        {
            var _screenParameters = GetScreen();

            var mouseScreenCoordinates = SpaceMapTools.ToRelativeCoordinates(new PointF(110, 120), _screenParameters.Center);

            Assert.AreEqual(new PointF(-850, -420), mouseScreenCoordinates);            
        }

        [TestMethod()]
        public void ToTacticalMapCoordinatesTest()
        {
            var _screenParameters = GetScreen();

            var mouseScreenCoordinates = SpaceMapTools.ToRelativeCoordinates(new PointF(110, 120), _screenParameters.Center);

            var mouseMapCoordinates = SpaceMapTools.ToTacticalMapCoordinates(mouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            Assert.AreEqual(new PointF(9150, 9580), mouseMapCoordinates);
        }

    }
}