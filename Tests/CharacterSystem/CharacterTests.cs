using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaLogic.CharacterSystem;

namespace Tests.CharacterSystem
{
    [TestClass()]
    public class CharacterTests
    {
        [TestMethod()]
        public void CharacterTest()
        {
            var character = new Character(637066561468099897);

            Assert.AreEqual("Joanna Benbow", character.Name);
        }
    }
}