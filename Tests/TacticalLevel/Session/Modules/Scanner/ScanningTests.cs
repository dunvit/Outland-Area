using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaLocalServer;

namespace Tests.TacticalLevel.Session.Modules.Scanner
{
    [TestClass]
    public class ScanningTests
    {
        private static int sessionID = 0;

        private static LocalGameServer CreateGameServer(string sessionName)
        {
            var localServer = new LocalGameServer();

            localServer.Initialization(sessionName);

            return localServer;
        }

        [TestMethod]
        public void ScanningModuleExistOnPlayerShip_Test()
        {
            var localServer = CreateGameServer("Map_005");

            var gameSession = localServer.RefreshGameSession(sessionID);

            var scanners = gameSession.GetPlayerSpaceShip().ToSpaceship().GetScanningModules();

            Assert.AreEqual(1, scanners.Count);

            var scannerModule = scanners[0];

            Assert.AreEqual(2000, scannerModule.ScanRange);
            Assert.AreEqual(55, scannerModule.Power);
            Assert.AreEqual(5005, scannerModule.OwnerId);
            Assert.AreEqual("Scanner Mk I", scannerModule.Name);
            Assert.AreEqual(true, scannerModule.IsEnabled);
        }

        [TestMethod]
        public void AutomaticExecuteScanningModule_Test()
        {
            var localServer = CreateGameServer("Map_005");

            var gameSession = localServer.RefreshGameSession(sessionID);

            var scanners = gameSession.GetPlayerSpaceShip().ToSpaceship().GetScanningModules();

            Assert.AreEqual(1, scanners.Count);

            var scannerModule = scanners[0];

            Assert.AreEqual(scannerModule.ReloadTime, scannerModule.Reloading);

            localServer.ResumeSession(sessionID);

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession(sessionID);

            scannerModule = gameSession.GetPlayerSpaceShip().ToSpaceship().GetScanningModules()[0];

            Assert.AreEqual(1, gameSession.Turn);

            Assert.AreEqual(1, scannerModule.Reloading);
        }

    }
}
