using System.Windows.Forms;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace Engine.Gui.Controls.TacticalLayer
{
    public partial class SelectedBaseCelestialObject : UserControl
    {
        public ICelestialObject SelectedCelestialObject { get; set; }

        public SelectedBaseCelestialObject()
        {
            InitializeComponent();
        }

        private delegate void RefreshCallback(ICelestialObject celestialObject, ICelestialObject spaceship);

        public void Event_SelectCelestialObject(ICelestialObject celestialObject, ICelestialObject spaceship)
        {

            if (txtObjectName.InvokeRequired)
            {
                RefreshCallback d = Event_SelectCelestialObject;
                Invoke(d, celestialObject, spaceship);
                return;
            }

            if (celestialObject != null)
            {
                txtObjectName.Text = celestialObject.Name;
                txtObjectClassification.Text = celestialObject.Classification.ToString();

                txtDirection.Text = $@"{celestialObject.Direction:N2}%";
                txtDistance.Text = $@"{Coordinates.GetDistance(celestialObject.GetLocation(), spaceship.GetLocation()):N2}%";
                txtSignature.Text = $@"{celestialObject.Signature:N2}%";
                txtSpeed.Text = $@"{celestialObject.Speed:N2}%";
            }
            else
            {

                if(SelectedCelestialObject == null)
                {
                    txtObjectName.Text = @"No Object Selected";
                    txtObjectClassification.Text = @"";

                    txtDirection.Text = @"???";
                    txtDistance.Text = @"???";
                    txtSignature.Text = @"???";
                    txtSpeed.Text = @"???";
                }
            }
            
        }
    }
}
