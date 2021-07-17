using System.Linq;
using EngineCore;
using EngineCore.Session;
using EngineCore.Universe.Equipment;
using EngineCore.Universe.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Outland_Area_CoreTests.DataProcessing
{
    [TestClass()]
    public class WeaponShootingTests
    {
        [TestMethod]
        public void WeaponModule_Shot_Test()
        {
            var settings = new EngineSettings { DebugProperties = new DebugProperties(true, true) };

            var server = EnvironmentGlobal.CreateGameServer("CommandsTests_Weapon", settings);

            server.EnableDebugMode();

            var gameSession = EnvironmentGlobal.GetSession(server);

            var spaceship = gameSession.GetPlayerSpaceShip();

            var targetSpacecraft = gameSession.GetCelestialObject(1000348945).ToSpaceship();

            var module = spaceship.GetWeaponModules().First();

            IDebugProperties debug = new DebugProperties(true, true);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id, 1));

            Assert.AreEqual(1, server.Commands.Count);
            Assert.AreEqual(200, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.TurnCalculation(10);

            gameSession = EnvironmentGlobal.GetSession(server);

            spaceship = gameSession.GetPlayerSpaceShip();

            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(0, server.Commands.Count);
            Assert.AreEqual(170, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.Wait(5);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id, 1));
            server.TurnCalculation(10);
            gameSession = EnvironmentGlobal.GetSession(server);
            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(140, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id, 1));
            server.TurnCalculation(10);

            gameSession = EnvironmentGlobal.GetSession(server);
            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(110, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id, 1));
            server.TurnCalculation(10);

            gameSession = EnvironmentGlobal.GetSession(server);
            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(80, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id, 1));
            server.TurnCalculation(10);

            gameSession = EnvironmentGlobal.GetSession(server);
            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(50, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id, 1));
            server.TurnCalculation(10);

            gameSession = EnvironmentGlobal.GetSession(server);
            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(20, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id, 1));
            server.TurnCalculation(10);

            gameSession = EnvironmentGlobal.GetSession(server);
            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(true, targetSpacecraft.IsDestroyed);
        }

        [TestMethod]
        public void Explosive_Integration_Test()
        {
            var settings = new EngineSettings { DebugProperties = new DebugProperties(true, true) };

            var server = EnvironmentGlobal.CreateGameServer("CommandsTests_Weapon", settings);

            server.EnableDebugMode();

            var gameSession = EnvironmentGlobal.GetSession(server);

            var spaceship = gameSession.GetPlayerSpaceShip();

            var targetSpacecraft = gameSession.GetCelestialObject(1000348945).ToSpaceship();

            var module = spaceship.GetWeaponModules().First();

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id, 1));

            Assert.AreEqual(1, server.Commands.Count);
            Assert.AreEqual(200, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.TurnCalculation(1);

            gameSession = EnvironmentGlobal.GetSession(server);

            var explosives = gameSession.CelestialObjects.Where(obj => obj.OwnerId == 5005 && obj is Explosion).ToList();

            Assert.AreEqual(1, explosives.Count);

            server.TurnCalculation(1);

            explosives = gameSession.CelestialObjects.Where(obj => obj.OwnerId == 5005 && obj is Explosion).ToList();

            Assert.AreEqual(1, explosives.Count);

            gameSession = EnvironmentGlobal.Turn(20);

            explosives = gameSession.CelestialObjects.Where(obj => obj.OwnerId == 5005 && obj is Explosion).ToList();

            Assert.AreEqual(0, explosives.Count);
        }
    }
}
