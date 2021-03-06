﻿using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Engine.Layers.Tactical;
using Engine.UI.Model;
using Engine.UI.Screens;
using EngineCore.Events;
using EngineCore.Session;
using EngineCore.Universe.Equipment;
using log4net;

namespace Engine.UI
{
    public class UiManager: IUiManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


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
                new WindowBackGround(),
                new WindowOpenFire(),
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

                if (screen is WindowOpenFire && key == "WindowOpenFire") return screen;

                if (screen is WindowBackGround && key == "WindowBackGround") return screen;

                if (screen is WindowTacticalLayerContainer && key == "WindowTacticalLayerContainer") return screen;

            }
            return null;
        }

        public void OpenGameGenericEventScreen(GameEvent gameEvent, GameSession gameSession)
        {
            Global.Game.SessionPause();

            var windowGameEvent = new WindowGenericEvent(gameEvent, gameSession)
            {
                ShowInTaskbar = false,
                ShowIcon = false,
                StartPosition = FormStartPosition.CenterParent
            };

            var result = OpenModalForm(windowGameEvent, gameEvent, gameSession);

            var decision = windowGameEvent.DecisionResult;

            Global.Game.SessionResume();
        }

        public void OpenGameEventScreen(GameEvent gameEvent, GameSession gameSession)
        {
            Global.Game.SessionPause();

            var windowGameEvent = new WindowObjectFound(gameEvent, gameSession)
            {
                ShowInTaskbar = false,
                ShowIcon = false,
                StartPosition = FormStartPosition.CenterParent
            };

            var result = OpenModalForm(windowGameEvent, gameEvent, gameSession);

            var decision = windowGameEvent.DecisionResult;

            Global.Game.SessionResume();
        }

        public void OpenScreen(string window, TacticalEnvironment environment)
        {
            var form = GetScreen(window);

            form.ShowInTaskbar = false;
            form.ShowIcon = false;
            form.StartPosition = FormStartPosition.CenterParent;

            var result = OpenModalForm(form, environment);
        }

        public void OpenScreen(Form window, TacticalEnvironment environment)
        {
            window.ShowInTaskbar = false;
            window.ShowIcon = false;
            window.StartPosition = FormStartPosition.CenterParent;

            var result = OpenModalForm(window, environment);
        }

        private delegate DialogResult RefreshCallback(Form screen, GameEvent gameEvent, GameSession gameSession);

        private DialogResult OpenModalForm(Form screen, TacticalEnvironment environment)
        {
            Form mainForm = null;
            if (Application.OpenForms.Count > 0)
                mainForm = Application.OpenForms[0];

            if (mainForm != null && mainForm.InvokeRequired)
            {
                RefreshCallback d = OpenModalForm;
                return (DialogResult)mainForm.Invoke(d, screen, environment);
            }

            screen.Tag = environment;

            return screen.ShowDialog();
        }

        private DialogResult OpenModalForm(Form screen, GameEvent gameEvent, GameSession gameSession)
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

        public void StartNewGameSession(GameSession gameSession)
        {
            Logger.Info("Activated.");

            var windowTacticalLayerContainer = GetScreen("WindowTacticalLayerContainer");

            var windowBackGround = GetScreen("WindowBackGround");

            windowTacticalLayerContainer.Show();

            //windowBackGround.Hide();
        }

        public void UiInitialization()
        {
            Logger.Info("UI activated.");

            var windowMenu = GetScreen("WindowMenu");
            var windowBackGround = GetScreen("WindowBackGround");

            windowBackGround.Show();
            windowMenu.Hide();
        }

        public void OpenExplosionResultScreen(GameEvent message, GameSession gameSession)
        {
            Global.Game.SessionPause();

            var windowGameEvent = new WindowExplosionResult(message, gameSession)
            {
                ShowInTaskbar = false,
                ShowIcon = false,
                StartPosition = FormStartPosition.CenterParent
            };

            var result = OpenModalForm(windowGameEvent, message, gameSession);

            Global.Game.SessionResume();
        }

        public void HideBackGround()
        {
            GetScreen("WindowBackGround").Visible = false;
        }

        public void ShowAlertOnReloadingModule(IModule module, TacticalEnvironment environment)
        {
            //WindowAlertModuleReloadingInProgress
            var windowGameEvent = new WindowAlertModuleReloadingInProgress(module, environment.Session)
            {
                ShowInTaskbar = false,
                ShowIcon = false,
                StartPosition = FormStartPosition.CenterParent
            };

            OpenScreen(windowGameEvent, environment);
        }
    }
}
