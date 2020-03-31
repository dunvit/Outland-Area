using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine
{
    public partial class WindowResizeTests : Form
    {
        public WindowResizeTests()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Size = new Size(1024, 768);
            Location = new Point(0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //1920 x 1080
            Size = new Size(1920, 1080);
            Location = new Point(0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Size = new Size(1400, 1050);
            Location = new Point(0, 0);
        }
    }
}
