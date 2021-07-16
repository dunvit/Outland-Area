using System.Drawing;
using System.Windows.Forms;
using Engine.Layers.Tactical;
using Engine.UI.Controls;
using EngineCore.Session;
using EngineCore.Universe.Equipment;
using EngineCore.Universe.Objects;
using log4net;

namespace Engine.UI.Screens
{
    public partial class WindowTacticalLayerContainer : BaseFullScreenWindow
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TacticalEnvironment _environment;

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
            Logger.Debug($"Window_KeyDown - Handle the KeyDown event {e.KeyCode} ");

            var spacecraft = _environment.Session.GetPlayerSpaceShip();

            string commandBody;

            switch (e.KeyCode)
            {
                case Keys.S:
                    if (_environment.Session.IsPause) return;
                    commandBody = ModuleCommand.ToJson(_environment.Session, spacecraft.GetPropulsionModules()[0].Braking);
                    Global.Game.ExecuteCommand(new EngineCore.Command(commandBody));                    
                    break;

                case Keys.D:
                    if (_environment.Session.IsPause) return;
                    commandBody = ModuleCommand.ToJson(_environment.Session, spacecraft.GetPropulsionModules()[0].TurnRight);
                    Global.Game.ExecuteCommand(new EngineCore.Command(commandBody));
                    break;

                case Keys.A:
                    if (_environment.Session.IsPause) return;
                    commandBody = ModuleCommand.ToJson(_environment.Session, spacecraft.GetPropulsionModules()[0].TurnLeft);
                    Global.Game.ExecuteCommand(new EngineCore.Command(commandBody));
                    break;

                case Keys.W:
                    if (_environment.Session.IsPause) return;
                    commandBody = ModuleCommand.ToJson(_environment.Session, spacecraft.GetPropulsionModules()[0].Acceleration);
                    Global.Game.ExecuteCommand(new EngineCore.Command(commandBody));
                    break;

                case Keys.Escape:
                    _environment.CancelAction();
                    if(_environment.Session.IsPause)
                        Global.Game.SessionResume();
                    break;
            }
        }

        private void Event_SelectModule(int moduleId)
        {
            // Resume game if it was on pause by module action
            if (_environment.Mode != TacticalMode.General && _environment.Session.IsPause)
            {
                Global.Game.SessionResume();
            }

            // Cancel previous action
            Global.Game.EventCancelModuleAction();

            crlModule.Initialization(moduleId, _environment);
            crlModule.Visible = true;
        }

        private void Event_EndTurn(TacticalEnvironment environment)
        {
            _environment = environment;
        }

        private void Event_StartGameSession(TacticalEnvironment environment)
        {
            crlTacticalMap.Refresh();

            _environment = environment;

            Initialization(_environment);

            Global.Game.InitializationFinish();

            Global.Game.UiManager.HideBackGround();
        }

        private void Initialization(TacticalEnvironment environment)
        {
            var spaceShip = _environment.Session.GetPlayerSpaceShip().ToSpaceship();

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

            Logger.Info("Initialization finished successful.");
        }
    }
}
