using System;
using System.Windows.Forms;
using OutlandAreaCommon.Tactical;

namespace Engine.Gui
{
    public partial class WindowAnomalyFound : Form
    {
        public GameEvent GameEvent { get; set; }
        public WindowAnomalyFound()
        {
            InitializeComponent();
        }

        private void WindowAnomalyFound_Load(object sender, EventArgs e)
        {
            var a = "";
        }

        private void Event_Exit(object sender, EventArgs e)
        {
            Close();
        }
    }
}
