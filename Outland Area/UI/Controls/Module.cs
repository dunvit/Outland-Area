using System;
using System.Windows.Forms;
using Engine.Tools;
using EngineCore.Session;

namespace Engine.UI.Controls
{
    public partial class Module : UserControl
    {
        private int _moduleId;

        public Module()
        {
            InitializeComponent();

            if (Global.Game is null) return;

            Global.Game.OnEndTurn += Event_EndTurn;
        }

        public void Initialization(int moduleId)
        {
            _moduleId = moduleId;
 
        }

        private void Event_EndTurn(GameSession gameSession)
        {
            if (_moduleId == 0) return;

            this.PerformSafely(RefreshControl, gameSession);
        }

        private void RefreshControl(GameSession gameSession)
        {
            var module = gameSession.GetPlayerSpaceShip().GetModule(_moduleId);

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
