using System.Threading;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaLocalServer;

namespace Tests.TacticalLevel.TurnCalculation
{
    [TestClass]
    public class Reloading_Tests
    {


        [TestMethod]
        public void WeaponModuleReloading_Test()
        {

            var a = new AClass().GetData(100000);

            var localServer = EnvironmentGlobal.CreateGameServer("WeaponModuleReloading_Test");

            var gameSession = localServer.RefreshGameSession();

            var weaponModules = gameSession.GetPlayerSpaceShip().ToSpaceship().GetWeaponModules();

            Assert.AreEqual(1, weaponModules.Count);

            var weaponModule = weaponModules[0];

            Assert.AreEqual(weaponModule.ReloadTime, weaponModule.Reloading);

            localServer.ResumeSession();

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession();

            weaponModule = gameSession.GetPlayerSpaceShip().ToSpaceship().GetScanningModules()[0];

            Assert.AreEqual(1, gameSession.Turn);

            Assert.AreEqual(1, weaponModule.Reloading);

            for (var i = 1; i < weaponModule.ReloadTime; i++)
            {
                localServer.TurnCalculation();

                gameSession = localServer.RefreshGameSession();

                weaponModule = gameSession.GetPlayerSpaceShip().ToSpaceship().GetScanningModules()[0];
            }

            Assert.AreEqual(weaponModule.ReloadTime, weaponModule.Reloading);

            localServer.TurnCalculation();

            Assert.AreEqual(weaponModule.ReloadTime, weaponModule.Reloading);
        }

        
    }

    [MemoryDiagnoser]
    public class AClass
    {

        [Benchmark]
        public int GetData(int count)
        {
            const int noNumbers = 10000000;  // 10 mil
            object o = null;
            for (int i = 0; i < noNumbers; i++)
            {
                o = i;
            }
            int v = (int)o;

            var result = 0;

            for (var i = 0; i < count; i++)
            {
                //Thread.Sleep(100);
                result++;
            }

            return count * 100;
        }
    }
}
