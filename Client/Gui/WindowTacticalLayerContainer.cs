using System;
using System.Linq;
using System.Windows.Forms;
using Engine.Tools;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using Message = OutlandAreaCommon.Tactical.Message;

namespace Engine.Gui
{
    public partial class WindowTacticalLayerContainer : BaseFullScreenWindow
    {
        private long weaponCompartmentId = 0;
        //private readonly WindowAnomalyFound _windowAnomalyFound = new WindowAnomalyFound();

        public WindowTacticalLayerContainer()
        {
            InitializeComponent();

            crlTacticalMap.Dock = DockStyle.Fill;

            if (DebugTools.IsInDesignMode())
                return;

            Global.Game.OnSelectCelestialObject += controlCommands.Event_SelectCelestialObject;
           
            Global.Game.OnBattleInitialization += Event_BattleInitialization;
            Global.Game.OnAnomalyFound += Event_AnomalyFound;
            Global.Game.OnEndTurn += Event_EndTurn;
            

            controlCommands.OnAlignToCelestialObject += Global.Game.AddCommandAlignTo;
            crlTacticalMap.OnAlignToCelestialObject += Global.Game.AddCommandAlignTo;
            crlTacticalMap.OnLaunchMissile += Global.Game.AddCommandOpenFire;
            crlTacticalMap.OnRefreshSelectedCelestialObject += crlSelectedObject.Event_SelectCelestialObject;
            controlCommands.OnAlignToCelestialObject += crlTacticalMap.CommandAlignTo;
            controlCommands.OnOrbitCelestialObject += Global.Game.AddCommandOrbit;
            controlCommands.OnOpenFire += Global.Game.AddCommandOpenFire;

            crlWeaponLauncher.OnActivateModule += crlTacticalMap.ActivateModule;
            
        }

        private void Event_AnomalyFound(Message message)
        {
            var a = CallModalForm(message);
        }

        private delegate DialogResult RefreshCallback(Message message);

        private DialogResult CallModalForm(Message message)
        {
            Form mainForm = null;
            if (Application.OpenForms.Count > 0)
                mainForm = Application.OpenForms[0];

            if (mainForm != null && mainForm.InvokeRequired)
            {
                RefreshCallback d = CallModalForm;
                return (DialogResult)mainForm.Invoke(d, message);
            }

            var windowAnomalyFound = new WindowAnomalyFound
            {
                ShowInTaskbar = false,
                ShowIcon = false,
                Message = message
            };

            return windowAnomalyFound.ShowDialog();
        }


        private void Event_EndTurn(GameSession gameSession)
        {
            foreach (var module in gameSession.GetPlayerSpaceShip().ToSpaceship().GetWeaponModules())
            {
                crlWeaponLauncher.ResetData(gameSession, module);
            }
        }

        private void Event_BattleInitialization(GameSession gameSession)
        {
            var playerSpaceship = gameSession.GetPlayerSpaceShip().ToSpaceship();
            
            foreach (var module in playerSpaceship.Modules.Where(m => m.Category == Category.Weapon))
            {
                crlWeaponLauncher.Initialization(module);
            }

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
    }
}
