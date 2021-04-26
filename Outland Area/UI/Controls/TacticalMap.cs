using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Engine.Tools;
using EngineCore.Session;
using EngineCore.Tools;
using log4net;

namespace Engine.UI.Controls
{
    public partial class TacticalMap : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private GameSession _gameSession;

        public TacticalMap()
        {
            InitializeComponent();

            if (Global.Game != null)
                Global.Game.OnEndTurn += Event_EndTurn;
        }

        private void Event_EndTurn(GameSession gameSession)
        {
            _gameSession = gameSession.DeepClone();

            Logger.Info($"[TacticalMap] Refresh space map for turn '{_gameSession.Turn}'.");

            this.PerformSafely(RefreshControl);
        }

        private void RefreshControl()
        {
            var timeDrawScreen = Stopwatch.StartNew();

            txtTurn.Text = _gameSession.Turn + "";

            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            //------------------------------------------------------------------------------------------------------ Start Drawing

            

            //------------------------------------------------------------------------------------------------------ Finish Drawing

            BackgroundImage = image;

            Logger.Info($"[TacticalMap] Refresh control was successful. Time {timeDrawScreen.Elapsed.TotalMilliseconds} ms.");
        }
    }
}
