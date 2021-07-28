using System.Drawing;
using Engine.UI.DrawEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Outland_Area_CoreTests.UI.DrawEngine
{
    [TestClass]
    public class DrawTacticalMapTests
    {
        [TestMethod]
        public void CalculateLineByAngleTest()
        {
            var result = DrawTacticalMap.CalculateLineByAngle(new PointF(100, 100), 90, 50);

            Assert.AreEqual(result.From, new PointF(150, 100));

            Assert.AreEqual(result.To, new PointF(50, 100));

            result = DrawTacticalMap.CalculateLineByAngle(new PointF(100, 100), 180, 50);

            Assert.AreEqual(result.From, new PointF(100, 150));

            Assert.AreEqual(result.To, new PointF(100, 50));
        }
    }
}