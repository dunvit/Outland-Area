using System;
using System.Windows.Forms;

namespace Engine
{
    public partial class ScreenA : BaseResizeWindowForm
    {
        public ScreenA()
        {
            InitializeComponent();

            Initialization();
        }

        private void oaButton2_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
