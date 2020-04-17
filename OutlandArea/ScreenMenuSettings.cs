using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlandArea
{
    public partial class ScreenMenuSettings : Form
    {
        public ScreenMenuSettings()
        {
            InitializeComponent();

            // Remove all items from design mode
            controlScreenResolution.Items.Clear();

            controlScreenResolution.Items.Add("1920x1280");
            controlScreenResolution.Items.Add("1536x864");
            controlScreenResolution.Items.Add("1280x720");
            controlScreenResolution.Items.Add("1024x768");
        }



        private void commandExit_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void oaButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
