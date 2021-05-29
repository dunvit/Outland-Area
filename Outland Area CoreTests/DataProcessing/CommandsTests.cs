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
        public void PropulsionModuleTest()
        {

            var server = EnvironmentGlobal.CreateGameServer("CommandsTests");

            var gameSession = server.RefreshGameSession(server.SessionId);

            var spaceship = gameSession.GetPlayerSpaceShip();

            var module = spaceship.GetPropulsionModules().First();            

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Braking));

            Assert.AreEqual(1, server.Commands.Count);

            server.TurnCalculation(1);

            Assert.AreEqual(0, server.Commands.Count);

            Assert.AreEqual(1, server.GetCommands(5005).Count);

            server.TurnCalculation(1);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Braking));

            Assert.AreEqual(1, server.Commands.Count);

            server.TurnCalculation(1);

            Assert.AreEqual(0, server.Commands.Count);

            Assert.AreEqual(2, server.GetCommands(5005).Count);

            Assert.AreEqual(CommandTypes.StopShip, server.GetCommands(5005)[0].Type);
        }
    }
}
