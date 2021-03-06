﻿using System;
using EngineCore;
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
        // TODO: Add property Mobility to Spacecraft
        const float MobilityInDegrees = 10.0f;

        [TestMethod()]
        public void AddCommandsGeneral_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("CommandsTests");

            var gameSession = EnvironmentGlobal.GetSession(server);

            var spaceship = gameSession.GetPlayerSpaceShip();

            var module = spaceship.GetPropulsionModules().First();

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Braking));

            Assert.AreEqual(1, server.Commands.Count);

            server.TurnCalculation(1);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Braking));

            Assert.AreEqual(0, server.Commands.Count);

            server.TurnCalculation(5);

            Assert.AreEqual(0, server.Commands.Count);

            server.TurnCalculation(1);
            server.Wait(5);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Braking));

            Assert.AreEqual(1, server.Commands.Count);

            server.TurnCalculation(1);
        }

        [TestMethod()]
        public void PropulsionModule_Braking_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("CommandsTests");

            var gameSession = EnvironmentGlobal.GetSession(server);

            var spaceship = gameSession.GetPlayerSpaceShip();

            var module = spaceship.GetPropulsionModules().First();            

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Braking));

            Assert.AreEqual(1, server.Commands.Count);

            Assert.AreEqual(7, gameSession.GetCelestialObject(spaceship.Id).Speed);

            server.TurnCalculation(1);

            gameSession = EnvironmentGlobal.GetSession(server);

            Assert.AreEqual(6.975, Math.Round(gameSession.GetCelestialObject(spaceship.Id).Speed, 3));

            Assert.AreEqual(0, server.Commands.Count);

            Assert.AreEqual(1, server.GetHistoryCommands(server.SessionId, spaceship.Id).Count);

            server.TurnCalculation(1);

            // Add command for not reloaded module
            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Braking));

            server.TurnCalculation(1);

            Assert.AreEqual(0, server.Commands.Count);

            server.Wait(5);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.Braking));

            Assert.AreEqual(1, server.Commands.Count);

            server.Wait(5);

            Assert.AreEqual(0, server.Commands.Count);

            Assert.AreEqual(2, server.GetHistoryCommands(server.SessionId, spaceship.Id).Count);

            Assert.AreEqual(CommandTypes.StopShip, server.GetHistoryCommands(server.SessionId, spaceship.Id)[0].Type);
        }

        [TestMethod()]
        public void PropulsionModule_TurnRight_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("CommandsTests");

            var gameSession = EnvironmentGlobal.GetSession(server);

            var spaceship = gameSession.GetPlayerSpaceShip();

            var module = spaceship.GetPropulsionModules().First();

            double turnRotationSpeed = MobilityInDegrees / (new EngineSettings().UnitsPerSecond * module.ReloadTime);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.TurnRight));

            Assert.AreEqual(1, server.Commands.Count);

            server.TurnCalculation(1);

            gameSession = EnvironmentGlobal.GetSession(server);

            spaceship = gameSession.GetPlayerSpaceShip();

            Assert.AreEqual(90 + 1 * turnRotationSpeed, spaceship.Direction);

            // Reloading time
            server.Wait(3);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.TurnRight));

            server.TurnCalculation(1);

            spaceship = EnvironmentGlobal.GetSession(server).GetPlayerSpaceShip();

            Assert.AreEqual(100 + turnRotationSpeed, spaceship.Direction);

            server.TurnCalculation(1);

            spaceship = EnvironmentGlobal.GetSession(server).GetPlayerSpaceShip();

            Assert.AreEqual(100 + 2 * turnRotationSpeed, spaceship.Direction);
        }

        [TestMethod()]
        public void PropulsionModule_TurnLeft_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("CommandsTests");

            var gameSession = EnvironmentGlobal.GetSession(server);

            var spaceship = gameSession.GetPlayerSpaceShip();

            var module = spaceship.GetPropulsionModules().First();

            double turnRotationSpeed = MobilityInDegrees / (new EngineSettings().UnitsPerSecond * module.ReloadTime);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.TurnLeft));

            Assert.AreEqual(1, server.Commands.Count);

            server.TurnCalculation(1);

            gameSession = EnvironmentGlobal.GetSession(server);

            spaceship = gameSession.GetPlayerSpaceShip();

            Assert.AreEqual(90 - turnRotationSpeed, spaceship.Direction);

            // Reloading time
            server.Wait(3);

            server.Command(server.SessionId, ModuleCommand.ToJson(gameSession, module.TurnLeft));

            server.TurnCalculation(1);

            spaceship = EnvironmentGlobal.GetSession(server).GetPlayerSpaceShip();

            Assert.AreEqual(80 - 1 * turnRotationSpeed, spaceship.Direction);

            server.TurnCalculation(1);

            spaceship = EnvironmentGlobal.GetSession(server).GetPlayerSpaceShip();

            Assert.AreEqual(80 - 2 * turnRotationSpeed, spaceship.Direction);
        }

        [TestMethod]
        public void Debugger_Replacer()
        {
            var a = new EngineCore.Tools.DictionaryWithReaderWriterLock<int, int>();

            a.Add(1, 2);
            a.Add(3, 4);
        }


        //[TestMethod]
        //public void Microsoft_Url_Replacer()
        //{
        //    var x1 = "https://s3.amazonaws.com/nv-p1-s3-assets-01/233396/1010/CSS/https/www.microsoft.com/onerfstatics/marketingsites-neu-prod/west-european/mscomhp/_scrf/css/themes%3Ddefault.device%3Duplevel_web_pc_webkit_chrome/32-1b5444/57-7b1339/37-e29aca/21-7d6c87/5a-e79275/2c-511e5e/65-478888%253Fver%3D2.0%26_cf%3D20210415";
        //    //var x2 = "https://www.microsoft.com/onerfstatics/marketingsites-neu-prod/west-european/mscomhp/_scrf/css/themes%3Ddefault.device%3Duplevel_web_pc_webkit_chrome/32-1b5444/57-7b1339/37-e29aca/21-7d6c87/5a-e79275/2c-511e5e/65-478888%253Fver%3D2.0%26amp;_cf%3D20210415";

        //    var urlBeforePTC = "https://s3.amazonaws.com/nv-p1-s3-assets-01/233396/1010/CSS/https/www.microsoft.com/onerfstatics/sfweusprod/west-european/store/_scrf/css/themes=store-web-default.device=uplevel_web_pc_webkit_chrome/9b-e8249b/fd-dc83dc/a9-92371e/33-5b9c81/7c-b44414/4e-fc9431/e9-4b83da/4d-131846/24-736200/15-4dced4/2d-5397d3/bf-9c867f/8f-bf0bd9/80-55f65d";

        //    var urlAfterPTCUpdate = x1.
        //    Replace("?", "%253F").
        //    //Replace("&", "&amp;").
        //    Replace("&", "%26").
        //    Replace("=", "%3D");
        //}
    }
}
