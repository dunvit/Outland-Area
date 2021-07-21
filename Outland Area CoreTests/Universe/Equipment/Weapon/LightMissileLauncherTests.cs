using EngineCore;
using EngineCore.Session;
using EngineCore.Universe.Equipment.Weapon;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Outland_Area_CoreTests.Universe.Equipment.Weapon
{
    [TestClass()]
    public class LightMissileLauncherTests
    {
        [TestMethod()]
        public void LightMissileLauncherTest()
        {
            var settings = new EngineSettings { DebugProperties = new DebugProperties(true, true) };

            var server = EnvironmentGlobal.CreateGameServer("CommandsTests_Weapon", settings);

            server.EnableDebugMode();

            var gameSession = EnvironmentGlobal.GetSession(server);

            var spaceship = gameSession.GetPlayerSpaceShip();

            var lightMissile = spaceship.Modules[1] as LightMissileLauncher;

            Assert.IsFalse(lightMissile is null);

            Assert.AreEqual(500, lightMissile.Range);
            Assert.AreEqual(0.7, lightMissile.Efficiency);
        }
    }
}