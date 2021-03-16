using System.Collections.Immutable;
using System.Linq;
using Engine.Layers.Tactical;
using LanguageExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaCommon.Universe.Objects.Spaceships;
using OutlandAreaLocalServer;

namespace Tests.ClientTests.Layers.Tactical
{
    /// <summary>
    /// Summary description for GameSession
    /// </summary>
    [TestClass]
    public class GameSessionTests
    {
        [TestMethod]
        public void MapCelestialObjectsCountTest()
        {
            var _gameSession = ScenarioConvertor.LoadGameSession("Map_005");

            Assert.AreEqual(2, _gameSession.SpaceMap.CelestialObjects.Count);
        }

        [TestMethod]
        public void GetPlayerSpaceShipTest()
        {
            var gameSession = ScenarioConvertor.ToGameSession(ScenarioConvertor.GetSavedMap("PlayerSpaceShipTest"));

            Assert.AreEqual("HMS Glowworm", gameSession.GetPlayerSpaceShip().Name);
            Assert.AreEqual(90, gameSession.GetPlayerSpaceShip().Direction);
            Assert.AreEqual(10000, gameSession.GetPlayerSpaceShip().PositionX);
            Assert.AreEqual(10000, gameSession.GetPlayerSpaceShip().PositionY);

            var spaceShip = (Spaceship) gameSession.GetPlayerSpaceShip();

            Assert.AreEqual(8, spaceShip.Modules.Count);

            Assert.AreEqual(1, spaceShip.GetModules(Category.DeepScanner).Count);
            Assert.AreEqual(1, spaceShip.GetModules(Category.SpaceScanner).Count);
            Assert.AreEqual(2, spaceShip.GetModules(Category.Shield).Count);
            Assert.AreEqual(2, spaceShip.GetModules(Category.Reactor).Count);
            Assert.AreEqual(1, spaceShip.GetModules(Category.Weapon).Count);

            var deepScanners = spaceShip.GetModules(Category.DeepScanner);
            Assert.AreEqual(2, deepScanners[0].Compartment);
            Assert.AreEqual(2, deepScanners[0].Slot);

            var spaceScanners = spaceShip.GetModules(Category.SpaceScanner);
            Assert.AreEqual(2, spaceScanners[0].Compartment);
            Assert.AreEqual(1, spaceScanners[0].Slot);

            var compartmentModules = spaceShip.GetModules(2);
            Assert.AreEqual(2, compartmentModules.Count);
            Assert.AreEqual(2, compartmentModules[0].Compartment);
            Assert.AreEqual(1, compartmentModules[0].Slot);
            Assert.AreEqual(2, compartmentModules[1].Compartment);
            Assert.AreEqual(2, compartmentModules[1].Slot);

        }


        [TestMethod]
        public void LoadScenarioEventsTest()
        {
            var localServer = EnvironmentGlobal.CreateGameServer("LoadScenarioEvents");

            var gameSession = localServer.RefreshGameSession();

            Assert.AreEqual(1, gameSession.SpaceMap.CelestialObjects.Count);

            Assert.AreEqual(2, gameSession.ScenarioEvents.Count());

            Assert.AreEqual(10, gameSession.ScenarioEvents[0].Id);
            Assert.AreEqual(10, gameSession.ScenarioEvents[0].ToScenarioEventDialog().Id);
            Assert.AreEqual(7001, gameSession.ScenarioEvents[0].ToScenarioEventDialog().DialogId);


            localServer.ResumeSession();

            localServer.TurnCalculation();

            localServer.TurnCalculation();

            var gameSessionTurn1 = localServer.RefreshGameSession();
            
            Assert.AreEqual(1,gameSessionTurn1.GameEvents.Count);

            localServer.TurnCalculation();

            gameSessionTurn1 = localServer.RefreshGameSession();

            Assert.AreEqual(1, gameSessionTurn1.GameEvents.Count);

            localServer.TurnCalculation();

            gameSessionTurn1 = localServer.RefreshGameSession();

            Assert.AreEqual(2, gameSessionTurn1.GameEvents.Count);

            Assert.AreEqual(7001, gameSessionTurn1.GameEvents[1].DialogId);


        }
    }
}
