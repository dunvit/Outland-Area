using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngineCore.Session;
using Outland_Area_CoreTests;

namespace EngineCore.Tests
{
    [TestClass()]
    public class LocalGameServerTests
    {
        [TestMethod()]
        public void GameSessionToSessionTransfer_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("General");

            var gameSession = EnvironmentGlobal.GetSessionServerSide(server);

            var sessionDto = gameSession.ToSessionTransfer();

            Assert.AreEqual(gameSession.IsPause, sessionDto.IsPause);
            Assert.AreEqual(gameSession.ScenarioName, sessionDto.ScenarioName);
            Assert.AreEqual(gameSession.Turn, sessionDto.Turn);
            Assert.AreEqual(gameSession.Rules.IsEventsEnabled, sessionDto.Rules.IsEventsEnabled);
            Assert.AreEqual(gameSession.Rules.Spawn.AsteroidSmallSize, sessionDto.Rules.Spawn.AsteroidSmallSize);
            Assert.AreEqual(gameSession.GetCelestialObjects().Count, sessionDto.CelestialObjects.Count);
            Assert.AreEqual(gameSession.GetCelestialObjects()[0].Id, sessionDto.CelestialObjects[0].Id);
            Assert.AreEqual(gameSession.GameEvents.Count, sessionDto.GameEvents.Count);
            Assert.AreEqual(gameSession.TurnHistory.Count, sessionDto.TurnHistory.Count);
        }

        [TestMethod()]
        public void GameSessionFromSessionTransfer_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("General");

            var gameSession = EnvironmentGlobal.GetSessionServerSide(server);

            var sessionDto = gameSession.ToSessionTransfer();

            var gameSessionFromTransfer = new GameSession(sessionDto);

            Assert.AreEqual(gameSessionFromTransfer.IsPause, sessionDto.IsPause);
            Assert.AreEqual(gameSessionFromTransfer.ScenarioName, sessionDto.ScenarioName);
            Assert.AreEqual(gameSessionFromTransfer.Turn, sessionDto.Turn);
            Assert.AreEqual(gameSessionFromTransfer.Rules.IsEventsEnabled, sessionDto.Rules.IsEventsEnabled);
            Assert.AreEqual(gameSessionFromTransfer.Rules.Spawn.AsteroidSmallSize, sessionDto.Rules.Spawn.AsteroidSmallSize);
            Assert.AreEqual(gameSessionFromTransfer.GetCelestialObjects().Count, sessionDto.CelestialObjects.Count);
            Assert.AreEqual(gameSessionFromTransfer.GetCelestialObjects()[0].Id, sessionDto.CelestialObjects[0].Id);
            Assert.AreEqual(gameSessionFromTransfer.GameEvents.Count, sessionDto.GameEvents.Count);
            Assert.AreEqual(gameSessionFromTransfer.TurnHistory.Count, sessionDto.TurnHistory.Count);
        }

        [TestMethod()]
        public void GameSessionClone_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("General");

            var gameSession = EnvironmentGlobal.GetSessionServerSide(server);

            var sessionDto = gameSession.ToSessionTransfer();

            var gameSessionCloned = new GameSession(gameSession.Clone());

            Assert.AreEqual(gameSessionCloned.IsPause, sessionDto.IsPause);
            Assert.AreEqual(gameSessionCloned.ScenarioName, sessionDto.ScenarioName);
            Assert.AreEqual(gameSessionCloned.Turn, sessionDto.Turn);
            Assert.AreEqual(gameSessionCloned.Rules.IsEventsEnabled, sessionDto.Rules.IsEventsEnabled);
            Assert.AreEqual(gameSessionCloned.Rules.Spawn.AsteroidSmallSize, sessionDto.Rules.Spawn.AsteroidSmallSize);
            Assert.AreEqual(gameSessionCloned.GetCelestialObjects().Count, sessionDto.CelestialObjects.Count);
            Assert.AreEqual(gameSessionCloned.GetCelestialObjects()[0].Id, sessionDto.CelestialObjects[0].Id);
            Assert.AreEqual(gameSessionCloned.GameEvents.Count, sessionDto.GameEvents.Count);
            Assert.AreEqual(gameSessionCloned.TurnHistory.Count, sessionDto.TurnHistory.Count);
        }
    }
}