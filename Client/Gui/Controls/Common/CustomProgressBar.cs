using System.Drawing;
using System.Windows.Forms;

namespace Engine.Gui.Controls.Common
{
    public class CustomProgressBar : ProgressBar
    {
        Label textValue = new Label();

        public string BarText { get; set; } 

        public Color BarLineColor { get; set; }

        public CustomProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);

            textValue.Dock = DockStyle.Fill;
            //textValue.Text = "100%";
            textValue.TextAlign = ContentAlignment.MiddleCenter;
            textValue.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textValue.ForeColor = Color.WhiteSmoke;
            textValue.Visible = true;
            textValue.BackColor = Color.Transparent;
            Controls.Add(textValue);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var rec = e.ClipRectangle;

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) ;

            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            
            rec.Height = rec.Height;

            var brush1 = new SolidBrush(Color.Maroon);

            e.Graphics.FillRectangle(brush1, 0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);

            var brush = new SolidBrush(BarLineColor);

            e.Graphics.FillRectangle(brush, 0, 0, rec.Width, rec.Height);

            textValue.Text = BarText;
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // NewProgressBar
            // 
            BackColor = Color.Maroon;
            ResumeLayout(false);

        }
    }
}
