using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Universe.Objects;
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
        public void GetObjectsByDistanceTests()
        {
            var localServer = CreateGameServer("Session_ObjectsByDistance");

            var gameSession = localServer.RefreshGameSession(sessionID);

            Assert.AreEqual(4, gameSession.SpaceMap.CelestialObjects.Count);

            var objectsByDistance = gameSession.GetCelestialObjectsByDistance();

            Assert.AreEqual(3, objectsByDistance.Count);

            Assert.AreEqual("OBJ_01", objectsByDistance[0].Name);
            Assert.AreEqual("OBJ_03", objectsByDistance[1].Name);
            Assert.AreEqual("OBJ_02", objectsByDistance[2].Name);

            var closest = gameSession.GetCelestialObjectsByDistance().FirstOrDefault(o => o.IsScanned == false);

            Assert.AreEqual("OBJ_01", closest.Name);
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

            Assert.AreEqual(1, gameSession.GetCurrentTurnEvents().Count);

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession(sessionID);

            Assert.AreEqual(2, gameSession.GetTurnEvents(3).Count);
            Assert.AreEqual(1, gameSession.GetTurnEvents(2).Count);

            
        }
    }
}