using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Engine.UI.Controls
{
    public partial class ProgressBarVerticalHorizontal : UserControl
    {
        public ProgressBarVerticalHorizontal()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);

            crlFilledSurface.BackColor = _barLineColor;
        }


        private int _maximum = 100;
        [Category("Flash"),
         Description("The ending color of the bar.")]
        // The public property BarLineColor accesses _barLineColor.  
        public int Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                _maximum = value;
                //crlFilledSurface.BackColor = _barLineColor;
                // The Invalidate method calls the OnPaint method, which redraws
                // the control.  
                Invalidate();
            }
        }

        private int _currentValue = 100;
        [Category("Flash"),
         Description("The ending color of the bar.")]
        // The public property BarLineColor accesses _barLineColor.  
        public int CurrentValue
        {
            get
            {
                return _currentValue;
            }
            set
            {
                _currentValue = value;
                crlFilledSurface.Width = (int)(Width * ((double)_currentValue / _maximum));
                Invalidate();
            }
        }

        private Color _barLineColor = Color.LimeGreen;
        [Category("Flash"),
         Description("The ending color of the bar.")]
        // The public property BarLineColor accesses _barLineColor.  
        public Color BarLineColor
        {
            get
            {
                return _barLineColor;
            }
            set
            {
                _barLineColor = value;
                crlFilledSurface.BackColor = _barLineColor;
                // The Invalidate method calls the OnPaint method, which redraws
                // the control.  
                Invalidate();
            }
        }
    }
}
