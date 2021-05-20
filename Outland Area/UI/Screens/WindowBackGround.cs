using System.Drawing;
using System.Windows.Forms;

namespace Engine.UI.Screens
{
    public partial class WindowBackGround : BaseFullScreenWindow
    {
        public WindowBackGround()
        {
            InitializeComponent();

            BackColor = Color.Black;

            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Normal;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
