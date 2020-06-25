using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.UserControls;

namespace Engine.Screens
{
    public partial class BattleScreen : BaseResizeWindowForm
    {
        public BattleScreen()
        {
            InitializeComponent();

            Initialization();
        }

        private void oaButton2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BattleMapScreen{Size = panelDesktop.Size});
        }

        private Form currentChildForm;

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
