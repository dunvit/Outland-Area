using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Engine.Tools;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Tactical;
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
            Global.Game.OnEndTurn += Event_EndTurn;
            

            crlTacticalMap.OnAlignToCelestialObject += Global.Game.AddCommandAlignTo;
            crlTacticalMap.OnLaunchMissile += Global.Game.AddCommandOpenFire;
            crlTacticalMap.OnRefreshSelectedCelestialObject += crlSelectedObject.Event_SelectCelestialObject;

            weaponCompartment1.OnActivateModule += crlTacticalMap.ActivateModule;

            scanningCompartment.OnActivateModule += Global.Game.ActivateModule;
        }

        private void Event_AnomalyFound(GameEvent gameEvent)
        {
            var a = CallModalForm(gameEvent);
        }

        private delegate DialogResult RefreshCallback(GameEvent gameEvent);

        private static DialogResult CallModalForm(GameEvent gameEvent)
        {
            Form mainForm = null;
            if (Application.OpenForms.Count > 0)
                mainForm = Application.OpenForms[0];

            if (mainForm != null && mainForm.InvokeRequired)
            {
                RefreshCallback d = CallModalForm;
                return (DialogResult)mainForm.Invoke(d, gameEvent);
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
            foreach (var module in gameSession.GetPlayerSpaceShip().ToSpaceship().GetWeaponModules())
            {
                weaponCompartment1.ResetData(gameSession, module);
            }

            scanningCompartment.ResetData(gameSession, gameSession.GetPlayerSpaceShip().ToSpaceship().GetModules(2));
        }

        private void Event_BattleInitialization(GameSession gameSession)
        {
            var playerSpaceship = gameSession.GetPlayerSpaceShip().ToSpaceship();
            
            foreach (var module in playerSpaceship.Modules.Where(m => m.Category == Category.Weapon))
            {
                weaponCompartment1.Initialization(module);
            }

            scanningCompartment.Initialization(playerSpaceship.GetModules(2));
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
    }
}
