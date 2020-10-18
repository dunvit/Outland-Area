using System;
using System.Windows.Forms;
using OutlandArea.TacticalBattleLayer;
using OutlandArea.UI.Screens;
using OutlandAreaLogic;

namespace OutlandArea
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start initialization all systems: Logs, Dialogs...
            Global.Initialization();

            // Load global application settings from configuration files
            Global.ApplicationSettings.WriteSettingsToLog();

            //var screenMain = new ScreenStartMenu { Size = Global.ApplicationSettings.WindowSize };

            var screenMain = new BattleBoard(new Manager())
            {
                Size = Global.ApplicationSettings.WindowSize
            };

            // Add screen as interface screen commands - IScreenCommands
            //Global.GameManager.ScreenMain = screenMain;
            
            var _gameManager = new GameManager(null);

            // Load form as window forms
            //Application.Run(screenMain);
            Application.Run(new WindowBattleBoard(_gameManager));
            //WindowBattleBoard
        }
    }
}
