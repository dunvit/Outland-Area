using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaLogic.Configuration;

namespace Tests.Configuration
{
    [TestClass()]
    public class SettingsTests
    {
        [TestMethod()]
        public void LoadSettingsTest()
        {
            Initialization();

            var settings = new Settings();

            var version = settings.Version;

            settings.WriteSettingsToLog();

            Assert.AreNotEqual(version, string.Empty);
        }

        private void Initialization()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}