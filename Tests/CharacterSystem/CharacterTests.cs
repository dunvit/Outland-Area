//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OutlandAreaLogic;
//using OutlandAreaLogic.CharacterSystem;

//namespace Tests.CharacterSystem
//{
//    [TestClass]
//    public class CharacterTests
//    {
//        [TestMethod]
//        public void CharacterTest()
//        {
//            var character = new Character(637066561468099897);

//            Assert.AreEqual("Joanna Benbow", character.Name);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(InvalidOperationException), "Critical error on read character data from file.")]
//        public void GetCharacterNegativeTest()
//        {
//            var character = Global.Characters.GetCharacter(637066561468099891);
//        }

//        [TestMethod()]
//        public void GetCharacterPositiveTest()
//        {
//            var character = Global.Characters.GetCharacter(637066561468099897);

//            Assert.AreEqual("Joanna Benbow", character.Name);
//        }
//    }
//}