using System;
using System.Drawing;
using System.Windows.Forms;
using Engine.UI.Controls;
using EngineCore.Events;
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
            Global.Game.OnSelectModule += Event_SelectModule;
            Global.Game.OnFoundSpaceship += Event_FoundSpaceship;
            Global.Game.OnStartGameSession += Event_StartGameSession;
        }

        private void Event_FoundSpaceship(GameEvent gameEvent, GameSession gameSession)
        {
            Global.Game.SessionPause();

            var dialogResult = CallModalFormFoundSpaceship(gameEvent, gameSession);

            Global.Game.SessionResume();
        }

        private delegate DialogResult RefreshCallback(GameEvent gameEvent, GameSession gameSession);

        private static DialogResult CallModalFormFoundSpaceship(GameEvent gameEvent, GameSession gameSession)
        {
            Form mainForm = null;
            if (Application.OpenForms.Count > 0)
                mainForm = Application.OpenForms[0];

            if (mainForm != null && mainForm.InvokeRequired)
            {
                RefreshCallback d = CallModalFormFoundSpaceship;
                return (DialogResult)mainForm.Invoke(d, gameEvent, gameSession);
            }

            var windowAnomalyFound = new WindowResumeGame
            {
                ShowInTaskbar = false,
                ShowIcon = false,
                GameEvent = gameEvent,
                Session = gameSession
            };

            Logger.Info($"Received game event ({gameEvent.Id}). Open dialog.");

            return windowAnomalyFound.ShowDialog();
        }

        private void Event_SelectModule(int moduleId)
        {
            crlModule.Initialization(moduleId);
            crlModule.Visible = true;
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

            crlModule.Location = new Point((Width / 2) - (crlModule.Width / 2), Height - crlModule.Height - 20);
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
