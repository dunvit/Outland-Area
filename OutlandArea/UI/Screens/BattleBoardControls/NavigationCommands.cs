using System;
using System.Windows.Forms;
using OutlandArea.TacticalBattleLayer;

namespace OutlandArea.UI.Screens.BattleBoardControls
{
    public partial class NavigationCommands : UserControl
    {
        public event Action<ICommand> OnSelectCommand;

        public long SpacecraftId { get; set; }

        public NavigationCommands()
        {
            InitializeComponent();
        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void Event_SelectCommand(object sender, EventArgs e)
        {
            var command = new TacticalBattleLayer.Commands.Navigation(SpacecraftId, "Turn on 10 degrees left", 2, 87);

            OnSelectCommand?.Invoke(command);
        }


    }
}
