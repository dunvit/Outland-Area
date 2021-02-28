using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace OutlandAreaCommon.Universe.Objects.Tests
{
    [TestClass()]
    public class MovementLogTests
    {
        [TestMethod()]
        public void UpdateTest()
        {
            var movementLog = new MovementLog(4);

            var localServer = EnvironmentGlobal.CreateGameServer("MovementLogTests");

            movementLog.Update(localServer.RefreshGameSession());

            Assert.IsTrue(movementLog.GetHistoryForCelestialObject(5005).Count == 2);

            Assert.AreEqual(movementLog.GetHistoryForCelestialObject(5005)[0].Coordinates, new PointF(8000, 10000));

            Assert.AreEqual(movementLog.GetHistoryForCelestialObject(5005)[1].Coordinates, new PointF(10000, 10000));

            localServer.TurnCalculation();

            movementLog.Update(localServer.RefreshGameSession());

            Assert.IsTrue(movementLog.GetHistoryForCelestialObject(5005).Count == 3);

            Assert.AreEqual(movementLog.GetHistoryForCelestialObject(5005)[0].Coordinates, new PointF(8000, 10000));

            Assert.AreEqual(movementLog.GetHistoryForCelestialObject(5005)[1].Coordinates, new PointF(10000, 10000));

            Assert.AreEqual(movementLog.GetHistoryForCelestialObject(5005)[2].Coordinates, new PointF(10005, 10000));

            localServer.TurnCalculation();

            movementLog.Update(localServer.RefreshGameSession());

            Assert.IsTrue(movementLog.GetHistoryForCelestialObject(5005).Count == 4);

            localServer.TurnCalculation();

            movementLog.Update(localServer.RefreshGameSession());

            Assert.IsTrue(movementLog.GetHistoryForCelestialObject(5005).Count == 4);

            //Assert.IsTrue(MovementLog.);
        }

        [TestMethod()]
        public void MovementLogEmptyTest()
        {
            var movementLog = new MovementLog(2);

            var localServer = EnvironmentGlobal.CreateGameServer("MovementLogTests");

            movementLog.Update(localServer.RefreshGameSession());

            Assert.IsTrue(movementLog.GetHistoryForCelestialObject(100).Count == 0);
        }
    }
}