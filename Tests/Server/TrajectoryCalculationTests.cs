using System.Drawing;
using Engine.Common.Geometry.Trajectory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Server
{
    [TestClass]
    public class TrajectoryCalculationTests
    {

        [TestMethod]
        public void LinearMovementTrajectoryTest()
        {
            var pointFrom = new PointF(0, 0);
            var pointTo = new PointF(50, 0);

            var result = Approach.LinearMovement(pointFrom, pointTo);

            Assert.AreEqual(50, result.Count);

            result = Approach.LinearMovement(new PointF(0, 0), new PointF(5, 5));

            Assert.AreEqual(8, result.Count);
        }
    }
}
