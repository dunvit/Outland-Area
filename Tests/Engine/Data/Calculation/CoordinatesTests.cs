using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandArea.BL.Data.Calculation;

namespace Tests.Engine.Data.Calculation
{
    [TestClass]
    public class CoordinatesTests
    {
        [TestMethod]
        public void ApproachTests()
        {
            Assert.AreEqual(Coordinates.MoveObject(new Point(0, 0), 10, 0), new Point(0, -10));

            Assert.AreEqual(Coordinates.MoveObject(new Point(0, 0), 10, 45), new Point(7, -7));

            Assert.AreEqual(Coordinates.MoveObject(new Point(0, 0), 10, 90), new Point(10, 0));

            Assert.AreEqual(Coordinates.MoveObject(new Point(0, 0), 10, 135), new Point(7, 7));
        }


        [TestMethod]
        public void GetRotationInternalTests()
        {
            var pointShipLocation = new Point(20, 20);

            Assert.AreEqual(Coordinates.GetRotation(new Point(20, 10), pointShipLocation), 0);

            Assert.AreEqual(Coordinates.GetRotation(new Point(30, 10), pointShipLocation), 45);

            Assert.AreEqual(Coordinates.GetRotation(new Point(30, 20), pointShipLocation), 90);

            Assert.AreEqual(Coordinates.GetRotation(new Point(30, 30), pointShipLocation), 135);

            Assert.AreEqual(Coordinates.GetRotation(new Point(20, 30), pointShipLocation), 180);

            Assert.AreEqual(Coordinates.GetRotation(new Point(10, 30), pointShipLocation), 225);

            Assert.AreEqual(Coordinates.GetRotation(new Point(10, 20), pointShipLocation), 270);

            Assert.AreEqual(Coordinates.GetRotation(new Point(10, 10), pointShipLocation), 315);


            Assert.AreEqual(Coordinates.GetRotation(new Point(10100, 10200), new Point(10000, 10000)), 153);
        }

        [TestMethod]
        public void GetRotationAngleTest()
        {
            var pointShipLocation = new Point(20, 20);
            var agility = 5;

            Assert.AreEqual(Coordinates.GetRotationAngle(new Point(10095, 10132), new Point(10100, 10200), 175, agility), 175);

            Assert.AreEqual(Coordinates.GetRotationAngle(new Point(10095, 10137), new Point(10100, 10200), 175, agility), 175);


            // -- Direction 0
            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(20, 10), 45, agility), 40);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(20, 10), 315, agility), 320);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(20, 10), 180, agility), 175);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(20, 10), 0, agility), 0);

            // -- Direction 90

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(30, 20), 45, agility), 50);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(30, 20), 315, agility), 320);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(30, 20), 180, agility), 175);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(30, 20), 0, agility), 5);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(30, 20), 90, agility), 90);

            // -- Direction 180

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(20, 30), 45, agility), 50);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(20, 30), 315, agility), 310);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(20, 30), 180, agility), 180);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(20, 30), 0, agility), 5);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(20, 30), 90, agility), 95);

            // -- Direction 270

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(10, 20), 45, agility), 40);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(10, 20), 315, agility), 310);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(10, 20), 180, agility), 185);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(10, 20), 0, agility), 355);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(10, 20), 90, agility), 95);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(10, 20), 350, agility), 345);

            Assert.AreEqual(Coordinates.GetRotationAngle(pointShipLocation, new Point(10, 20), 5, agility), 0);




        }

        private static int ToDegrees(double Angle) => (int)(Angle * 180 / Math.PI);
    }
}
