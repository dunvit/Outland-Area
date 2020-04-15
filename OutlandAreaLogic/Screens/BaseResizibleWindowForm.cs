using System;
using System.Windows.Forms;
using OutlandAreaLogic.Tools;

namespace Engine
{
    public class BaseResizeWindowForm: Form
    {
        private WinFormResize _formResize;

        public void Initialization()
        {
            _formResize = new WinFormResize(this);

            Load += _Load;
            Resize += _Resize;
        }

        private void _Load(object sender, EventArgs e)
        {
            _formResize._get_initial_size();
        }

        private void _Resize(object sender, EventArgs e)
        {
            _formResize._resize();
        }
    }
}
