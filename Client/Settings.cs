using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Engine
{
    public class Settings
    {
        //public ILog Logger = LogManager.GetLogger("ConfigurationSettings");
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string Version => Configuration.Tools.GetConfigFromSectionOptionalStringValue("Current", "Version");

        public Size WindowSize { get; set; }

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
            Logger.Debug("--------------------------------------------------------------");
            Logger.Debug("Version:              " + Version);
            Logger.Debug("WindowSize:           " + WindowSize);
            Logger.Debug("ServerAddress:        " + ServerAddress);

            Logger.Debug("--------------------------------------------------------------");
        }
    }
}
