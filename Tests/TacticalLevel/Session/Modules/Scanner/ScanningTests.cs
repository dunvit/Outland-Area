using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.General.Scanner;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaLocalServer;

namespace Tests.TacticalLevel.Session.Modules.Scanner
{
    [TestClass]
    public class ScanningTests
    {

        [TestMethod]
        public void ScanningModuleExistOnPlayerShip_Test()
        {
            var localServer = EnvironmentGlobal.CreateGameServer("Map_005");

            var gameSession = localServer.RefreshGameSession();

            var scanners = gameSession.GetPlayerSpaceShip().ToSpaceship().GetScanningModules();

            Assert.AreEqual(1, scanners.Count);

            var scannerModule = scanners[0];

            Assert.AreEqual(2000, scannerModule.ScanRange);
            Assert.AreEqual(55, scannerModule.Power);
            Assert.AreEqual(5005, scannerModule.OwnerId);
            Assert.AreEqual("SpaceScanner Mk I", scannerModule.Name);
            Assert.AreEqual(true, scannerModule.IsEnabled);
        }

        [TestMethod]
        public void DeepScanningModuleExistOnPlayerShip_Test()
        {
            var localServer = EnvironmentGlobal.CreateGameServer("Map_005");

            var gameSession = localServer.RefreshGameSession();

            var scanners = gameSession.GetPlayerSpaceShip().ToSpaceship().GetModules(Category.DeepScanner);

            Assert.AreEqual(1, scanners.Count);

            var scannerModule = (DeepScanner)scanners[0];

            Assert.AreEqual(300, scannerModule.ScanRange);
            Assert.AreEqual(60, scannerModule.Power);
            Assert.AreEqual(5005, scannerModule.OwnerId);
            Assert.AreEqual("DeepScanner Mk I", scannerModule.Name);
            Assert.AreEqual(false, scannerModule.IsEnabled);
        }

        [TestMethod]
        public void AutomaticExecuteScanningModule_Test()
        {
            var localServer = EnvironmentGlobal.CreateGameServer("ScanningModuleTest");

            var gameSession = localServer.RefreshGameSession();

            var scanners = gameSession.GetPlayerSpaceShip().ToSpaceship().GetScanningModules();

            Assert.AreEqual(1, scanners.Count);

            var scannerModule = scanners[0];

            Assert.AreEqual(scannerModule.ReloadTime, scannerModule.Reloading);

            localServer.ResumeSession();

            Assert.AreEqual(2, gameSession.SpaceMap.CelestialObjects.Count);

            localServer.TurnCalculation();

            var gameSessionTurn1 = localServer.RefreshGameSession();

            scannerModule = gameSessionTurn1.GetPlayerSpaceShip().ToSpaceship().GetScanningModules()[0];

            Assert.AreEqual(1, gameSessionTurn1.Turn);

            Assert.AreEqual(1, scannerModule.Reloading);

            Thread.Sleep(200);

            Assert.AreEqual(3, gameSessionTurn1.SpaceMap.CelestialObjects.Count);
        }

    }
}
