//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OutlandAreaLogic.DialogSystems;
//using OutlandAreaLogic.DialogSystems.Schemes;

//namespace Tests.DialogSystems
//{
//    [TestClass()]
//    public class DialogsTests
//    {
//        [TestMethod()]
//        public void DialogsInitializationTest()
//        {
//            EnvironmentGlobal.Initialization();

//            var dialogs = new Dialogs();

//            Assert.IsTrue(dialogs.List.Count > 0);

//            var privateObject = new PrivateObject(dialogs);

//            privateObject.Invoke("ReadDialogsFromDirectory");

//            var result = (List<DialogRowScheme>)privateObject.Invoke("Initialization");

//            Assert.IsTrue(result.Count > 0);

//            var resultDialogRowScheme = (DialogRowScheme)privateObject.Invoke("GetDialogRowSchemeById", 637066561468000002);

//            Assert.AreEqual(637066561468099898, resultDialogRowScheme.CharacterId, "Character Id is not correct.");
//        }
//    }
//}