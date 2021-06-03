using EngineCore;
using EngineCore.Session;
using EngineCore.Universe.Equipment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            Assert.AreEqual(95, spaceship.Direction);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.TurnRight));

            server.TurnCalculation(1);

            spaceship = server.RefreshGameSession(server.SessionId).GetPlayerSpaceShip();

            Assert.AreEqual(100, spaceship.Direction);

            server.TurnCalculation(1);

            spaceship = server.RefreshGameSession(server.SessionId).GetPlayerSpaceShip();

            Assert.AreEqual(100, spaceship.Direction);
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

            Assert.AreEqual(85, spaceship.Direction);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.TurnLeft));

            server.TurnCalculation(1);

            spaceship = server.RefreshGameSession(server.SessionId).GetPlayerSpaceShip();

            Assert.AreEqual(80, spaceship.Direction);

            server.TurnCalculation(1);

            spaceship = server.RefreshGameSession(server.SessionId).GetPlayerSpaceShip();

            Assert.AreEqual(80, spaceship.Direction);
        }
    }
}
