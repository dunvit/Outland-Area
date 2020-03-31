using System;
using System.Windows.Forms;
using Engine;
using OutlandAreaLogic;

namespace Prototypes
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


            
            //var mainForm = new Form1 { Size = Global.ApplicationSettings.WindowSize };
            var mainForm = new WindowResizeTests();

            Application.Run(mainForm);
        }
    }
}
