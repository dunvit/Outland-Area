using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outland_Area_CoreTests;

namespace Engine.DAL.Tests
{
    [TestClass()]
    public class GameSessionRefreshTests
    {
        [TestMethod()]
        public void RequestGameSessionTest()
        {
            var server = EnvironmentGlobal.CreateGameServer("General");

            var refreshedGameSession = new GameSessionRefresh().RequestGameSession(server, server.SessionId);

            Assert.AreEqual(1, refreshedGameSession.Data.CelestialObjects.Count);
        }
    }
}