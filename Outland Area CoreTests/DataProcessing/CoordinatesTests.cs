﻿using EngineCore.DataProcessing;
using System.Drawing;
using EngineCore.Geometry;
using EngineCore.Session;
using EngineCore.Universe.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EngineCore.DataProcessing.Tests
{
    [TestClass()]
    public class CoordinatesTests
    {
        [TestMethod()]
        public void LineLineTest()
        {
            //var result = GeometryTools.GetCrossLineToLinePoint(new PointF(0, 0), new PointF(100, 0), new PointF(50, 50),
            //    new PointF(50, -50));

            //Assert.Fail();

            var x = GeometryTools.Azimuth(new PointF(0, 0), new PointF(-1, 0));

        }
    }
}

namespace Outland_Area_CoreTests.DataProcessing
{
    [TestClass()]
    public class CoordinatesTests
    {
        [TestMethod]
        public void LinearMovementCalculationTest()
        {

            var server = EnvironmentGlobal.CreateGameServer("Map_OneShip");

            var gameSession = EnvironmentGlobal.GetSession(server);

            var spaceShip = gameSession.GetCelestialObject(gameSession.GetCelestialObjects()[0].Id);

            var position = spaceShip.GetLocation();

            Assert.AreEqual(1, gameSession.GetCelestialObjects().Count);
            Assert.AreEqual(new PointF(10000, 10000), position);

            server.TurnCalculation();

            gameSession = EnvironmentGlobal.GetSession(server);

            position = gameSession.GetCelestialObject(gameSession.GetCelestialObjects()[0].Id).GetLocation();

            Assert.AreEqual(new PointF((float) 10000.35, 10000), position);

            for(var i = 0; i < 19; i++)
                server.TurnCalculation();

            gameSession = EnvironmentGlobal.GetSession(server);

            position = gameSession.GetCelestialObject(gameSession.GetCelestialObjects()[0].Id).GetLocation();

            Assert.AreEqual(new PointF((float)10006.9922, 10000), position);
        }
    }
}