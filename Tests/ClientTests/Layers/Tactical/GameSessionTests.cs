using Engine.Layers.Tactical;
using LanguageExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            Assert.AreEqual(7, spaceShip.Modules.Count);
        }

        

    }
}
