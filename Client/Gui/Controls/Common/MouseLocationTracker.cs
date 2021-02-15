using System;
using System.Windows.Forms;

namespace Engine.Gui.Controls.Common
{
    public class MouseLocationTracker
    {
        private Timer mTimer;
        private bool _isSelected;
        private readonly Control _control;

        public event Action OnMouseInControl;
        public event Action OnMouseOutControl;
        public event Action OnMouseResumeIntoControl;

        public MouseLocationTracker(UserControl control)
        {
            _control = control;

            mTimer = new Timer { Interval = 200 };
            mTimer.Tick += mTimer_Tick;
            mTimer.Enabled = true;
        }

        public MouseLocationTracker(Control control)
        {
            _control = control;

            mTimer = new Timer { Interval = 200 };
            mTimer.Tick += mTimer_Tick;
            mTimer.Enabled = true;
        }

        public bool IsActive => _isSelected;

        private void mTimer_Tick(object sender, EventArgs e)
        {
            if (Tools.DebugTools.IsInDesignMode()) return;

            if (AmIStillInsideTheUserControl(_control))
            {
                if (_isSelected == false)
                {
                    OnMouseInControl?.Invoke();
                }
                else
                {
                    OnMouseResumeIntoControl?.Invoke();

                }

                _isSelected = true;
            }
            else
            {
                if (_isSelected == true)
                {
                    OnMouseOutControl?.Invoke();
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
