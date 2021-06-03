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
    public class ReloadingTests
    {
        [TestMethod()]
        public void Reloading_MicroWarpDrive_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("Reloading");

            var gameSession = server.RefreshGameSession(server.SessionId);

            var spaceship = gameSession.GetPlayerSpaceShip();

            var module = spaceship.GetPropulsionModules().First();

            Assert.AreEqual(2.0f, module.Reloading);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Braking));

            Assert.AreEqual(1, server.Commands.Count);

            Assert.AreEqual(7, gameSession.GetCelestialObject(spaceship.Id).Speed);

            server.TurnCalculation(1);

            gameSession = server.RefreshGameSession(server.SessionId);

            spaceship = gameSession.GetPlayerSpaceShip();

            module = spaceship.GetPropulsionModules().First();

            Assert.AreEqual(0.05, module.Reloading);

            server.TurnCalculation(5);

            module = server.RefreshGameSession(server.SessionId).GetPlayerSpaceShip().GetPropulsionModules().First();

            Assert.AreEqual(0.3, module.Reloading);
        }
    }
}
