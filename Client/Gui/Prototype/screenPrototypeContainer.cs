using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.Gui.Prototype
{
    public partial class screenPrototypeContainer : Form
    {
        public screenPrototypeContainer()
        {
            InitializeComponent();

            containerTacticalScreen.Dock = DockStyle.Fill;
        }

        private void Event_WindowLoad(object sender, EventArgs e)
        {
            containerTacticalScreen.Initialize();
        }
    }
}
