using System;
using System.Windows.Forms;

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
    }
}
