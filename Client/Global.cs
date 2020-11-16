﻿using Engine.Gui;
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

            Game = new GameManager();

            GameUiManager.Initialization();

            Game.Initialization(GameUiManager);
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