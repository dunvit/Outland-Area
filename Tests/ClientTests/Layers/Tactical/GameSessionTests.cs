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
            var _gameSession = Convertor.ToGameSession(
                Convertor.GetSavedMap("Map_005"));

            Assert.AreEqual(2, _gameSession.SpaceMap.CelestialObjects.Count);
        }

        [TestMethod]
        public void GetPlayerSpaceShipTest()
        {
            var gameSession = Convertor.ToGameSession(
                Convertor.GetSavedMap("PlayerSpaceShipTest"));

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



    }
}
