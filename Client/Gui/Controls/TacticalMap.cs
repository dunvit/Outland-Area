using Engine.Configuration;
using Engine.Layers.Tactical;
using Engine.Tools;
using log4net;
using System.Diagnostics;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Engine.Gui.Controls
{
    public partial class TacticalMap : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Point _centerScreenPosition = new Point(10000, 10000);
        private ScreenParameters _screenParameters;
        private GameSession _gameSession;
        private int turn;
        private Timer crlRefreshMap;
        private bool refreshInProgress;
        private ICelestialObject MouseMoveCelestialObject { get; set; }

        public TacticalMap()
        {
            InitializeComponent();

            if (DebugTools.IsInDesignMode())
                return;

            Global.Game.OnEndTurn += Event_RefreshCelestialMap;

            
        }

        private void Initialization()
        {
            Logger.Info($"[{GetType().Name}] Celestial map control - Initialization.");

            _screenParameters = new ScreenParameters(Width, Height, _centerScreenPosition.X, _centerScreenPosition.Y);

            if (DebugTools.IsInDesignMode())
                return;

            crlRefreshMap = new Timer();
            crlRefreshMap.Elapsed += Event_Refresh;
            crlRefreshMap.Interval = 100;
            crlRefreshMap.Enabled = true;
        }

        private void Event_Refresh(object sender, ElapsedEventArgs e)
        {
            Logger.Debug($"[{GetType().Name}] Refresh celestial map control.");

            if (refreshInProgress) return;

            var timeDrawScreen = Stopwatch.StartNew();

            refreshInProgress = true;

            DrawScreen();

            refreshInProgress = false;

            Logger.Debug($"[{GetType().Name}][DrawScreen] Time {timeDrawScreen.Elapsed.TotalMilliseconds} ms.");
        }

        private void DrawScreen()
        {
            Logger.Debug($"[{GetType().Name}][DrawScreen]");
        }

        private void MapClick(object sender, MouseEventArgs e)
        {
            Logger.Info($"[{GetType().Name}][MapClick]");

            var mouseScreenCoordinates = Tools.Common.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            var mouseMapCoordinates = Tools.Common.ToTacticalMapCoordinates(mouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            var celestialObjectInRange = SessionTools.GetObjectInRange(_gameSession, 15, new Point(mouseMapCoordinates.X, mouseMapCoordinates.Y));

            if (celestialObjectInRange != null)
            {
                Global.Game.SelectCelestialObject(celestialObjectInRange);
            }
            else
            {
                Global.Game.SelectPointInSpace(mouseMapCoordinates);
            }
        }

        private void MapMouseMove(object sender, MouseEventArgs e)
        {
            Logger.Info($"[{GetType().Name}][MapMouseMove]");

            var mouseScreenCoordinates = Tools.Common.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            var mouseMapCoordinates = Tools.Common.ToTacticalMapCoordinates(mouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            var celestialObjectInRange = SessionTools.GetObjectInRange(_gameSession, 15, new Point(mouseMapCoordinates.X, mouseMapCoordinates.Y));

            MouseMoveCelestialObject = celestialObjectInRange?.DeepClone();
        }

        private void Event_RefreshCelestialMap(GameSession gameSession)
        {
            turn = gameSession.Turn;

            if (crlRefreshMap.Enabled == false)
            {
                Initialization();
            }

            Logger.Info($"[{GetType().Name}][RefreshCelestialMap]" + turn);

            _gameSession = gameSession;
        }
    }
}
