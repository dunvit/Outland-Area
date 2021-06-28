using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Outland_Area_CoreTests.DAL
{
    [TestClass]
    public class GameSessionTurnsTests
    {
        [TestMethod()]
        public void TurnRecalculation_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("General");

            server.TurnCalculation(1);

            var gameSession = server.RefreshGameSession(server.SessionId);

            Assert.AreEqual(1, gameSession.Turn);

            server.TurnCalculation(5);

            gameSession = server.RefreshGameSession(server.SessionId);

            Assert.AreEqual(6, gameSession.Turn);
        }

        [TestMethod()]
        public void SessionId_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("General");

            server.TurnCalculation(1);

            var gameSession = server.RefreshGameSession(server.SessionId);

            Assert.AreEqual(1005302115, gameSession.Id);

            server.TurnCalculation(5);

            gameSession = server.RefreshGameSession(server.SessionId);

            Assert.AreEqual(1005302115, gameSession.Id);

            server = EnvironmentGlobal.CreateGameServer("Reloading");

            server.TurnCalculation(1);

            gameSession = server.RefreshGameSession(server.SessionId);

            Assert.AreEqual(1005302116, gameSession.Id);

            server.TurnCalculation(5);

            gameSession = server.RefreshGameSession(server.SessionId);

            Assert.AreEqual(1005302116, gameSession.Id);
        }
    }
}
