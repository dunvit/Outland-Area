using Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Outland_Area_CoreTests
{
    [TestClass()]
    public class GameManagerTests
    {
        [TestMethod()]
        public void StopAndResumeSession_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("OuterSpace");

            var gameManager = new GameManager(server);

            gameManager.SessionResume();

            Assert.IsFalse(server.RefreshGameSession(server.SessionId).IsPause);

            gameManager.GetDataFromServer();

            gameManager.SessionPause();

            Assert.IsTrue(server.RefreshGameSession(server.SessionId).IsPause);

            gameManager.SessionResume();

            Assert.IsFalse(server.RefreshGameSession(server.SessionId).IsPause);

            gameManager.SessionPause();

            Assert.IsTrue(server.RefreshGameSession(server.SessionId).IsPause);

            gameManager.SessionPause();

            Assert.IsTrue(server.RefreshGameSession(server.SessionId).IsPause);
        }
    }
}