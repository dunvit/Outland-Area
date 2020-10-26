using System;
using System.Windows.Forms;
using Engine.Tools;

namespace Engine.Gui
{
    public partial class WindowTacticalLayerContainer : BaseFullScreenWindow 
    {
        public WindowTacticalLayerContainer()
        {
            InitializeComponent();

            crlCelestialMap.Dock = DockStyle.Fill;

            if (DebugTools.IsInDesignMode())
                return;

            Global.Game.OnSelectCelestialObject += controlCommands.GetTarget;
            //controlCommands
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
