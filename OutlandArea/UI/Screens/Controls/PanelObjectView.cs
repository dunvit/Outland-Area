using System;
using System.Windows.Forms;
using OutlandArea.Map;

namespace OutlandArea.UI.Screens.Controls
{
    public partial class PanelObjectView : UserControl
    {
        private ICelestialObject _celestialObject = null;
        public PanelObjectView()
        {
            InitializeComponent();
        }

        public void ShowCelestialObjectInfo(ICelestialObject celestialObject)
        {
            _celestialObject = celestialObject;

            txtNameValue.Text = _celestialObject.Name;
            txtDirectionValue.Text = _celestialObject.Direction.ToString();
            txtLocationValue.Text = $@"({_celestialObject.PositionX}:{_celestialObject.PositionY})";
            txtSignatureValue.Text = _celestialObject.Signature + @" m";
            txtSpeedValue.Text = _celestialObject.Speed + @" m/s";

            pictureBox2.Image = Tools.UI.LoadGenericImage(@"Images\Ore\" + new Random().Next(1, 3));
        }

        public void ClearCelestialObjectInfo()
        {
            txtNameValue.Text = "";
            txtDirectionValue.Text = "";
            txtLocationValue.Text = "";
            txtSignatureValue.Text = "";
            txtSpeedValue.Text = "";

            pictureBox2.Image = null;
        }
    }
}
