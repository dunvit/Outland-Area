using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Engine.Gui.Controls.Common
{
    public partial class ActionButton : UserControl
    {
        private MouseLocationTracker _mouseLocationTracker;
        public new Action OnMouseEnter;
        public new Action OnMouseLeave;

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
            _mouseLocationTracker = new MouseLocationTracker(this);

            _mouseLocationTracker.OnMouseInControl += delegate
            {
                borderImage.Image = Properties.Resources.BordersSelected;
                OnMouseEnter?.Invoke();
            };

            _mouseLocationTracker.OnMouseOutControl += delegate
            {
                borderImage.Image = Properties.Resources.BordersUnselected;
                OnMouseLeave?.Invoke();
            };

            _mouseLocationTracker.OnMouseResumeIntoControl += delegate
            {
                OnMouseEnter?.Invoke();
            };
        }
    }
}
