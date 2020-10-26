using System.Windows.Forms;
using Engine.Layers.Tactical;

namespace Engine.Gui.Controls.TacticalLayer
{
    public partial class CommandsControl : UserControl
    {
        private ICelestialObject SelectedObject { get; set; }

        public CommandsControl()
        {
            InitializeComponent();
        }

        public void GetTarget(ICelestialObject celestialObject)
        {
            SelectedObject = celestialObject;

            RefreshCommands(SelectedObject);
        }

        private void RefreshCommands(ICelestialObject celestialObject)
        {
            txtSelectedObjectLabel.Text = celestialObject.Name;
            txtSelectedObjectLabel.Visible = true;
        }
    }
}
