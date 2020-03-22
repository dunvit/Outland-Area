using System.Windows.Forms;
using OutlandAreaLogic.DialogSystems.Schemes;

namespace Engine.Dialogs
{
    public partial class WindowSimpleDialog : Form
    {
        private readonly Manager _dialogsManager;

        public long ExitId { get; set; }

        public WindowSimpleDialog(Manager dialogsManager)
        {
            InitializeComponent();

            _dialogsManager = dialogsManager;
        }

        public void DrawDialogRow(DialogRowScheme dialog)
        {
            txtMessage.Text = dialog.Message;

            txtId.Text = dialog.Id.ToString();

            var control = 0;

            foreach (var dialogExitScheme in dialog.Exits)
            {
                control++;

                switch (control)
                {
                    case 1:
                        btnAnswearFirst.Tag = dialogExitScheme.Id;
                        btnAnswearFirst.Text = dialogExitScheme.Text;
                        btnAnswearFirst.Visible = true;
                        break;

                    case 2:
                        btnAnswearSecond.Tag = dialogExitScheme.Id;
                        btnAnswearSecond.Text = dialogExitScheme.Text;
                        btnAnswearSecond.Visible = true;
                        break;
                }
            }
        }

        private void Event_Exit(object sender, System.EventArgs e)
        {
            if (sender is Button control) ExitId = (long) control.Tag;

            _dialogsManager.ShowDialog(ExitId);
        }
    }
}
