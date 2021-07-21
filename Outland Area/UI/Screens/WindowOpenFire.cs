using System;
using System.Linq;
using System.Windows.Forms;
using Engine.Layers.Tactical;
using EngineCore.Session;
using EngineCore.Universe.Equipment;

namespace Engine.UI.Screens
{
    public partial class WindowOpenFire : Form
    {
        public WindowOpenFire()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Event_OpenFire(object sender, EventArgs e)
        {
            var environment = (TacticalEnvironment)Tag;

            var targetId = environment.GetActiveObject().Id;

            var moduleId = environment.Action.ModuleId;

            var actionId = environment.Action.ActionId;

            var spacecraft = environment.Session.GetPlayerSpaceShip();

            var module = spacecraft.GetWeaponModule(moduleId);

            var commandBody = ModuleCommand.ToJson(environment.Session, module.Shot, targetId, moduleId, actionId);

            Global.Game.ExecuteCommand(new EngineCore.Command(commandBody));
            environment.SetAction(0, 0, TacticalMode.General);
            environment.CancelAction();
            Global.Game.SessionResume();

            Close();
        }
    }
}
