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
    public partial class ScreenB : BaseResizeWindowForm
    {
        public ScreenB()
        {
            InitializeComponent();

            Initialization();
        }



        private void oaButton2_Click_1(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
