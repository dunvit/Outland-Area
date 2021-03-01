using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.Propulsion;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace Tests.TacticalLevel.Session.Modules.Propulsion
{
    [TestClass]
    public class PropulsionTests
    {
        [TestMethod]
        public void Navigation_Turn_Test()
        {
            var localServer = EnvironmentGlobal.CreateGameServer("NavigationTests");

            var gameSession = localServer.RefreshGameSession();

            localServer.ResumeSession();

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession();

            Assert.AreEqual(2, gameSession.GetPlayerSpaceShip().Direction);

            var propModule = gameSession.GetPlayerSpaceShip().ToSpaceship().GetPropulsionModules().FirstOrDefault();

            localServer.Command(gameSession.Id, gameSession.GetPlayerSpaceShip().Id, propModule.Id, 0, 0, (int)CommandTypes.TurnLeft);

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession();

            Assert.AreEqual(363, gameSession.GetPlayerSpaceShip().Direction);

            var spaceShip = gameSession.GetPlayerSpaceShip();

            spaceShip.Direction = 210;

            localServer.ForceUpdate(spaceShip);

            gameSession = localServer.RefreshGameSession();

            Assert.AreEqual(210, gameSession.GetPlayerSpaceShip().Direction);

            spaceShip.Direction = 1;

            localServer.ForceUpdate(spaceShip);

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession();

            Assert.AreEqual(364, gameSession.GetPlayerSpaceShip().Direction);

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession();

            Assert.AreEqual(359, gameSession.GetPlayerSpaceShip().Direction);

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession();

            Assert.AreEqual(354, gameSession.GetPlayerSpaceShip().Direction);

            localServer.Command(gameSession.Id, gameSession.GetPlayerSpaceShip().Id, propModule.Id, 0, 0, (int)CommandTypes.TurnRight);

            localServer.TurnCalculation();

            gameSession = localServer.RefreshGameSession();

            Assert.AreEqual(359, gameSession.GetPlayerSpaceShip().Direction);
        }

        [TestMethod]
        public void GetPropulsionModuleTest()
        {
            var localServer = EnvironmentGlobal.CreateGameServer("Map_005");

            var gameSession = localServer.RefreshGameSession();

            var propulsionModules = gameSession.GetPlayerSpaceShip().ToSpaceship().GetModules(Category.Propulsion);

            Assert.AreEqual(1, propulsionModules.Count);

            var propulsionModule = propulsionModules.FirstOrDefault() as MicroWarpDrive;

            Assert.AreEqual("Civilian Prototype Mk I", propulsionModule.Name);
            Assert.AreEqual(2000, propulsionModule.Power);
            Assert.AreEqual(5005, propulsionModule.OwnerId);
            Assert.AreEqual(100, propulsionModule.ActivationCost);

            var propulsionModulesCategory = gameSession.GetPlayerSpaceShip().ToSpaceship().GetPropulsionModules();

            Assert.AreEqual(1, propulsionModulesCategory.Count);

            var propModule = propulsionModulesCategory.FirstOrDefault();

            Assert.AreEqual("Civilian Prototype Mk I", propModule.Name);
            Assert.AreEqual(2000, propModule.Power);
            Assert.AreEqual(5005, propModule.OwnerId);
            Assert.AreEqual(100, propModule.ActivationCost);
        }
    }
}
