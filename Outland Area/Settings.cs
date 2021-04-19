using System.Configuration;
using System.Drawing;
using log4net;

namespace Engine
{
    public class Settings
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string Version => Configuration.Tools.GetConfigFromSectionOptionalStringValue("Current", "Version");

        public Size WindowSize { get;}

        public string ServerAddress => Configuration.Tools.GetConfigFromSectionOptionalStringValue("ServerAddress", "Settings");

        public int ServerType => Configuration.Tools.GetConfigOptionalIntValue("ServerType", "Settings");

        public Settings()
        {
            WindowSize = new Size(
                Configuration.Tools.GetConfigOptionalIntValue("ClientWidth", "Settings", 1024),
                Configuration.Tools.GetConfigOptionalIntValue("ClientHeight", "Settings", 768)
            );
        }

        public void WriteSettingsToLog()
        {
            var settings = "";

            settings += "\n" + "--------------------------------------------------------------";
            settings += "\n" + "Version:              " + Version;
            settings += "\n" + "WindowSize:           " + WindowSize;
            settings += "\n" + "ServerAddress:        " + ServerAddress;
            settings += "\n" + "ServerType:           " + ServerType;
            settings += "\n" + "--------------------------------------------------------------";

            Logger.Info(settings);
        }
    }
}
