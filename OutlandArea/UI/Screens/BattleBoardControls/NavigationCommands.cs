using System;
using System.Windows.Forms;
using OutlandArea.TacticalBattleLayer;

namespace OutlandArea.UI.Screens.BattleBoardControls
{
    public partial class NavigationCommands : UserControl, IBattleManager
    {
        public Manager Manager { get; set; }

        public event Action<ICommand> OnSelectCommand;

        public long SpacecraftId { get; set; }

        public NavigationCommands()
        {
            InitializeComponent();
        }

        public void Activate(Manager manager)
        {
            Manager = manager;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void Event_SelectCommand(object sender, EventArgs e)
        {
            var command = new TacticalBattleLayer.Commands.Navigation(
                SpacecraftId, 
                637066561468099898, 
                "Turn on 10 degrees left", 
                2, 
                87, 
                "turnleft",
                new NavigationChanges {DirectionDelta = -10, VelocityDelta = 0});

            OnSelectCommand?.Invoke(command);
        }

        private void cmdCommandSecond_Click(object sender, EventArgs e)
        {
            var command = new TacticalBattleLayer.Commands.Navigation(
                SpacecraftId,
                637066561468099898,
                "Turn on 10 degrees right",
                2,
                87,
                "turnRight",
                new NavigationChanges { DirectionDelta = +10, VelocityDelta = 0 });

            OnSelectCommand?.Invoke(command);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            var command = new TacticalBattleLayer.Commands.Navigation(
                SpacecraftId,
                637066561468099898,
                "Increase a speed",
                2,
                87,
                "IncreseSpeed",
                new NavigationChanges { DirectionDelta = 0, VelocityDelta = 50 });

            OnSelectCommand?.Invoke(command);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            var command = new TacticalBattleLayer.Commands.Navigation(
                SpacecraftId,
                637066561468099898,
                "Decrease a speed",
                2,
                87,
                "decreseSpeed",
                new NavigationChanges { DirectionDelta = 0, VelocityDelta = -50 });

            OnSelectCommand?.Invoke(command);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            var command = new TacticalBattleLayer.Commands.Navigation(
                SpacecraftId,
                637066561468099897,
                "Turn on 10 degrees left",
                2,
                87,
                "turnleft",
                new NavigationChanges { DirectionDelta = -10, VelocityDelta = 0 });

            OnSelectCommand?.Invoke(command);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var command = new TacticalBattleLayer.Commands.Navigation(
                SpacecraftId,
                637066561468099897,
                "Turn on 10 degrees right",
                2,
                87,
                "turnRight",
                new NavigationChanges { DirectionDelta = +10, VelocityDelta = 0 });

            OnSelectCommand?.Invoke(command);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var command = new TacticalBattleLayer.Commands.Navigation(
                SpacecraftId,
                637066561468099897,
                "Increase a speed",
                2,
                87,
                "IncreseSpeed",
                new NavigationChanges { DirectionDelta = 0, VelocityDelta = 50 });

            OnSelectCommand?.Invoke(command);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var command = new TacticalBattleLayer.Commands.Navigation(
                SpacecraftId,
                637066561468099897,
                "Decrease a speed",
                2,
                87,
                "decreseSpeed",
                new NavigationChanges { DirectionDelta = 0, VelocityDelta = -50 });

            OnSelectCommand?.Invoke(command);
        }
    }
}
