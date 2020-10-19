using System;
using System.Windows.Forms;

namespace Engine
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

            Global.GameInitialization();

            Application.Run(Global.GameUiManager.GetScreen("WindowMenu"));
        }
    }
}
