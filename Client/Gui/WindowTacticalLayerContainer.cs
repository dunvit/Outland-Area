using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Engine.Tools;
using OutlandAreaCommon;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace Engine.Gui
{
    public partial class WindowTacticalLayerContainer : BaseFullScreenWindow
    {
        public WindowTacticalLayerContainer()
        {
            InitializeComponent();

            crlTacticalMap.Dock = DockStyle.Fill;

            if (DebugTools.IsInDesignMode())
                return;

           
            Global.Game.OnBattleInitialization += Event_BattleInitialization;
            Global.Game.OnAnomalyFound += Event_AnomalyFound;
            Global.Game.OnOpenDialog += EventDialog;
            Global.Game.OnFoundSpaceship += Event_FoundSpaceship;
            Global.Game.OnEndTurn += Event_EndTurn;
            

            crlTacticalMap.OnAlignToCelestialObject += Global.Game.AddCommandAlignTo;
            crlTacticalMap.OnLaunchMissile += Global.Game.AddCommandOpenFire;
            crlTacticalMap.OnRefreshSelectedCelestialObject += crlSelectedObject.Event_SelectCelestialObject;

            Global.Game.OnActivateModuleForPointInMap += crlTacticalMap.ActivateModule;
            Global.Game.OnActivateModuleForSelectObjectInMap += crlTacticalMap.ActivateModuleForSelectObject;

            weaponCompartment1.OnExecuteModule += Global.Game.ExecuteModule;
            weaponCompartment1.OnActivateModule += Global.Game.ActivateModule;
            weaponCompartment1.OnDeactivateModule += Global.Game.DeactivateModule;

            scanningCompartment.OnExecuteModule += Global.Game.ExecuteModule;
            scanningCompartment.OnActivateModule += Global.Game.ActivateModule;
            scanningCompartment.OnDeactivateModule += Global.Game.DeactivateModule;

            propulsionCompartment1.OnChangeDirection += Global.Game.NavigationChangeDirection;
        }

        private void Event_FoundSpaceship(GameEvent gameEvent, GameSession gameSession)
        {
            Global.Game.PauseSession();

            var dialogResult = CallModalFormFoundSpaceship(gameEvent, gameSession);

            Global.Game.ResumeSession();
        }

        private void Event_AnomalyFound(GameEvent gameEvent, GameSession gameSession)
        {
            var a = CallModalForm(gameEvent, gameSession);
            Global.Game.ResumeSession();
        }

        private void EventDialog(GameEvent gameEvent, GameSession gameSession)
        {
            var a = CallModalForm(gameEvent, gameSession);

            Global.Game.ResumeSession();
        }
        //EventDialog

        private delegate DialogResult RefreshCallback(GameEvent gameEvent, GameSession gameSession);

        private static DialogResult CallModalFormFoundSpaceship(GameEvent gameEvent, GameSession gameSession)
        {
            Form mainForm = null;
            if (Application.OpenForms.Count > 0)
                mainForm = Application.OpenForms[0];

            if (mainForm != null && mainForm.InvokeRequired)
            {
                RefreshCallback d = CallModalFormFoundSpaceship;
                return (DialogResult)mainForm.Invoke(d, gameEvent, gameSession);
            }

            var windowAnomalyFound = new WindowSpaceShipFound
            {
                ShowInTaskbar = false,
                ShowIcon = false,
                GameEvent = gameEvent,
                Session = gameSession
            };

            return windowAnomalyFound.ShowDialog();
        }

        private static DialogResult CallModalForm(GameEvent gameEvent, GameSession gameSession)
        {
            Form mainForm = null;
            if (Application.OpenForms.Count > 0)
                mainForm = Application.OpenForms[0];

            if (mainForm != null && mainForm.InvokeRequired)
            {
                RefreshCallback d = CallModalForm;
                return (DialogResult)mainForm.Invoke(d, gameEvent, gameSession);
            }

            var windowAnomalyFound = new WindowAnomalyFound
            {
                ShowInTaskbar = false,
                ShowIcon = false,
                GameEvent = gameEvent
            };

            return windowAnomalyFound.ShowDialog();
        }

        private void Event_EndTurn(GameSession gameSession)
        {
            weaponCompartment1.ResetData(gameSession, gameSession.GetPlayerSpaceShip().ToSpaceship().GetModules(1));
            scanningCompartment.ResetData(gameSession, gameSession.GetPlayerSpaceShip().ToSpaceship().GetModules(2));
            propulsionCompartment1.ResetData(gameSession, gameSession.GetPlayerSpaceShip().ToSpaceship().GetModules(2));
        }

        private void Event_BattleInitialization(GameSession gameSession)
        {
            var playerSpaceship = gameSession.GetPlayerSpaceShip().ToSpaceship();

            weaponCompartment1.Initialization(playerSpaceship.GetModules(1));
            scanningCompartment.Initialization(playerSpaceship.GetModules(2));
            propulsionCompartment1.Initialization(playerSpaceship.GetModules(3));
        }

        private void Event_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Event_ResumeGame(object sender, EventArgs e)
        {
            Global.Game.ResumeSession();
        }

        private void WindowTacticalLayerContainer_FormClosing(object sender, FormClosingEventArgs e)
        {
            crlTacticalMap.CloseTacticalMap();
        }

        private void WindowTacticalLayerContainer_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            Global.Game.ResumeSession();
        }

        

        public void ConnectClosestObjects(GameSession gameSession, IModule module, IEnumerable<ICelestialObject> objects, bool show)
        {
            crlTacticalMap.Connectors(gameSession, module, objects, show);
        }
    }
}
