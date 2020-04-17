using System;
using System.Windows.Forms;
using Engine;

namespace OutlandArea
{
    public partial class ScreenStartMenu : BaseResizeWindowForm
    {
        private Form WindowMenu { get; set; } = new ScreenMenu();

        private bool IsActivated { get; set; }

        public ScreenStartMenu()
        {
            InitializeComponent();

            // Resize window by application settings
            // Default 1280x720
            // Setting loading in Program.cs
            Initialization();
        }

        

        private void Event_LoadMainWindow(object sender, EventArgs e)
        {
            //
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
    }
}
