using System;
using System.Windows.Forms;
using Engine.Layers.Tactical;

namespace Engine.Gui.Controls.TacticalLayer
{
    public partial class CommandsControl : UserControl
    {
        public event Action<ICelestialObject> OnAlignToCelestialObject;
        public event Action<ICelestialObject> OnOrbitCelestialObject;
        public event Action<ICelestialObject> OnOpenFire;

        private ICelestialObject SelectedObject { get; set; }

        public CommandsControl()
        {
            InitializeComponent();
        }

        public void Event_SelectCelestialObject(ICelestialObject celestialObject)
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

        private void Event_OpenFire(object sender, EventArgs e)
        {
            if (SelectedObject == null) return;

            OnOpenFire?.Invoke(SelectedObject);
        }

        private void Event_Orbit(object sender, EventArgs e)
        {
            if (SelectedObject == null) return;

            if ((CelestialObjectTypes) SelectedObject.Classification == CelestialObjectTypes.PointInMap) return;

            OnOrbitCelestialObject?.Invoke(SelectedObject);
        }
    }
}
