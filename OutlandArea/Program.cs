using System;
using System.Windows.Forms;
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

            var mainForm = new ScreenStartMenu{ Size = Global.ApplicationSettings.WindowSize};

            Application.Run(mainForm);
        }
    }
}
