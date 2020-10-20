using System;
using System.Windows.Forms;

namespace Engine.Gui
{
    public partial class WindowMenu : Form
    {
        public WindowMenu()
        {
            InitializeComponent();

            lblVersion.Text = Global.ApplicationSettings.Version;
        }

        private void Event_ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Event_StartNewGame(object sender, EventArgs e)
        {
            Global.GenerateGameSession();
        }
    }
}
