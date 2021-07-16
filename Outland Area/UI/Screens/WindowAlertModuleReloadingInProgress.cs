using System;
using System.Windows.Forms;
using EngineCore.Session;
using EngineCore.Universe.Equipment;

namespace Engine.UI.Screens
{
    public partial class WindowAlertModuleReloadingInProgress : Form
    {
        public WindowAlertModuleReloadingInProgress(IModule module, GameSession gameSession)
        {
            InitializeComponent();

            txtMessage.Text = $@"RELOAD WILL BE COMPLETE IN {Math.Round(module.ReloadTime - module.Reloading, 2)} SECONDS";
        }

        private void Event_WindowClose(object sender, EventArgs e)
        {
            Close();
        }
    }
}
