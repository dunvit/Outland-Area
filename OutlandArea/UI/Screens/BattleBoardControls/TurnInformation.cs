using System;
using System.Windows.Forms;
using OutlandArea.TacticalBattleLayer;

namespace OutlandArea.UI.Screens.BattleBoardControls
{
    public partial class TurnInformation : UserControl
    {
        private Turn CurrentTurn { get; set; }

        public TurnInformation()
        {
            InitializeComponent();
        }

        public void Refresh(Turn turn)
        {
            CurrentTurn = turn;

            labelTurnNumber.Text = CurrentTurn.Number.ToString();
        }

        private void Event_ApplicationExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Event_EndTurn(object sender, EventArgs e)
        {
            Manager.EndTurn(null);
        }
    }
}
