using System;
using System.Windows.Forms;
using log4net;

namespace Engine
{
    static class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Global.GameInitialization();

            Logger.Info("Start game desktop client.");

            Application.Run(Global.Game.ShowScreen("WindowMenu"));
        }
    }
}
