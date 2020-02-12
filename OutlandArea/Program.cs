using System;
using System.Windows.Forms;

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

            // Log system initialization
            log4net.Config.XmlConfigurator.Configure();

            // Load global application settings from configuration files
            Global.ApplicationSettings.WriteSettingsToLog();

            var mainForm = new Form1{Size = Global.ApplicationSettings.WindowSize};

            Application.Run(mainForm);
        }
    }
}
