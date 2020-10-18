
namespace Engine
{
    public class Global
    {
        public static Settings ApplicationSettings { get; private set; }

        public static void GameInitialization()
        {
            log4net.Config.XmlConfigurator.Configure();

            ApplicationSettings = ReloadApplicationSettings();
        }

        private static Settings ReloadApplicationSettings()
        {
            var settings = new Settings();

            settings.WriteSettingsToLog();

            return settings;
        }

    }
}
