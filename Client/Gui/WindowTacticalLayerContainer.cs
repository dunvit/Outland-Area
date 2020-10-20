using System;
using System.Windows.Forms;

namespace Engine.Gui
{
    public partial class WindowTacticalLayerContainer : BaseFullScreenWindow 
    {
        public WindowTacticalLayerContainer()
        {
            InitializeComponent();
        }

        private void Event_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
