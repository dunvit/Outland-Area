using System.Drawing;
using System.Windows.Forms;
using Engine.UI.Controls;
using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Equipment;
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

            KeyPreview = true;
            KeyDown += Window_KeyDown;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Logger.Debug($"[{GetType().Name}][Window_KeyDown]\t Handle the KeyDown event {e.KeyCode} ");

            if (_gameSession.IsPause) return;

            var spacecraft = _gameSession.GetPlayerSpaceShip();

            var commandBody = string.Empty;

            switch (e.KeyCode)
            {
                case Keys.S:
                    commandBody = ModuleCommand.ToJson(_gameSession, spacecraft.GetPropulsionModules()[0].Braking);
                    Global.Game.ExecuteCommand(new EngineCore.Command(commandBody));                    
                    break;

                case Keys.D:
                    commandBody = ModuleCommand.ToJson(_gameSession, spacecraft.GetPropulsionModules()[0].TurnRight);
                    Global.Game.ExecuteCommand(new EngineCore.Command(commandBody));
                    break;

                case Keys.A:
                    commandBody = ModuleCommand.ToJson(_gameSession, spacecraft.GetPropulsionModules()[0].TurnLeft);
                    Global.Game.ExecuteCommand(new EngineCore.Command(commandBody));
                    break;

                case Keys.W:
                    commandBody = ModuleCommand.ToJson(_gameSession, spacecraft.GetPropulsionModules()[0].Acceleration);
                    Global.Game.ExecuteCommand(new EngineCore.Command(commandBody));
                    break;

                default:
                    break;
            }
        }



        private void Event_SelectModule(int moduleId)
        {
            crlModule.Initialization(moduleId, _gameSession);
            crlModule.Visible = true;
        }

        private void Event_EndTurn(GameSession gameSession)
        {
            _gameSession = gameSession;
        }

        private void Event_StartGameSession(GameSession gameSession)
        {
            crlTacticalMap.Refresh();

            _gameSession = gameSession;

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
