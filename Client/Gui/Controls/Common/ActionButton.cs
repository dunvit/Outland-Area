using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Engine.Gui.Controls.Common
{
    public partial class ActionButton : UserControl
    {
        private MouseLocationTracker mouseLocationTracker;

        public ActionButton()
        {
            InitializeComponent();


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

        private void ActionButton_Load(object sender, EventArgs e)
        {
            mouseLocationTracker = new MouseLocationTracker(this);

            mouseLocationTracker.OnMouseInControl += delegate
            {
                borderImage.Image = Properties.Resources.BordersSelected;
            };

            mouseLocationTracker.OnMouseOutControl += delegate
            {
                borderImage.Image = Properties.Resources.BordersUnselected;
            };
        }
    }
}
