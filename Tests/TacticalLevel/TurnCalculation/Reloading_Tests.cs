using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaLocalServer;

namespace Tests.TacticalLevel.TurnCalculation
{
    [TestClass]
    public class Reloading_Tests
    {
        private static int sessionID = 0;

        private static LocalGameServer CreateGameServer(string sessionName)
        {
            var localServer = new LocalGameServer();

            localServer.Initialization(sessionName);

            return localServer;
        }

        [TestMethod]
        public void WeaponModuleReloading_Test()
        {
            var localServer = CreateGameServer("WeaponModuleReloading_Test");

            var gameSession = localServer.RefreshGameSession(sessionID);

            var weaponModules = gameSession.GetPlayerSpaceShip().ToSpaceship().GetWeaponModules();

            Assert.AreEqual(1, weaponModules.Count);

            var weaponModule = weaponModules[0];

            Assert.AreEqual(weaponModule.ReloadTime, weaponModule.Reloading);

            localServer.ResumeSession(sessionID);

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession(sessionID);

            weaponModule = gameSession.GetPlayerSpaceShip().ToSpaceship().GetScanningModules()[0];

            Assert.AreEqual(1, gameSession.Turn);

            Assert.AreEqual(1, weaponModule.Reloading);

            for (var i = 1; i < weaponModule.ReloadTime; i++)
            {
                localServer.TurnCalculation();

                gameSession = localServer.RefreshGameSession(sessionID);

                weaponModule = gameSession.GetPlayerSpaceShip().ToSpaceship().GetScanningModules()[0];
            }

            Assert.AreEqual(weaponModule.ReloadTime, weaponModule.Reloading);

            localServer.TurnCalculation();

            Assert.AreEqual(weaponModule.ReloadTime, weaponModule.Reloading);
        }
    }
}
