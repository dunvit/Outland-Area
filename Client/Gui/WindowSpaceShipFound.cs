using System;
using System.Windows.Forms;
using OutlandAreaCommon.Tactical;

namespace Engine.Gui
{
    public partial class WindowSpaceShipFound : Form
    {
        public GameEvent GameEvent { get; set; }

        public GameSession Session { get; set; }
        public WindowSpaceShipFound()
        {
            InitializeComponent();
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void flatButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void flatButton4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
