using System;
using System.Windows.Forms;
using Engine.Gui.Prototype;

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

        private void flatButton3_Click(object sender, EventArgs e)
        {
            var screenPrototypeContainer = new screenPrototypeContainer();
            var a = screenPrototypeContainer.ShowDialog();
        }
    }
}
