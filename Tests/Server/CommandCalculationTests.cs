using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Castle.DynamicProxy;
using Engine.Management.Server;
using LanguageExt;
using LanguageExt.SomeHelp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaCommon;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaCommon.Universe.Objects.Spaceships;

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

            var spaceShip = gameSession.GetCelestialObject(gameSession.SpaceMap.CelestialObjects[0].Id);

            var position = spaceShip.GetLocation();

            Assert.AreEqual(1, gameSession.SpaceMap.CelestialObjects.Count);
            Assert.AreEqual(new PointF(10000, 10000), position);

            server.TurnCalculation();
            gameSession = server.RefreshGameSession(0);

            position = gameSession.GetCelestialObject(gameSession.SpaceMap.CelestialObjects[0].Id).GetLocation();

            Assert.AreEqual(new PointF(10010, 10000), position);
        }

        [TestMethod]
        public void OptionCelestialObjectTest()
        {

            var server = CreateServer();

            var testGameSession = new GameSession();

            testGameSession.GetSpaceMapOption();


            

            var gameSession = server.RefreshGameSession(0);

            gameSession.GetSpaceMapOption();

            var id = 5005;

            var vModulesShields = gameSession.GetSpaceMapOption().
                Map(_ => _.GetCelestialObjectOption(id)).
                Match(_ => _, Option<ICelestialObject>.None).
                Map(_=> _.ToSpaceship().Modules.Where(module => module.Category == Category.Shield)).
                Match(modules => modules, new List<IModule>());


            foreach (var vModulesShield in vModulesShields)
            {
                var a1 = vModulesShield.Name;
            }

            var name = ("Paul", "Louth");
            var res = name.Map((first, last) => $"{first} {last}");


            var celestialObjectOption = gameSession.GetCelestialObjectOption(gameSession.SpaceMap.CelestialObjects[0].Id);

            var a = celestialObjectOption.Match<ICelestialObject>(celestialObject => celestialObject, (Func<ICelestialObject>) null);

            var weaponModules = celestialObjectOption
                .Map(spaceship => spaceship.ToSpaceship().Modules.Where(module => module.Category == Category.Shield))
                .Match(modules => modules, new List<IModule>()).Map(m => (m.Id, m.Name));


            //foreach (var module in weaponModules)
            //{
            //    var moduleName = module.Name;
            //}

            var rrr = weaponModules.FirstOrDefault();

            var noneOption = gameSession.GetCelestialObjectOption(125);

            var shieldModules = noneOption.Map(spaceship => spaceship.ToSpaceship().
                Modules.Where(module => module.Category == Category.Shield)).Match(modules => modules, new List<IModule>());
        }

        private ICelestialObject Ok(ICelestialObject arg)
        {
            return arg;
        }

        [TestMethod]
        public void AlignToCalculationTest()
        {
            var server = CreateServer();

            var gameSession = server.RefreshGameSession(0);

            var spaceShip = gameSession.GetCelestialObject(gameSession.SpaceMap.CelestialObjects[0].Id);

            var position = spaceShip.GetLocation();

            Assert.AreEqual(1, gameSession.SpaceMap.CelestialObjects.Count);
            Assert.AreEqual(new PointF(10000, 10000), position);

            var pointInSpace = AddCelestialObjectAlignTo(new PointF(10500, 10500));

            gameSession.AddCelestialObject(pointInSpace);

            server.Command(gameSession.Id, spaceShip.Id, pointInSpace.Id, 0, 0, (int)CommandTypes.AlignTo);

            server.TurnCalculation();
            gameSession = server.RefreshGameSession(0);

            position = gameSession.GetCelestialObject(gameSession.SpaceMap.CelestialObjects[0].Id).GetLocation();

            Assert.AreEqual(new PointF(10009, 10000), position);

            Assert.AreEqual(2, gameSession.SpaceMap.CelestialObjects.Count);

            position = gameSession.GetCelestialObject(pointInSpace.Id).GetLocation();

            Assert.AreEqual(new PointF(10500, 10500), position);

            server.TurnCalculation();
            gameSession = server.RefreshGameSession(0);

            position = gameSession.GetCelestialObject(gameSession.SpaceMap.CelestialObjects[0].Id).GetLocation();

            Assert.AreEqual(new PointF(10018, 10001), position);

            server.TurnCalculation();
            server.TurnCalculation();
            server.TurnCalculation();
            server.TurnCalculation();
            server.TurnCalculation();

            gameSession = server.RefreshGameSession(0);

            position = gameSession.GetCelestialObject(gameSession.SpaceMap.CelestialObjects[0].Id).GetLocation();

            Assert.AreEqual(new PointF(10063, 10002), position);
        }
    }
}
