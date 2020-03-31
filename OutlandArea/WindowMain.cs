using Engine;
using Engine.Dialogs;
using OutlandAreaLogic.DialogSystems.Schemes;
using System.Windows.Forms;
using OutlandAreaLogic.Compartments;

namespace OutlandArea
{
    public partial class WindowMain : Form, ICompartmentWindow
    {
        private readonly Manager _manager;

        public WindowMain()
        {
            _manager = new Manager { Container = this };

            InitializeComponent();
        }

        public void Execute(DialogRowScheme dialogRow)
        {
            var windowSimpleDialog = new WindowSimpleDialog(_manager);

            windowSimpleDialog.DrawDialogRow(dialogRow);

            windowSimpleDialog.TopLevel = false;
            windowSimpleDialog.AutoScroll = true;

            panel1.Controls.Add(windowSimpleDialog);
            windowSimpleDialog.Show();

            Control controlForRemove = null;

            if (panel1.Controls.Count == 2)
            {
                foreach (Control panel1Control in panel1.Controls)
                {
                    if (controlForRemove == null)
                    {
                        controlForRemove = panel1Control;
                    }
                }

                if (controlForRemove != null)
                {
                    panel1.Controls.Remove(controlForRemove);
                }
            }
        }

        public void ShowCompartment(UserControl compartment)
        {
            crlCompartment.Controls.Add(compartment);

            compartment.Show();

            Control controlForRemove = null;

            if (crlCompartment.Controls.Count == 2)
            {
                foreach (Control panel1Control in crlCompartment.Controls)
                {
                    if (controlForRemove == null)
                    {
                        controlForRemove = panel1Control;
                    }
                }

                if (controlForRemove != null)
                {
                    crlCompartment.Controls.Remove(controlForRemove);
                }
            }
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

        private void Event_ShowNavigationCompartment(object sender, System.EventArgs e)
        {
            _manager.ShowCompartment("Navigation");
        }

        private void Event_ShowCargoCompartment(object sender, System.EventArgs e)
        {
            _manager.ShowCompartment("Cargo");
        }
    }
}
