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

            Assert.AreEqual(0, gameSession.GetCurrentTurnEvents().Count);

            localServer.ResumeSession(sessionID);

            localServer.TurnCalculation();

            Assert.AreEqual(0, gameSession.GetCurrentTurnEvents().Count);

            gameSession = localServer.RefreshGameSession(sessionID);

            gameSession.AddEvent(new GameEvent{CelestialObjectId = 1, IsOpenWindow = true, Type = GameEventTypes.AnomalyFound});

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession(sessionID);

            gameSession.AddEvent(new GameEvent { CelestialObjectId = 2, IsOpenWindow = true, Type = GameEventTypes.AnomalyFound });

            gameSession.AddEvent(new GameEvent { CelestialObjectId = 3, IsOpenWindow = true, Type = GameEventTypes.AnomalyFound });

            Assert.AreEqual(2, gameSession.GetCurrentTurnEvents().Count);

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession(sessionID);

            Assert.AreEqual(2, gameSession.GetTurnEvents(3).Count);
            Assert.AreEqual(2, gameSession.GetTurnEvents(2).Count);
        }
    }
}