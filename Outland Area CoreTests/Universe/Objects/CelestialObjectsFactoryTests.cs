using EngineCore;
using EngineCore.Universe.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Outland_Area_CoreTests.Universe.Objects
{
    [TestClass]
    public class CelestialObjectsFactoryTests
    {
        [TestMethod]
        public void GenerateNpcShip_Test()
        {
            var settings = new EngineSettings { DebugProperties = new DebugProperties(true, true) };

            var server = EnvironmentGlobal.CreateGameServer("General", settings);

            server.EnableDebugMode();

            var gameSession = EnvironmentGlobal.GetSession(server);

            var result = CelestialObjectsFactory.GenerateNpcShip(gameSession, 12, 12, 1).ToSpaceship();
            Assert.IsTrue(result.Id > 0);
            Assert.AreEqual(4, result.Modules.Count);
            Assert.AreEqual(6, result.MaxSpeed);
        }
    }
}