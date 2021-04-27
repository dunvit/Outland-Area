using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Engine.Configuration;
using Engine.UI.DrawEngine;
using Engine.UI.Model;
using EngineCore.Session;
using EngineCore.Tools;
using log4net;

namespace Engine.UI.Controls
{
    public partial class TacticalMap : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        private readonly Point _centerScreenPosition = new Point(10000, 10000);
        private ScreenParameters _screenParameters;
        private GameSession _gameSession;
        private bool _refreshInProgress;

        public TacticalMap()
        {
            InitializeComponent();

            if (Global.Game is null) return;

            Global.Game.OnEndTurn += Event_EndTurn;
            Global.Game.OnStartGameSession += Event_StartGameSession;
        }

        private void Event_StartGameSession(GameSession gameSession)
        {
            _gameSession = gameSession.DeepClone();

            Logger.Info($"[TacticalMap] Start game session for id '{_gameSession.Id}'.");

            RefreshControl();
        }


        private void Event_EndTurn(GameSession gameSession)
        {
            _gameSession = gameSession.DeepClone();

            Logger.Info($"[TacticalMap] Refresh space map for turn '{_gameSession.Turn}'.");

            RefreshControl();
        }

        private void RefreshControl()
        {
            if (_refreshInProgress) return;

            var timeDrawScreen = Stopwatch.StartNew();

            _refreshInProgress = true;

            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            _screenParameters =
                new ScreenParameters(Width, Height, _centerScreenPosition.X, _centerScreenPosition.Y)
                {
                    GraphicSurface = graphics
                };

            DrawTacticalMapScreen(_screenParameters, _gameSession);

            BackgroundImage = image; 

            _refreshInProgress = false;

            Logger.Info($"[TacticalMap] Refresh space map for turn '{_gameSession.Turn}' was finished successful. Time {timeDrawScreen.Elapsed.TotalMilliseconds} ms.");
        }



        private void DrawTacticalMapScreen(IScreenInfo screenParameters, GameSession gameSession)
        {
            // TODO: - Draw back ground only once
            DrawTacticalMap.DrawBackGround(screenParameters);

            DrawTacticalMap.DrawGrid(screenParameters);

            DrawTacticalMap.DrawCelestialObjects(screenParameters, gameSession);

            DrawTacticalMap.DrawDirections(screenParameters, gameSession);
        }
    }
}
