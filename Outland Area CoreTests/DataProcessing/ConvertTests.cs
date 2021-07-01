using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outland_Area_CoreTests;

namespace EngineCore.DataProcessing.Tests
{
    [TestClass()]
    public class ConvertTests
    {
        [TestMethod()]
        public void ToClientTest()
        {
            var server = EnvironmentGlobal.CreateGameServer("ConvertTests");

            Assert.AreEqual(2, EnvironmentGlobal.GetSession(server).Data.CelestialObjects.Count);

            var gameSession = EnvironmentGlobal.GetSession(server);

            Assert.AreEqual(2, gameSession.Data.CelestialObjects.Count);

            server.TurnCalculation(2);

            Assert.AreEqual(1, EnvironmentGlobal.GetSessionServerSide(server).ScenarioEvents.Count);

            server.TurnCalculation(10);

            Assert.AreEqual(0, EnvironmentGlobal.GetSession(server).ScenarioEvents.Count);
        }
    }
}