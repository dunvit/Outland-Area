using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Engine.UI.Model;
using Engine.UI.Screens;

namespace Engine.UI
{
    public class UiManager: IUiManager
    {
        private List<Form> _screens;

        private readonly WindowTacticalLayerContainer _tacticalLayerContainer = new WindowTacticalLayerContainer();

        public UiManager()
        {
            Initialization();
        }

        public void Initialization()
        {
            _screens = new List<Form>
            {
                new WindowMenu(),
                _tacticalLayerContainer
            };

            foreach (var screen in _screens)
            {
                if (screen is BaseFullScreenWindow)
                {
                    screen.Size = Global.ApplicationSettings.WindowSize;
                    screen.Location = new Point(0, 0);
                }
            }
        }

        public Form GetScreen(string key)
        {
            foreach (var screen in _screens)
            {
                if (screen is WindowMenu && key == "WindowMenu") return screen;

                if (screen is WindowTacticalLayerContainer && key == "WindowTacticalLayerContainer") return screen;

            }
            return null;
        }

        public void StartNewGameSession()
        {
            var windowMenu = GetScreen("WindowMenu");
            var windowTacticalLayerContainer = GetScreen("WindowTacticalLayerContainer");

            windowTacticalLayerContainer.Show();
            windowMenu.Hide();
            windowTacticalLayerContainer.Focus();
        }
    }
}
