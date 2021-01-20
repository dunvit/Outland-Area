using System;
using System.Windows.Forms;

namespace Engine.Gui.Controls.Common
{
    public class MouseLocationTracker
    {
        private Timer mTimer;
        private bool _isSelected;
        private readonly UserControl _control;

        public event Action OnMouseInControl;
        public event Action OnMouseOutControl;

        public MouseLocationTracker(UserControl control)
        {
            _control = control;

            mTimer = new Timer { Interval = 200 };
            mTimer.Tick += mTimer_Tick;
            mTimer.Enabled = true;
        }

        private void mTimer_Tick(object sender, EventArgs e)
        {
            if (AmIStillInsideTheUserControl(_control))
            {
                if (_isSelected == false)
                {
                    OnMouseInControl?.Invoke();
                    //borderImage.Image = Properties.Resources.BordersSelected;
                }

                _isSelected = true;
            }
            else
            {
                if (_isSelected == true)
                {
                    OnMouseOutControl?.Invoke();
                    //borderImage.Image = Properties.Resources.BordersUnselected;
                }

                _isSelected = false;
            }
        }

        private static bool AmIStillInsideTheUserControl(Control control)
        {
            return control.RectangleToScreen(control.ClientRectangle).Contains(Cursor.Position);
        }
    }
}
