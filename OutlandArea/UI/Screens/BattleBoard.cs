using System;
using System.Windows.Forms;
using OutlandArea.TacticalBattleLayer;

namespace OutlandArea.UI.Screens
{
    public partial class BattleBoard : Form
    {


        public BattleBoard()
        {
            InitializeComponent();

            controlTacticalMap.Size = new System.Drawing.Size(1918, 1078);

            Manager.OnStartNewTurn += Event_StartNewTurn;

            
        }

        private void Event_StartNewTurn(Turn turn)
        {
            turnInformation1.Refresh(turn);
            controlTacticalMap.Refresh(turn);
        }

        private void Event_CloseApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Event_BoardLoad(object sender, EventArgs e)
        {
            Manager.FinishInitialization();
        }
    }
}
