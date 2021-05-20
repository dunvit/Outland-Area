using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Engine.UI.Model;
using Engine.UI.Screens;
using EngineCore.Events;
using EngineCore.Session;
using log4net;

namespace Engine.UI
{
    public class UiManager: IUiManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<Form> _screens;

        private WindowTacticalLayerContainer _tacticalLayerContainer = new WindowTacticalLayerContainer();

        public UiManager()
        {
            Initialization();
        }

        public void Initialization()
        {
            _screens = new List<Form>
            {
                new WindowMenu(),
                new WindowBackGround(),
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

                if (screen is WindowBackGround && key == "WindowBackGround") return screen;

                if (screen is WindowTacticalLayerContainer && key == "WindowTacticalLayerContainer") return screen;

            }
            return null;
        }

        public void StartNewGameSession()
        {
            var windowTacticalLayerContainer = GetScreen("WindowTacticalLayerContainer");
            var windowBackGround = GetScreen("WindowBackGround");

            windowTacticalLayerContainer.Show();
            windowTacticalLayerContainer.Focus();

            windowBackGround.Hide();
        }

        public void UiInitialization()
        {
            var windowMenu = GetScreen("WindowMenu");
            var windowBackGround = GetScreen("WindowBackGround");

            windowBackGround.Show();
            windowMenu.Hide();
        }

        public void OpenGameEventScreen(GameEvent gameEvent, GameSession gameSession)
        {
            Global.Game.SessionPause();

            var windowGameEvent = new WindowResumeGame
            {
                ShowInTaskbar = false,
                ShowIcon = false,
                GameEvent = gameEvent,
                Session = gameSession
            };

            var result = OpenModalForm(windowGameEvent, gameEvent, gameSession);

            Global.Game.SessionResume();
        }

        private delegate DialogResult RefreshCallback(Form screen, GameEvent gameEvent, GameSession gameSession);

        private static DialogResult OpenModalForm(Form screen, GameEvent gameEvent, GameSession gameSession)
        {
            Form mainForm = null;
            if (Application.OpenForms.Count > 0)
                mainForm = Application.OpenForms[0];

            if (mainForm != null && mainForm.InvokeRequired)
            {
                RefreshCallback d = OpenModalForm;
                return (DialogResult)mainForm.Invoke(d, screen, gameEvent, gameSession);
            }

            Logger.Info($"Received game event ({gameEvent.Id}). Open dialog.");

            return screen.ShowDialog();
        }
    }
}
