using System;
using System.Windows.Forms;
using OutlandAreaLogic.DialogSystems.Schemes;
using Prototypes.Dialogs;

namespace Prototypes
{
    public partial class Form1 : Form, IDialogWindow
    {
        private readonly Manager _dialogsManager;

        public Form1()
        {
            _dialogsManager = new Manager {Container = this};
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private bool _isWindowActivated;

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (_isWindowActivated == false)
            {
                _dialogsManager.Show(637066561468000000);
                _isWindowActivated = true;
            }
        }

        public void Execute(DialogRowScheme dialogRow)
        {
            var windowSimpleDialog = new WindowSimpleDialog();

            windowSimpleDialog.DrawDialogRow(dialogRow);

            windowSimpleDialog.ShowDialog(this);

            _dialogsManager.Show(windowSimpleDialog.ExitId);
        }
    }

    
}
