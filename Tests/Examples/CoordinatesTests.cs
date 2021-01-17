using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Server.DataProcessing.Trajectory;

namespace Tests.Examples
{
    [TestClass]
    public class CoordinatesTests
    {
        [TestMethod]
        public void GeneralTest()
        {
            var points = Coordinates.GetWayPoints(new Point(1, 1), new Point(4, 5), 4);

            //Assert.AreEqual(new PointF(1, 1), points[0]);
            //Assert.AreEqual(new PointF(1.75f, 2f), points[1]);
            //Assert.AreEqual(new PointF(2.5f, 3f), points[2]);
            //Assert.AreEqual(new PointF(3.25f, 4f), points[3]);
            //Assert.AreEqual(new PointF(4f, 5f), points[4]);
        }

        [TestMethod]
        public void OrbitTest()
        {
            //var points = Coordinates.GetRadiusPoint(new Point(0, 100), new Point(0, -100));

            //Assert.AreEqual(new PointF(-100, -99), Coordinates.GetRadiusPoint(new Point(0, 100), new Point(0, -100), 100));
            //Assert.AreEqual(new PointF(100, 100), Coordinates.GetRadiusPoint(new Point(-100, 0), new Point(100, 0), 100));
            //Assert.AreEqual(new PointF(200, -100), Coordinates.GetRadiusPoint(new Point(100, 100), new Point(100, -100), 100));

            //Assert.AreEqual(new PointF(10, -104), Coordinates.GetRadiusPoint(new Point(100, 100), new Point(110, -100), 100));

            //Assert.AreEqual(new PointF(1.75f, 2f), points[1]);
            //Assert.AreEqual(new PointF(2.5f, 3f), points[2]);
            //Assert.AreEqual(new PointF(3.25f, 4f), points[3]);
            //Assert.AreEqual(new PointF(4f, 5f), points[4]);
        }

        //Engine.Management.Server.DataProcessing.Trajectory
        [TestMethod]
        public void Trajectory_Line_Test()
        {
            //var from = new Point(0, 0);
            //var to = new Point(10, 0);
            //var direction = Coordinates.GetRotation(to, from);

            //var result = new Line().Calculate(from, to, direction, 1);

            //Assert.IsTrue(result.Count == 10);
            //Assert.AreEqual(result[0].Coordinates, new Point(1, 0));
            //Assert.AreEqual(result[4].Coordinates, new Point(5, 0));
            //Assert.AreEqual(result[9].Coordinates, to);

            //from = new Point(0, 0);
            //to = new Point(10, 10);
            //direction = Coordinates.GetRotation(to, from);

            //var result2 = new Line().Calculate(from, to, direction, 1);

            //Assert.IsTrue(result.Count == 10);
            //Assert.AreEqual(result2[0].Coordinates, new Point(0, 0));
            //Assert.AreEqual(result2[4].Coordinates, new Point(3, 3));
            //Assert.AreEqual(result2[14].Coordinates, to);
        }

    }
}
