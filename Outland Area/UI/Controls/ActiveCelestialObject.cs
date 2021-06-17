using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Engine.Tools;
using EngineCore.Session;
using EngineCore.Tools;
using log4net;

namespace Engine.UI.Controls
{
    public partial class ActiveCelestialObject : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private GameSession _gameSession;


        public ActiveCelestialObject()
        {
            InitializeComponent();

            if (Global.Game != null)
                Global.Game.OnEndTurn += Event_EndTurn;
        }

        private void Event_EndTurn(GameSession gameSession)
        {
            _gameSession = gameSession.DeepClone();

            Logger.Debug($"[GameSessionInformation] Refresh game information for turn '{_gameSession.Turn}'.");

            this.PerformSafely(RefreshControl);
        }

        private void RefreshControl()
        {
            var activeCelestialObject = Global.Game.GetActiveObject();

            txtInfo.Text = activeCelestialObject != null ? $@"Active object id is {Global.Game.GetActiveObject().Id}" : "";
        }
    }
}
