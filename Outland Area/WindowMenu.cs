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
            Global.GenerateGameSession("Map_OneShip");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Global.GenerateGameSession("TestScenario_1");
        }
    }
}
