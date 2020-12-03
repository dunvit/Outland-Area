using System;
using System.Drawing;
using Engine.Management.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaCommon;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace Tests.Server
{
    [TestClass]
    public class CommandCalculationTests  
    {

        private static ICelestialObject AddCelestialObjectAlignTo(PointF location)
        {
            var celestialObject = new PointInSpace
            {
                Id = new Random().NextInt(),
                Name = "Point in space",
                Speed = 0,
                Direction = 0,
                Classification = (int) CelestialObjectTypes.PointInMap,
                PositionX = location.X,
                PositionY = location.Y
            };

            return celestialObject;
        }

        private LocalStaticGameServer CreateServer(string map = "Map_OneShip")
        {
            return new LocalStaticGameServer(map);
        }

        [TestMethod]
        public void LinearMovementCalculationTest()
        {

            var server = CreateServer();

            var gameSession = server.RefreshGameSession(0);

            var spaceShip = gameSession.GetCelestialObject(gameSession.Map.CelestialObjects[0].Id);

            var position = spaceShip.GetLocation();

            Assert.AreEqual(1, gameSession.Map.CelestialObjects.Count);
            Assert.AreEqual(new PointF(10000, 10000), position);

            server.TurnCalculation();
            gameSession = server.RefreshGameSession(0);

            position = gameSession.GetCelestialObject(gameSession.Map.CelestialObjects[0].Id).GetLocation();

            Assert.AreEqual(new PointF(10010, 10000), position);
        }

        [TestMethod]
        public void AlignToCalculationTest()
        {
            var server = CreateServer();

            var gameSession = server.RefreshGameSession(0);

            var spaceShip = gameSession.GetCelestialObject(gameSession.Map.CelestialObjects[0].Id);

            var position = spaceShip.GetLocation();

            Assert.AreEqual(1, gameSession.Map.CelestialObjects.Count);
            Assert.AreEqual(new PointF(10000, 10000), position);

            var pointInSpace = AddCelestialObjectAlignTo(new PointF(10500, 10500));

            gameSession.AddCelestialObject(pointInSpace);

            server.Command(gameSession.Id, spaceShip.Id, pointInSpace.Id, 0, 0, (int)CommandTypes.AlignTo);

            server.TurnCalculation();
            gameSession = server.RefreshGameSession(0);

            position = gameSession.GetCelestialObject(gameSession.Map.CelestialObjects[0].Id).GetLocation();

            Assert.AreEqual(new PointF(10009, 10000), position);

            Assert.AreEqual(2, gameSession.Map.CelestialObjects.Count);

            position = gameSession.GetCelestialObject(pointInSpace.Id).GetLocation();

            Assert.AreEqual(new PointF(10500, 10500), position);

            server.TurnCalculation();
            gameSession = server.RefreshGameSession(0);

            position = gameSession.GetCelestialObject(gameSession.Map.CelestialObjects[0].Id).GetLocation();

            Assert.AreEqual(new PointF(10018, 10001), position);

            server.TurnCalculation();
            server.TurnCalculation();
            server.TurnCalculation();
            server.TurnCalculation();
            server.TurnCalculation();

            gameSession = server.RefreshGameSession(0);

            position = gameSession.GetCelestialObject(gameSession.Map.CelestialObjects[0].Id).GetLocation();

            Assert.AreEqual(new PointF(10063, 10002), position);
        }
    }
}
