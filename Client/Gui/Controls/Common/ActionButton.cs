using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Engine.Gui.Controls.Common
{
    public partial class ActionButton : UserControl
    {
        private Timer mTimer;

        private bool isSelected = false;

        public ActionButton()
        {
            InitializeComponent();

            mTimer = new Timer {Interval = 200};
            mTimer.Tick += mTimer_Tick;
            mTimer.Enabled = true;
        }

        private void mTimer_Tick(object sender, EventArgs e)
        {
            if (AmIStillInsideTheUserControl(this))
            {
                if (isSelected == false)
                {
                    borderImage.Image = Properties.Resources.BordersSelected;
                }

                isSelected = true;
            }
            else
            {
                if (isSelected == true)
                {
                    borderImage.Image = Properties.Resources.BordersUnselected;
                }

                isSelected = false;
            }
        }

        private bool AmIStillInsideTheUserControl(Control control)
        {
            return control.RectangleToScreen(control.ClientRectangle).Contains(Cursor.Position);
        }

        [Browsable(true)]
        public Image Picture
        {
            get => pictureBox1.Image;

            set
            {
                pictureBox1.Image = value;
                Refresh();
            }
        }

        private void InvokeClick(object sender, EventArgs e)
        {
            OnClick(e);
        }

        public void Unselect()
        {
            borderImage.Image = Properties.Resources.BordersUnselected;
        }
    }
}
