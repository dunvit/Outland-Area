using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Outland_Area_CoreTests.DAL
{
    [TestClass]
    public class ScenarioGeneralTests
    {
        [TestMethod()]
        public void SessionName_Test()
        {
            var server = EnvironmentGlobal.CreateGameServer("General");

            var gameSession = EnvironmentGlobal.GetSessionServerSide(server);

            Assert.AreEqual("General", gameSession.ScenarioName);
        }
    }
}
