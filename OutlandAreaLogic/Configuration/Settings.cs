using System.Drawing;
using log4net;

namespace OutlandAreaLogic.Configuration
{
    public class Settings
    {
        public ILog Logger = LogManager.GetLogger("ConfigurationSettings");

        public string Version => ConfigurationTools.GetConfigFromSectionOptionalStringValue("Current", "Version");

        public Size WindowSize { get; set; }

        public string ServerAddress => ConfigurationTools.GetConfigFromSectionOptionalStringValue("ServerAddress", "Settings");

        public Settings()
        {
            WindowSize = new Size(
                ConfigurationTools.GetConfigOptionalIntValue("ClientWidth", "Settings", 1024), 
                ConfigurationTools.GetConfigOptionalIntValue("ClientHeight", "Settings", 768)
                );


        }

        public void WriteSettingsToLog()
        {
            Logger.Debug("--------------------------------------------------------------");
            Logger.Debug("Version:              " + Version);
            Logger.Debug("WindowSize:           " + WindowSize);
            Logger.Debug("ServerAddress:        " + ServerAddress);
            
            Logger.Debug("--------------------------------------------------------------");
        }
    }
}
