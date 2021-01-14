using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaCommon.Tactical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutlandAreaLocalServer;

namespace OutlandAreaCommon.Tactical.Tests
{
    [TestClass()]
    public class GameSessionTests
    {
        private static int sessionID = 0;

        private static LocalGameServer CreateGameServer(string sessionName)
        {
            var localServer = new LocalGameServer();

            localServer.Initialization(sessionName);

            return localServer;
        }

        [TestMethod()]
        public void AddMessageTest()
        {
            var localServer = CreateGameServer("MessageTest");

            var gameSession = localServer.RefreshGameSession(sessionID);

            Assert.AreEqual(0, gameSession.GetCurrentTurnMessage().Count);

            localServer.ResumeSession(sessionID);

            localServer.TurnCalculation();

            Assert.AreEqual(0, gameSession.GetCurrentTurnMessage().Count);

            gameSession = localServer.RefreshGameSession(sessionID);

            gameSession.AddMessage(new Message{CelestialObjectId = 1, IsOpenWindow = true, Type = MessageTypes.AnomalyFound});

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession(sessionID);

            gameSession.AddMessage(new Message { CelestialObjectId = 2, IsOpenWindow = true, Type = MessageTypes.AnomalyFound });

            gameSession.AddMessage(new Message { CelestialObjectId = 3, IsOpenWindow = true, Type = MessageTypes.AnomalyFound });

            Assert.AreEqual(2, gameSession.GetCurrentTurnMessage().Count);

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession(sessionID);

            Assert.AreEqual(2, gameSession.GetTurnMessage(2).Count);
            Assert.AreEqual(1, gameSession.GetTurnMessage(1).Count);
        }
    }
}