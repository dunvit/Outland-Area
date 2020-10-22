using System;
using System.Windows.Forms;

namespace Engine.Gui
{
    public partial class WindowTacticalLayerContainer : BaseFullScreenWindow 
    {
        public WindowTacticalLayerContainer()
        {
            InitializeComponent();

            crlCelestialMap.Dock = DockStyle.Fill;
        }

        private void Event_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Event_ResumeGame(object sender, EventArgs e)
        {
            Global.Game.ResumeSession();
        }
    }
}
