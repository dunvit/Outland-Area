using System;
using System.Drawing;
using System.Windows.Forms;

namespace Engine.Gui.Controls.TacticalLayer
{
    public partial class GenericCompartment : UserControl
    {
        public GenericCompartment()
        {
            InitializeComponent();
        }

        private Point _locationMax = Point.Empty;
        private Point _locationMin = Point.Empty;
        private int _heightMax;
        private int _heightMin;
        private bool _isMax;

        private void Event_ChangeVisibility(object sender, EventArgs e)
        {
            if (_isMax)
            {
                Height = _heightMin;
                Location = _locationMin;
            }
            else
            {
                Height = _heightMax;
                Location = _locationMax;
            }

            _isMax = !_isMax;
        }


        private void GenericCompartment_Load(object sender, EventArgs e)
        {
            _heightMax = Height;
            _heightMin = 56;
            _isMax = true;
            _locationMax = new Point(Left, Top);
            _locationMin = new Point(Left, Top + _heightMax - _heightMin - 2);

            Event_ChangeVisibility(null, null);
        }
    }
}
