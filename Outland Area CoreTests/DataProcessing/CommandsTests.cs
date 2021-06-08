using EngineCore;
using EngineCore.DataProcessing;
using EngineCore.Session;
using EngineCore.Universe.Equipment;
using EngineCore.Universe.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace Outland_Area_CoreTests.DataProcessing
{
    [TestClass()]
    public class CommandsTests
    {
        [TestMethod()]
        public void PropulsionModule_Braking_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("CommandsTests");

            var gameSession = server.RefreshGameSession(server.SessionId);

            var spaceship = gameSession.GetPlayerSpaceShip();

            var module = spaceship.GetPropulsionModules().First();            

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Braking));

            Assert.AreEqual(1, server.Commands.Count);

            Assert.AreEqual(7, gameSession.GetCelestialObject(spaceship.Id).Speed);

            server.TurnCalculation(1);

            gameSession = server.RefreshGameSession(server.SessionId);

            Assert.AreEqual(6, gameSession.GetCelestialObject(spaceship.Id).Speed);

            Assert.AreEqual(0, server.Commands.Count);

            Assert.AreEqual(1, server.GetHistoryCommands(server.SessionId, spaceship.Id).Count);

            server.TurnCalculation(1);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Braking));

            Assert.AreEqual(1, server.Commands.Count);

            server.TurnCalculation(1);

            Assert.AreEqual(0, server.Commands.Count);

            Assert.AreEqual(2, server.GetHistoryCommands(server.SessionId, spaceship.Id).Count);

            Assert.AreEqual(CommandTypes.StopShip, server.GetHistoryCommands(server.SessionId, spaceship.Id)[0].Type);
        }

        [TestMethod()]
        public void PropulsionModule_TurnRight_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("CommandsTests");

            var gameSession = server.RefreshGameSession(server.SessionId);

            var spaceship = gameSession.GetPlayerSpaceShip();

            var module = spaceship.GetPropulsionModules().First();

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.TurnRight));

            Assert.AreEqual(1, server.Commands.Count);

            server.TurnCalculation(1);

            gameSession = server.RefreshGameSession(server.SessionId);

            spaceship = gameSession.GetPlayerSpaceShip();

            Assert.AreEqual(90.5, spaceship.Direction);

            // Reloading time
            server.Wait(3);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.TurnRight));

            server.TurnCalculation(1);

            spaceship = server.RefreshGameSession(server.SessionId).GetPlayerSpaceShip();

            Assert.AreEqual(91, spaceship.Direction);

            server.TurnCalculation(1);

            spaceship = server.RefreshGameSession(server.SessionId).GetPlayerSpaceShip();

            Assert.AreEqual(91, spaceship.Direction);
        }

        [TestMethod()]
        public void PropulsionModule_TurnLeft_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("CommandsTests");

            var gameSession = server.RefreshGameSession(server.SessionId);

            var spaceship = gameSession.GetPlayerSpaceShip();

            var module = spaceship.GetPropulsionModules().First();

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.TurnLeft));

            Assert.AreEqual(1, server.Commands.Count);

            server.TurnCalculation(1);

            gameSession = server.RefreshGameSession(server.SessionId);

            spaceship = gameSession.GetPlayerSpaceShip();

            Assert.AreEqual(89.5, spaceship.Direction);

            // Reloading time
            server.Wait(3);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.TurnLeft));

            server.TurnCalculation(1);

            spaceship = server.RefreshGameSession(server.SessionId).GetPlayerSpaceShip();

            Assert.AreEqual(89, spaceship.Direction);

            server.TurnCalculation(1);

            spaceship = server.RefreshGameSession(server.SessionId).GetPlayerSpaceShip();

            Assert.AreEqual(89, spaceship.Direction);
        }

        [TestMethod]
        public void WeaponModule_Shot_Test()
        {
            var settings = new EngineSettings { DebugProperties = new DebugProperties(true, true) };

            var server = EnvironmentGlobal.CreateGameServer("CommandsTests_Map_FirstBattle", settings);

            var gameSession = server.RefreshGameSession(server.SessionId);

            var spaceship = gameSession.GetPlayerSpaceShip();

            var targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            var module = spaceship.GetWeaponModules().First();

            IDebugProperties debug = new DebugProperties(true, true);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id));

            Assert.AreEqual(1, server.Commands.Count);
            Assert.AreEqual(200, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.TurnCalculation(1);

            gameSession = server.RefreshGameSession(server.SessionId);

            spaceship = gameSession.GetPlayerSpaceShip();

            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(0, server.Commands.Count);
            Assert.AreEqual(170, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.TurnCalculation(5);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id));
            server.TurnCalculation(1);
            gameSession = server.RefreshGameSession(server.SessionId);
            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(140, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id));
            server.TurnCalculation(1);
            gameSession = server.RefreshGameSession(server.SessionId);
            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(110, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id));
            server.TurnCalculation(1);
            gameSession = server.RefreshGameSession(server.SessionId);
            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(80, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id));
            server.TurnCalculation(1);
            gameSession = server.RefreshGameSession(server.SessionId);
            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(50, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id));
            server.TurnCalculation(1);
            gameSession = server.RefreshGameSession(server.SessionId);
            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(20, targetSpacecraft.Shields);
            Assert.AreEqual(false, targetSpacecraft.IsDestroyed);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Shot, 1000348945, ((IModule)module).Id));
            server.TurnCalculation(1);
            gameSession = server.RefreshGameSession(server.SessionId);
            targetSpacecraft = gameSession.GetCelestialObject(1000348945, false).ToSpaceship();

            Assert.AreEqual(true, targetSpacecraft.IsDestroyed);
        }
    }
}
