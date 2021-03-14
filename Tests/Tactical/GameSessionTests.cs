using OutlandAreaCommon.Tactical;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace OutlandAreaCommon.Tactical.Tests
{
    [TestClass()]
    public class GameSessionTests
    {

        [TestMethod()]
        public void GetObjectsByDistanceTests()
        {
            var localServer = EnvironmentGlobal.CreateGameServer("Session_ObjectsByDistance");

            var gameSession = localServer.RefreshGameSession();

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
            var localServer = EnvironmentGlobal.CreateGameServer("MessageTest");

            var gameSession = localServer.RefreshGameSession();

            Assert.AreEqual(0, gameSession.GetCurrentTurnEvents().Count);

            localServer.ResumeSession();

            localServer.TurnCalculation();

            Assert.AreEqual(0, gameSession.GetCurrentTurnEvents().Count);

            gameSession = localServer.RefreshGameSession();

            gameSession.AddEvent(new GameEvent { CelestialObjectId = 1, IsOpenWindow = true, Type = GameEventTypes.AnomalyFound });

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession();

            gameSession.AddEvent(new GameEvent { CelestialObjectId = 2, IsOpenWindow = true, Type = GameEventTypes.AnomalyFound });

            gameSession.AddEvent(new GameEvent { CelestialObjectId = 3, IsOpenWindow = true, Type = GameEventTypes.AnomalyFound });

            Assert.AreEqual(1, gameSession.GetCurrentTurnEvents().Count);

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession();

            Assert.AreEqual(2, gameSession.GetTurnEvents(3).Count);
            Assert.AreEqual(1, gameSession.GetTurnEvents(2).Count);


        }

        [TestMethod()]
        public void GetDialogTest()
        {
            var localServer = EnvironmentGlobal.CreateGameServer("General");

            var gameSession = localServer.RefreshGameSession();

            var dialogRow = gameSession.GetDialogRow(637066561468000000);

            Assert.AreEqual(637066561468000000, dialogRow.Id);
            Assert.AreEqual(1, dialogRow.Exits.Count);
            Assert.AreEqual(637066561468000000, dialogRow.CharacterId);
        }

        [TestMethod()]
        public void GetCharacterTest()
        {
            var localServer = EnvironmentGlobal.CreateGameServer("General");

            var gameSession = localServer.RefreshGameSession();

            var character = gameSession.GetCharacter(637066561468099897);

            Assert.AreEqual(637066561468099897, character.Id);
            Assert.AreEqual("Joanna Benbow", character.Name);
            Assert.AreEqual(637066561468043700, character.CelestialId);
            Assert.AreEqual("DFS-800 Viking", character.CelestialName);

            character = gameSession.GetCharacter(637066561468099897);

            Assert.AreEqual(637066561468099897, character.Id);
            Assert.AreEqual("Joanna Benbow", character.Name);
            Assert.AreEqual(637066561468043700, character.CelestialId);
            Assert.AreEqual("DFS-800 Viking", character.CelestialName);
        }
    }
}