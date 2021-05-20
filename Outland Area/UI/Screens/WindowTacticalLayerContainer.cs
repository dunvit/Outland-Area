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
            Global.Game.OnSelectModule += Event_SelectModule;
            Global.Game.OnStartGameSession += Event_StartGameSession;

            Tools.Buffering.SetDoubleBuffered(crlTacticalMap);
            Tools.Buffering.SetDoubleBuffered(crlCommandsContainer);

            crlTacticalMap.Dock = DockStyle.Fill;
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
            crlTacticalMap.Refresh();

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

            Logger.Info("[TacticalLayerContainer][Initialization]\t Initialization finished successful.");
        }
    }
}
