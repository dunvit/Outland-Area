using System;
using System.Reflection;
using System.Windows.Forms;
using Engine.Tools;
using EngineCore.Session;
using log4net;

namespace Engine.UI.Controls
{
    public partial class Module : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private int _moduleId;

        public Module()
        {
            InitializeComponent();

            if (Global.Game is null) return;

            Global.Game.OnEndTurn += Event_EndTurn;
        }


        public void Initialization(int moduleId, GameSession gameSession)
        {
            _moduleId = moduleId;

            var module = gameSession.GetPlayerSpaceShip().GetModule(_moduleId);
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
