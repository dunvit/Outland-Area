using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OutlandArea.BL;
using OutlandArea.Map;
using OutlandAreaLogic;

namespace Tests.Engine
{
    [TestClass]
    public class GameManagerTests
    {
        [TestMethod]
        public void GeneralTest()
        {
            var jsonGameSession = Convertor.GetSavedMap("Map_003");


            var stopwatchDynamic = Stopwatch.StartNew();

            //var gameSessionDynamic = Convertor.ConvertStringToGameSession(jsonGameSession);

            var time = stopwatchDynamic.ElapsedMilliseconds;

            var stopwatchJObject = Stopwatch.StartNew();

            var gameSessionJObject = Convertor.ToGameSession(jsonGameSession);

            var timeJObject = stopwatchJObject.ElapsedMilliseconds;
            //ConvertToGameSession
        }
    }
}
