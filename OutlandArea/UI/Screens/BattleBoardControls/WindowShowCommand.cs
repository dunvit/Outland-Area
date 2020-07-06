using System;
using System.Windows.Forms;
using OutlandArea.TacticalBattleLayer;

namespace OutlandArea.UI.Screens.BattleBoardControls
{
    public partial class WindowShowCommand : Form
    {
        public event Action<ICommand> OnAddCommand;

        public ICommand Command { get; set; }

        public WindowShowCommand()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void Event_AddCommand(object sender, EventArgs e)
        {
            OnAddCommand?.Invoke(Command);

            Close();
        }
    }
}
