using System;
using System.Drawing;
using System.Windows.Forms;

namespace Engine.Screens
{
    public partial class WindowBattleContainer : BaseResizeWindowForm
    {
        private Form currentChildForm;
        private UserControl currentChildUserControl;

        private WindowCompartmentNavigation _compartmentNavigation;
        private WindowCompartmentTargeting _compartmentTargeting;
        private ScreenShipInformation _screenShipInformation;
        private ScreenNavigation _screenNavigation;

        public WindowBattleContainer()
        {
            InitializeComponent();

            Initialization();

            //OpenChildControl(new ScreenShipInformation());
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
            if(currentChildUserControl != null) currentChildUserControl.Hide();

            childForm.BackColor = Color.Transparent;

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
            if (_screenNavigation == null)
            {
                _screenNavigation = new ScreenNavigation();
            }

            OpenChildControl(_screenNavigation);
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

        private bool isActivated;

        private void WindowBattleContainer_Activated(object sender, EventArgs e)
        {
            if (isActivated) return;

            isActivated = true;

            if (_screenShipInformation == null)
            {
                _screenShipInformation = new ScreenShipInformation();
            }

            OpenChildControl(_screenShipInformation);
        }

        private void hexogonalButton1_Click(object sender, EventArgs e)
        {
            if (_screenShipInformation == null)
            {
                _screenShipInformation = new ScreenShipInformation();
            }

            OpenChildControl(new ScreenShipInformation());
        }
    }

}
