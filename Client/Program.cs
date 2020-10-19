using System;
using System.Windows.Forms;
using Engine;

namespace Client
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


            Application.Run(new Engine.Gui.WindowMenu());
        }
    }
}
