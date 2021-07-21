using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Engine.Layers.Tactical;
using Engine.Tools;
using EngineCore.Session;
using EngineCore.Universe.Equipment.Weapon;
using log4net;

namespace Engine.UI.Controls
{
    public partial class Module : UserControl
    {
        private int _moduleId;

        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private TacticalEnvironment _environment;

        public Module()
        {
            InitializeComponent();

            if (Global.Game is null) return;

            Global.Game.OnEndTurn += Event_EndTurn;
        }

        public void Initialization(int moduleId, TacticalEnvironment gameSession)
        {
            _environment = gameSession;
            _moduleId = moduleId;

            var module = gameSession.Session.GetPlayerSpaceShip().GetModule(_moduleId);

            actionsContainer.Controls.Clear();

            if (module is IWeaponModule)
            {
                var i = 0;

                foreach (var moduleSkill in module.Skills)
                {
                    i++;

                    var attackAction = new ActionAttack(moduleId, moduleSkill.Id, gameSession.Session)
                    {
                        Location = new Point((i - 1) * 55, 0)
                    };

                    _logger.Info($"Add action '{moduleSkill.Id}' to module '{module.Id}'");
                    attackAction.Tag = module.Id;
                    attackAction.Click += Event_SelectAction;

                    actionsContainer.Controls.Add(attackAction);
                }
            }
        }

        private void Event_SelectAction(object? sender, EventArgs e)
        {
            var action = (ActionAttack) sender;

            var moduleId = action.ModuleId;
            var actionId = action.Id;

            var module = _environment.Session.GetPlayerSpaceShip().GetModule(moduleId);

            if (module.IsReloaded == false)
            {
                Global.Game.ShowAlertOnReloadingModule(module);
                return;
            }

            var mode = TacticalMode.SelectingSpaceObject;

            if (module is IWeaponModule) mode = TacticalMode.SelectingSpaceObjectForShot;

            _environment.SetAction(moduleId, actionId, mode);
            Global.Game.SessionPause();
        }

        private void Event_EndTurn(TacticalEnvironment gameSession)
        {
            if (_moduleId == 0) return;

            this.PerformSafely(RefreshControl, gameSession);
        }

        private void RefreshControl(TacticalEnvironment gameSession)
        {
            var module = gameSession.Session.GetPlayerSpaceShip().GetModule(_moduleId);

            crlModuleName.Text = module.Name;

            crlReloading.Maximum = (int) module.ReloadTime;
            crlReloading.CurrentValue = (int) module.Reloading;
        }

        private void Event_CloseModule(object sender, EventArgs e)
        {
            _moduleId = 0;
            Visible = false;
        }
    }
}
