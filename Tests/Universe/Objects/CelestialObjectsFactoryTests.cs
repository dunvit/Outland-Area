using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaCommon.Universe.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutlandAreaLocalServer;

namespace OutlandAreaCommon.Universe.Objects.Tests
{
    [TestClass()]
    public class CelestialObjectsFactoryTests
    {
        private static int sessionID = 0;

        private static LocalGameServer CreateGameServer(string sessionName)
        {
            var localServer = new LocalGameServer();

            localServer.Initialization(sessionName);

            return localServer;
        }

        [TestMethod()]
        public void GenerateAsteroidTest()
        {
            var localServer = CreateGameServer("CelestialObjectsFactoryTests");

            var gameSession = localServer.RefreshGameSession(sessionID);

            var asteroid = CelestialObjectsFactory.GenerateAsteroid(gameSession);

            Assert.IsNotNull(asteroid);

            Assert.IsTrue(asteroid.Direction > 0 && asteroid.Direction <= 360);

            Assert.IsTrue(asteroid.Speed > 0 && asteroid.Speed <= 30);

        }
    }
}