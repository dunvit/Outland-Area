using System;
using System.Drawing;
using Engine;

namespace Prototypes
{
    public partial class WindowMain : BaseResizeWindowForm
    {
        public WindowMain()
        {
            InitializeComponent();

            Initialization();
        }

        private void WindowMain_Load(object sender, EventArgs e)
        {

        }

        private void oaButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void oaButton1_Click(object sender, EventArgs e)
        {
            GlobalPrototype.Manager.screenB.Show();

            GlobalPrototype.Manager.screenB.Visible = true;
        }

        private void oaButton3_Click(object sender, EventArgs e)
        {
            GlobalPrototype.Manager.screenA.Show();

            GlobalPrototype.Manager.screenA.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Size = new Size(1280, 720);
            GlobalPrototype.Manager.Resize(Size);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Size = new Size(1920, 1080);
            GlobalPrototype.Manager.Resize(Size);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Size = new Size(1366, 768);
            GlobalPrototype.Manager.Resize(Size);
        }
    }
}
