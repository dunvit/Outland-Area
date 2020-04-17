using System.Drawing;
using System.Windows.Forms;

namespace OutlandAreaLogic.Controls
{
    public partial class OaButton : Button
    {
        public OaButton()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            FlatStyle = FlatStyle.Flat;
            ForeColor = Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
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
