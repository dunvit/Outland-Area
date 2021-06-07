using EngineCore.DataProcessing.CommandsExecution;
using EngineCore.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemanticComparison;

namespace Outland_Area_CoreTests.DataProcessing
{
    [TestClass()]
    public class WeaponShootingTests
    {
        [TestMethod()]
        public void Basic_Shot_Test()
        {
            var shots = new Shots();

            var shotPrediction = shots.Prediction(new GameSession(), EngineCore.CommandTypes.Shot, 100, 200, 101);

            var expected = new Likeness<ActionResult, ActionResult>(new ActionResult { Min = 45, Max = 57 });

            Assert.AreEqual(expected, shotPrediction);
        }
    }
}
