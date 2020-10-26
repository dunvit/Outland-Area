using System;
using System.Windows.Forms;
using Engine.Layers.Tactical;

namespace Engine.Gui.Controls.TacticalLayer
{
    public partial class CommandsControl : UserControl
    {
        public event Action<ICelestialObject> OnAlignToCelestialObject;

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

        private void Event_AlignTo(object sender, EventArgs e)
        {
            if (SelectedObject == null) return;

            OnAlignToCelestialObject?.Invoke(SelectedObject);
        }
    }
}
