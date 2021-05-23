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

            Assert.AreEqual(3, server.GetCurrentGameSession(server.SessionId).SpaceMap.CelestialObjects.Count);

            var gameSession = server.RefreshGameSession(server.SessionId);

            Assert.AreEqual(2, gameSession.SpaceMap.CelestialObjects.Count);

            server.TurnCalculation(2);

            Assert.AreEqual(1, server.RefreshGameSession(server.SessionId).ScenarioEvents.Count);

            server.TurnCalculation(10);

            Assert.AreEqual(0, server.RefreshGameSession(server.SessionId).ScenarioEvents.Count);
        }
    }
}