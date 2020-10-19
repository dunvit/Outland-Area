using Engine.Gui;
using Engine.Management;

namespace Engine
{
    public class Global
    {
        public static Settings ApplicationSettings { get; private set; }
        public static GameManager Game { get; private set; }

        public static readonly UiManager GameUiManager = new UiManager();

        public static void GameInitialization()
        {
            log4net.Config.XmlConfigurator.Configure();

            ApplicationSettings = ReloadApplicationSettings();

            GameUiManager.Initialization();

            Game = new GameManager(GameUiManager);
        }

        public static void GenerateGameSession()
        {
            GameUiManager.StartNewGameSession();
        }

        private static Settings ReloadApplicationSettings()
        {
            var settings = new Settings();

            settings.WriteSettingsToLog();

            return settings;
        }

    }
}
