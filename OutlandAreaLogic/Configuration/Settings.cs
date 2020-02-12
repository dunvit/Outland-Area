using log4net;

namespace OutlandAreaLogic.Configuration
{
    public class Settings
    {
        public ILog Logger = LogManager.GetLogger("ConfigurationSettings");

        public string Version => ConfigurationTools.GetConfigFromSectionOptionalStringValue("Current", "Version");

        public void WriteSettingsToLog()
        {
            Logger.Debug("--------------------------------------------------------------");
            Logger.Debug("Version:              " + Version);
            Logger.Debug("--------------------------------------------------------------");
        }
    }
}
