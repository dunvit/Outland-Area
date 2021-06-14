using System.Drawing;
using EngineCore.Session;
using EngineCore.Universe.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Outland_Area_CoreTests.DataProcessing
{
    [TestClass()]
    public class CoordinatesTests
    {
        [TestMethod]
        public void LinearMovementCalculationTest()
        {

            var server = EnvironmentGlobal.CreateGameServer("Map_OneShip");

            var gameSession = server.RefreshGameSession(server.SessionId);

            var spaceShip = gameSession.GetCelestialObject(gameSession.Data.CelestialObjects[0].Id);

            var position = spaceShip.GetLocation();

            Assert.AreEqual(1, gameSession.Data.CelestialObjects.Count);
            Assert.AreEqual(new PointF(10000, 10000), position);

            server.TurnCalculation();

            gameSession = server.RefreshGameSession(server.SessionId);

            position = gameSession.GetCelestialObject(gameSession.Data.CelestialObjects[0].Id).GetLocation();

            Assert.AreEqual(new PointF((float) 10000.35, 10000), position);

            for(var i = 0; i < 19; i++)
                server.TurnCalculation();

            gameSession = server.RefreshGameSession(server.SessionId);

            position = gameSession.GetCelestialObject(gameSession.Data.CelestialObjects[0].Id).GetLocation();

            Assert.AreEqual(new PointF((float)10006.9922, 10000), position);
        }
    }
}