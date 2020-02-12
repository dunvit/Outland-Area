using System.Windows.Forms;

namespace OutlandArea
{
    public partial class WindowMain : Form
    {
        public WindowMain()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                {
                    var windowSettings = new UI.Screens.WindowSettings();

                    windowSettings.ShowDialog();

                    return true;
                }
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}
