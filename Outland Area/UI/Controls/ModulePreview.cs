using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Objects;

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

        private void Event_EndTurn(GameSession gameSession)
        {
            RefreshControl(gameSession);
        }

        private void Event_Initialization(GameSession gameSession)
        {
            RefreshControl(gameSession);
        }

        private void RefreshControl(GameSession gameSession)
        {
            var spaceShip = gameSession.GetPlayerSpaceShip().ToSpaceship();

            foreach (var module in spaceShip.Modules)
            {
                if (module.Id == Id)
                {
                    crlModuleName.Text = module.Name;
                    return;
                }
            }
        }
    }
}
