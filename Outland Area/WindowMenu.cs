using System;
using System.Windows.Forms;

namespace Engine
{
    public partial class WindowMenu : Form
    {
        public WindowMenu()
        {
            InitializeComponent();

            lblVersion.Text = Global.ApplicationSettings.Version;
        }

        private void Event_ApplicationExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Event_StartNewGameSession(object sender, EventArgs e)
        {
            Global.GenerateGameSession();
        }
    }
}
