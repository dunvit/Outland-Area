using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;

namespace Engine.Gui
{
    public class UiManager: IUiManager
    {
        private List<Form> Screens;

        private readonly WindowTacticalLayerContainer _tacticalLayerContainer = new WindowTacticalLayerContainer();

        public void Initialization()
        {
            Screens = new List<Form>
            {
                new WindowMenu(),
                _tacticalLayerContainer
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

        public void ConnectClosestObjects(GameSession gameSession, IModule module, IEnumerable<ICelestialObject> objects, bool show)
        {
            _tacticalLayerContainer.ConnectClosestObjects(gameSession, module, objects, show);
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
