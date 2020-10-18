using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OutlandArea.BL;
using OutlandArea.BL.Equipment;
using OutlandArea.Map;
using OutlandArea.Map.Objects;
using OutlandArea.Map.Objects.Spaceships;
using OutlandAreaLogic;

namespace Tests.Engine
{
    [TestClass]
    public class GameManagerTests
    {
        [TestMethod]
        public void GeneralTest()
        {
            var jsonGameSession = Convertor.GetSavedMap("Tests_Map_004");


            var stopwatchDynamic = Stopwatch.StartNew();

            //var gameSessionDynamic = Convertor.ConvertStringToGameSession(jsonGameSession);

            var time = stopwatchDynamic.ElapsedMilliseconds;

            var stopwatchJObject = Stopwatch.StartNew();

            var gameSessionJObject = Convertor.ToGameSession(jsonGameSession);

            var spaceship = (Spaceship)GameSessionTools.GetCelestialObject(5005, gameSessionJObject);


            Assert.IsTrue(spaceship.Direction == 90);

            Assert.AreEqual(spaceship.Modules.Count, 6);

            Assert.AreEqual(spaceship.Modules[0].Name, "Civilian Prototype Mk I");

            Assert.AreEqual(spaceship.Modules[0].Category, Category.Propulsion);

            Assert.AreEqual(spaceship.Modules[0].ActivationCost, 100);

            Assert.AreEqual(spaceship.Modules[3].Name, "Reactor Mk I");

            Assert.AreEqual(spaceship.Modules[3].Category, Category.Reactor);

            Assert.AreEqual(spaceship.Modules[3].ActivationCost, 100);

            var timeJObject = stopwatchJObject.ElapsedMilliseconds;
            //ConvertToGameSession


            var spaceshipInfo = new SpaceShipInfo(spaceship);

            Assert.AreEqual(450, spaceshipInfo.Shields);

            var b = "";
        }
    }
}
