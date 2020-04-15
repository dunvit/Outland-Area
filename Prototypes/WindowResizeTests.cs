using System;
using System.Drawing;

namespace Engine
{
    public partial class WindowResizeTests : BaseResizeWindowForm
    {
        public WindowResizeTests() 
        {
            InitializeComponent();

            Location = new Point(0, 0);

            Size = new Size(1280, 720);
            Location = new Point(0, 0);

            Initialization();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Size = new Size(1280, 720);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Size = new Size(1920, 1080);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Size = new Size(1366,768);
        }



        private void button1_Click_2(object sender, EventArgs e)
        {
            Close();
        }
    }
}
