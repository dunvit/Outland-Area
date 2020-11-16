using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Engine.Gui
{
    public class UiManager: IUiManager
    {
        private List<Form> Screens;

        public void Initialization()
        {
            Screens = new List<Form>
            {
                new WindowMenu(), 
                new WindowTacticalLayerContainer()
            };

            foreach (var screen in Screens)
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
            foreach (var screen in Screens)
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
