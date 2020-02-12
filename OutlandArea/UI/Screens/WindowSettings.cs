using System;
using System.Windows.Forms;

namespace OutlandArea.UI.Screens
{
    public partial class WindowSettings : Form
    {
        public WindowSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
