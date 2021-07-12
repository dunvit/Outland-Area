using System;
using System.Windows.Forms;
using Engine.Layers.Tactical;
using Engine.Tools;
using EngineCore.Session;

namespace Engine.UI.Controls
{
    public partial class ModulePreview : UserControl
    {
        public int Id { get; set; }
        public ModulePreview()
        {
            InitializeComponent();

            if (Global.Game is null) return;

            Global.Game.OnEndTurn += Event_EndTurn;
            Global.Game.OnInitializationFinish += Event_Initialization;
        }

        private void Event_EndTurn(TacticalEnvironment gameSession)
        {
            // TODO: Open after redesign control (cross-thread problem) 
            //RefreshControl(gameSession);
        }

        private void Event_Initialization(TacticalEnvironment gameSession)
        {
            this.PerformSafely(RefreshControl, gameSession);
        }

        private void RefreshControl(TacticalEnvironment gameSession)
        {
            var module = gameSession.Session.GetPlayerSpaceShip().GetModule(Id);

            crlModuleName.Text = module.Name;

            //crlModuleReload.Maximum = (int)module.ReloadTime;
            //crlModuleReload.CurrentValue = (int)module.Reloading;
        }

        private void Event_ModuleActivate(object sender, EventArgs e)
        {
            Global.Game.EventActivateModule(Id);
        }
    }
}
