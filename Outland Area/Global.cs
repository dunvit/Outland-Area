using Engine.Gui;
//using Engine.Management;

namespace Engine
{
    public class Global
    {
        public static Settings ApplicationSettings { get; private set; }
        public static GameManager Game { get; private set; }

        //public static UiManager GameUiManager;

        public static void GameInitialization()
        {
            log4net.Config.XmlConfigurator.Configure();

            ApplicationSettings = ReloadApplicationSettings();

            Game = new GameManager();

            //GameUiManager = new UiManager();

            //GameUiManager.Initialization();

            //Game.Initialization(GameUiManager);
        }

        public static void GenerateGameSession()
        {
            Game.StartNewGameSession();
        }

        private static Settings ReloadApplicationSettings()
        {
            var settings = new Settings();

            settings.WriteSettingsToLog();

            return settings;
        }

    }
}
