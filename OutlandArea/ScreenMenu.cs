using System;
using System.Windows.Forms;
using OutlandAreaLogic;

namespace OutlandArea
{
    public partial class ScreenMenu : Form
    {
        

        public ScreenMenu()
        {
            InitializeComponent();
        }

        private void commandExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Event_OpenSettingsWindow(object sender, EventArgs e)
        {
            var screenSettings = new ScreenMenuSettings();

            screenSettings.ShowDialog();
        }

        private void Event_StartNewGame(object sender, EventArgs e)
        {
            Global.GameManager.ScreenMain.Execute("Dialog Screen");
            Close();
        }
    }
}
