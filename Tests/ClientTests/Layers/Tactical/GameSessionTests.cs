using Engine.Layers.Tactical;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaCommon.Tactical;
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

            Assert.AreEqual(2, _gameSession.Map.CelestialObjects.Count);
        }

        [TestMethod]
        public void GetPlayerSpaceShipTest()
        {
            var _gameSession = Convertor.ToGameSession(
                Convertor.GetSavedMap("Map_005"));

            Assert.AreEqual("HMS Glowworm", _gameSession.GetPlayerSpaceShip().Name);
            Assert.AreEqual(90, _gameSession.GetPlayerSpaceShip().Direction);
            Assert.AreEqual(10000, _gameSession.GetPlayerSpaceShip().PositionX);
            Assert.AreEqual(10000, _gameSession.GetPlayerSpaceShip().PositionY);

            var spaceShip = (Spaceship) _gameSession.GetPlayerSpaceShip();

            Assert.AreEqual(6, spaceShip.Modules.Count);
        }
        
    }
}
