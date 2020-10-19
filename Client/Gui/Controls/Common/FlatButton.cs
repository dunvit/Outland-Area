using System.Drawing;
using System.Windows.Forms;

namespace Engine.Gui.Controls.Common
{
    public partial class FlatButton : Button
    {
        public FlatButton()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(29, 29, 29);
            FlatAppearance.BorderColor = Color.FromArgb(43,43,43);
            FlatAppearance.MouseOverBackColor = Color.FromArgb(47,47,47);
            FlatStyle = FlatStyle.Flat;
            ForeColor = Color.FromArgb(161, 161, 161);
            Location = new Point(92, 177);

            Size = new Size(117, 23);
            //Text = "button";
            UseVisualStyleBackColor = false;

            
        }

        public sealed override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        private void OaButton_MouseLeave(object sender, System.EventArgs e)
        {
            ForeColor = Color.FromArgb(161, 161, 161);
        }

        private void OaButton_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
            ForeColor = Color.FromArgb(223, 223, 223);
        }
    }
}
