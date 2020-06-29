using System;
using System.Drawing;
using System.Windows.Forms;
using Engine;
using OutlandArea.UI.Screens;
using OutlandArea.UI.Screens.Dialog;
using OutlandAreaLogic;

namespace OutlandArea
{
    public partial class ScreenStartMenu : BaseResizeWindowForm, IScreenCommands
    {
        private Form WindowMenu { get; set; } = new ScreenMenu();

        private Form DialogScreen { get; set; } = new DialogScreen { Size = Global.ApplicationSettings.WindowSize };

        private Form BattleBoardScreen { get; set; } = new BattleBoard {Size = new Size(1920, 1080)};

        private bool IsActivated { get; set; }

        public ScreenStartMenu()
        {
            InitializeComponent();

            // Resize window by application settings
            // Default 1280x720
            // Setting loading in Program.cs
            Initialization();
        }

        private void Event_ActivateWindow(object sender, EventArgs e)
        {
            // Exit from activation flow if window already active.
            if (IsActivated) return;

            // Run menu window
            WindowMenu.ShowDialog();

            // Set window status is active.
            IsActivated = true;
        }

        public void Execute(string screenName)
        {
            controlCurrentStatus.Text = @"Current status: Load window " + screenName;

            switch (screenName)
            {
                case "Dialog Screen":

                    DialogScreen.ShowDialog();
                    break;

                case "Battle Board":
                    BattleBoardScreen.ShowDialog();
                    break;
            }

            Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                {
                    WindowMenu.ShowDialog();

                    return true;
                }
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}
