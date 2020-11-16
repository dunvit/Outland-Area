using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Engine;

namespace Tests.Configuration
{
    [TestClass()]
    public class SettingsTests
    {
        [TestMethod()]
        public void LoadSettingsTest()
        {
            EnvironmentGlobal.Initialization();

            var settings = new Engine.Settings();

            var version = settings.Version;

            settings.WriteSettingsToLog();

            Assert.AreNotEqual(version, string.Empty);

            Assert.AreEqual(new Size(1920, 1080), settings.WindowSize);
        }



       
    }
}