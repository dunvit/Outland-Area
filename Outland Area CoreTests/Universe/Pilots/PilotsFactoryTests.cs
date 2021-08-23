using EngineCore.Universe.Pilots;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Outland_Area_CoreTests.Universe.Pilots
{
    [TestClass()]
    public class PilotsFactoryTests
    {
        [TestMethod()]
        public void GenerateGunnerTest()
        {

            var gunner = PilotsFactory.GenerateGunner();

            Assert.IsTrue(gunner.Id > 0);
            Assert.IsFalse(gunner.Name == string.Empty);
            Assert.IsFalse(gunner.Family == string.Empty);
            Assert.IsTrue(gunner.SkillsAutoCannon <= 55);
            Assert.IsTrue(gunner.SkillsMissileLauncherOperation >= 50 && gunner.SkillsMissileLauncherOperation <= 65);
            Assert.IsTrue(gunner.Health == 100);
        }

        [TestMethod()]
        public void GeneratePointDefenseOperatorTest()
        {

            var gunner = PilotsFactory.GeneratePointDefenseOperator();

            Assert.IsTrue(gunner.Id > 0);
            Assert.IsFalse(gunner.Name == string.Empty);
            Assert.IsFalse(gunner.Family == string.Empty);
            Assert.IsTrue(gunner.SkillsMissileLauncherOperation <= 55);
            Assert.IsTrue(gunner.SkillsAutoCannon >= 50 && gunner.SkillsAutoCannon <= 65);
            Assert.IsTrue(gunner.Health == 100);
        }
    }
}