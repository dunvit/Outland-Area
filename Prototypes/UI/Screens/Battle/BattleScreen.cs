using System;
using System.Windows.Forms;

namespace Engine.UI.Screens.Battle
{
    public partial class BattleScreen : Form
    {
        public BattleScreen()
        {
            InitializeComponent();
        }


        private void oaButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
