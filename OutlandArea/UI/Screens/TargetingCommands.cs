using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutlandArea.TacticalBattleLayer;

namespace OutlandArea.UI.Screens
{
    public partial class TargetingCommands : UserControl, IBattleManager
    {
        public event Action<ICommand> OnSelectCommand;

        public long SpacecraftId { get; set; }

        public TargetingCommands()
        {
            InitializeComponent();
        }

        private void cmdCommandFirst_Click(object sender, EventArgs e)
        {
            var command = new TacticalBattleLayer.Commands.Navigation(
                SpacecraftId,
                637066561468099711,
                "Lock target",
                2,
                66,
                "TargetGet",
                new NavigationChanges { DirectionDelta = 0, VelocityDelta = 0 });

            OnSelectCommand?.Invoke(command);
        }

        public Manager Manager { get; }
        public void Activate(Manager manager)
        {
            
        }
    }
}
