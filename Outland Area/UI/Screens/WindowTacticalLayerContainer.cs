﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Engine.UI.Controls;
using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Objects;
using log4net;

namespace Engine.UI.Screens
{
    public partial class WindowTacticalLayerContainer : BaseFullScreenWindow
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private GameSession _gameSession;

        public WindowTacticalLayerContainer()
        {
            InitializeComponent();

            if (Global.Game is null) return;

            Global.Game.OnEndTurn += Event_EndTurn;
            Global.Game.OnStartGameSession += Event_StartGameSession;
        }

        private void Event_EndTurn(GameSession gameSession)
        {
            _gameSession = gameSession.DeepClone();
        }

        private void Event_StartGameSession(GameSession gameSession)
        {
            _gameSession = gameSession.DeepClone();

            Initialization(_gameSession);

            Global.Game.InitializationFinish();
        }

        private void Initialization(GameSession gameSession)
        {
            var spaceShip = _gameSession.GetPlayerSpaceShip().ToSpaceship();

            var countModulesPreview = 0;

            foreach (var propulsionModule in spaceShip.Modules)
            {
                var controlPropulsionModule = new ModulePreview
                {
                    Visible = true,
                    Location = new Point(10, 100 * countModulesPreview + 40),
                    Id = propulsionModule.Id
                };

                countModulesPreview++;

                crlCommandsContainer.Controls.Add(controlPropulsionModule);
            }

            crlCommandsContainer.Height = countModulesPreview * 100 + 50;
        }
        

        private void Event_LoadTacticalLayer(object sender, EventArgs e)
        {
            crlTacticalMap.Dock = DockStyle.Fill;

            Logger.Info("[TacticalLayerContainer]\t Initialization finished successful.");
        }

        private void crlTacticalMap_Load(object sender, EventArgs e)
        {

        }
    }
}
