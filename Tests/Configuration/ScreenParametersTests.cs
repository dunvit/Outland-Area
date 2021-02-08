using System.Drawing;
using Engine.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Configuration
{
    [TestClass()]
    public class ScreenParametersTests
    {
        [TestMethod()]
        public void VisibleScreenTest()
        {
            var screen = new ScreenParameters(1920, 1080, 10000, 10000);

            Assert.AreEqual(new Rectangle(9040, 9460, 1920, 1080), screen.VisibleScreen());
        }

        [TestMethod()]
        public void PointOnScreenTest()
        {
            var screen = new ScreenParameters(1920, 1080);

            Assert.AreEqual(true, screen.PointInVisibleScreen(10400, 10400));
            Assert.AreEqual(false, screen.PointInVisibleScreen(9400, 12400));
        }
    }
}