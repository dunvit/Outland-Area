using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutlandAreaLogic.Configuration;
using System.Drawing;

namespace Tests.Configuration
{
    [TestClass()]
    public class SettingsTests
    {
        [TestMethod()]
        public void LoadSettingsTest()
        {
            EnvironmentGlobal.Initialization();

            var settings = new Settings();

            var version = settings.Version;

            settings.WriteSettingsToLog();

            Assert.AreNotEqual(version, string.Empty);

            Assert.AreEqual(new Size(1920, 1080), settings.WindowSize);
        }



       
    }
}