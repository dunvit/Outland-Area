using System;
using System.Windows.Forms;
using Engine;
using Engine.Screens;
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

            GlobalPrototype.Manager.Activate();

            //var mainForm = new Form1 { Size = Global.ApplicationSettings.WindowSize };
            //var mainForm = new WindowResizeTests();
            //var mainForm = new WindowMain();
            //var mainForm = new BattleScreen { Size = Global.ApplicationSettings.WindowSize };
            
            //var mainForm = new WindowResizeTests { Size = Global.ApplicationSettings.WindowSize };
            var mainForm = new WindowBattleContainer { Size = Global.ApplicationSettings.WindowSize };
            
            //var mainForm = new PrototypeRadar { Size = Global.ApplicationSettings.WindowSize };

            Application.Run(mainForm);
        }
    }
}
