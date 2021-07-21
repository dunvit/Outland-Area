using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngineCore.Universe.Equipment.Weapon;
using System;
using System.Collections.Generic;
using System.Text;
using EngineCore.Session;
using Outland_Area_CoreTests;

namespace EngineCore.Universe.Equipment.Weapon.Tests
{
    [TestClass()]
    public class WeaponSkillTests
    {
        [TestMethod()]
        public void Missile_Test()
        {
            var settings = new EngineSettings { DebugProperties = new DebugProperties(true, true) };

            var server = EnvironmentGlobal.CreateGameServer("CommandsTests_Weapon", settings);

            var gameSession = EnvironmentGlobal.GetSession(server);

            var spaceship = gameSession.GetPlayerSpaceShip();

            Assert.AreEqual(2, spaceship.Modules[1].Skills.Count);
        }
    }
}