using System;
using System.Windows.Forms;
using OutlandArea.Battle;

namespace OutlandArea.UI.Screens
{
    public partial class BattleBoard : Form
    {
        public BattleBoard()
        {
            InitializeComponent();

            Manager.OnStartNewTurn += Event_StartNewTurn;

            
        }

        private void Event_StartNewTurn(Turn turn)
        {
            turnInformation1.Refresh(turn);
        }

        private void Event_CloseApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
