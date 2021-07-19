using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outland_Area_CoreTests;

namespace Engine.DAL.Tests
{
    [TestClass()]
    public class GameSessionRefreshTests
    {
        [TestMethod()]
        public void RequestGameSessionTest()
        {
            var server = EnvironmentGlobal.CreateGameServer("General");

            Assert.AreEqual(1, EnvironmentGlobal.GetSession(server).GetCelestialObjects().Count);
        }
    }
}