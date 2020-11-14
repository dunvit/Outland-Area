using System;
using Engine.Configuration;
using Engine.Layers.Tactical;
using Engine.Tools;
using log4net;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Timers;
using System.Windows.Forms;
using OutlandArea.Tools;
using OutlandAreaCommon;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using Timer = System.Timers.Timer;

namespace Engine.Gui.Controls
{
    public partial class TacticalMap : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Point _centerScreenPosition = new Point(10000, 10000);
        private ScreenParameters _screenParameters;
        private GameSession _gameSession;
        private MapSettings mapSettings = new MapSettings();
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
            Logger.Info($"[{GetType().Name}]\t Celestial map control - Initialization.");

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
            Logger.Debug($"[{GetType().Name}]\t Refresh celestial map control.");

            if (refreshInProgress) return;

            var timeDrawScreen = Stopwatch.StartNew();

            refreshInProgress = true;

            DrawScreen();

            refreshInProgress = false;

            Logger.Debug($"[{GetType().Name}]\t [DrawScreen] Time {timeDrawScreen.Elapsed.TotalMilliseconds} ms.");
        }

        private void DrawScreen()
        {
            Logger.Debug($"[{GetType().Name}]\t [DrawScreen]");

            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            foreach (var currentObject in _gameSession.Map.CelestialObjects)
            {
                switch ((CelestialObjectTypes)currentObject.Classification)
                {
                    case CelestialObjectTypes.Asteroid:
                        // Regular asteroid
                        DrawTacticalMap.DrawAsteroid(currentObject, graphics, _screenParameters);
                        break;
                    case CelestialObjectTypes.Spaceship:
                        if (mapSettings.IsDrawSpaceshipInformation)
                            DrawTacticalMap.DrawSpaceshipInformation(currentObject, graphics, _screenParameters);

                        DrawTacticalMap.DrawSpaceship(currentObject, graphics, _screenParameters);

                        break;
                    case CelestialObjectTypes.Missile:
                        DrawTacticalMap.DrawMissile(currentObject, graphics, _screenParameters);
                        break;
                }

                if (mapSettings.IsDrawCelestialObjectDirections)
                {
                    try
                    {
                        DrawTacticalMap.DrawCelestialObjectDirection(currentObject, graphics, _screenParameters);
                    }
                    catch (Exception e)
                    {
                        Logger.Error(e.Message);
                    }

                }

                if (mapSettings.IsDrawCelestialObjectCoordinates)
                {
                    if (currentObject.Classification > 0)
                        DrawTacticalMap.DrawCelestialObjectCoordinates(currentObject, graphics, _screenParameters);
                }
            }

            BackgroundImage = image;
        }

        private void MapClick(object sender, MouseEventArgs e)
        {
            Logger.Info($"[{GetType().Name}]\t [MapClick]");

            var mouseScreenCoordinates = OutlandAreaCommon.Tools.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            var mouseMapCoordinates = OutlandAreaCommon.Tools.ToTacticalMapCoordinates(mouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

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
            Logger.Debug($"[{GetType().Name}]\t [MapMouseMove]");

            var mouseScreenCoordinates = OutlandAreaCommon.Tools.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            var mouseMapCoordinates = OutlandAreaCommon.Tools.ToTacticalMapCoordinates(mouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            var celestialObjectInRange = SessionTools.GetObjectInRange(_gameSession, 15, new Point(mouseMapCoordinates.X, mouseMapCoordinates.Y));

            MouseMoveCelestialObject = celestialObjectInRange?.DeepClone();
        }

        private void Event_RefreshCelestialMap(GameSession gameSession)
        {
            turn = gameSession.Turn;

            if (crlRefreshMap == null)
            {
                Initialization();
            }

            Logger.Debug($"[{GetType().Name}]\t [Refresh] Turn: {turn}.");

            _gameSession = gameSession;
        }
    }
}
