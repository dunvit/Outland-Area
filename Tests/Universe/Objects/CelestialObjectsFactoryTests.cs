using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace OutlandAreaCommon.Universe.Objects.Tests
{
    [TestClass]
    public class CelestialObjectsFactoryTests
    {
        [TestMethod]
        public void GenerateAsteroidTest()
        {
            var localServer = EnvironmentGlobal.CreateGameServer("CelestialObjectsFactoryTests");

            var gameSession = localServer.RefreshGameSession();

            var asteroid = CelestialObjectsFactory.GenerateAsteroid(gameSession);

            Assert.IsNotNull(asteroid);

            Assert.IsTrue(asteroid.Direction > 0 && asteroid.Direction <= 360);

            Assert.IsTrue(asteroid.Speed > 0 && asteroid.Speed <= 30);
        }
    }
}