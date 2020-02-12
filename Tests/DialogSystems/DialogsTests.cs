using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaLogic.DialogSystems;

namespace Tests.DialogSystems
{
    [TestClass()]
    public class DialogsTests
    {
        [TestMethod()]
        public void DialogsInitializationTest()
        {
            EnvironmentGlobal.Initialization();

            var dialogs = new Dialogs();

            dialogs.Initialization();

            Assert.AreEqual(4, dialogs.List.Count);
        }
    }
}