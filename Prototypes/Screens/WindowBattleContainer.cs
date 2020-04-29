using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.Screens
{
    public partial class WindowBattleContainer : BaseResizeWindowForm
    {
        private Form currentChildForm;
        private UserControl currentChildUserControl;

        private WindowCompartmentNavigation _compartmentNavigation;
        private WindowCompartmentTargeting _compartmentTargeting;

        public WindowBattleContainer()
        {
            InitializeComponent();

            Initialization();
        }


        private void OpenChildForm(Form childForm)
        {
            //open only form
            currentChildForm?.Close();
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            
            panelCompartmentsContainer.Controls.Add(childForm);
            panelCompartmentsContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //lblTitleChildForm.Text = childForm.Text;

        }

        private void OpenChildControl(UserControl childForm)
        {
            //open only form
            currentChildUserControl = childForm;
            //End
            //childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelCompartmentsContainer.Controls.Add(childForm);
            panelCompartmentsContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //lblTitleChildForm.Text = childForm.Text;

        }


        private void hexogonalButton3_Click(object sender, EventArgs e)
        {
            OpenChildControl(new ScreenNavigation());
        }

        private void hexogonalButton2_Click(object sender, EventArgs e)
        {
            if (_compartmentTargeting == null)
            {
                _compartmentTargeting = new WindowCompartmentTargeting();
            }

            OpenChildForm(new WindowCompartmentTargeting());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
