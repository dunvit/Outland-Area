using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Engine.UI.Controls
{
    public partial class ProgressBarVertical : UserControl
    {
        public ProgressBarVertical()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);

            crlFilledSurface.BackColor = _barLineColor;
        }
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    var rec = e.ClipRectangle;

        //    rec.Width = (int)(rec.Width * ((double)Value / Maximum));

        //    if (ProgressBarRenderer.IsSupported)
        //        ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);

        //    rec.Height = rec.Height;

        //    var brush1 = new SolidBrush(Color.Maroon);

        //    e.Graphics.FillRectangle(brush1, 0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);

        //    var brush = new SolidBrush(BarLineColor);

        //    e.Graphics.FillRectangle(brush, 0, 0, rec.Width, rec.Height);
        //}

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
                crlFilledSurface.Height = (int)(Height * ((double)_currentValue / _maximum));
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
