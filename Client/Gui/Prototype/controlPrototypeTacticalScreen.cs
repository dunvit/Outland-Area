using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Engine.Configuration;
using Engine.Gui.Controller;
using Engine.Gui.Controls.TacticalLayer;
using Engine.Tools;

namespace Engine.Gui.Prototype
{
    public partial class controlPrototypeTacticalScreen : UserControl
    {
        private readonly Point _centerScreenPosition = new Point(10000, 10000);
        private ScreenParameters _screenParameters;

        public controlPrototypeTacticalScreen()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            if (DebugTools.IsInDesignMode()) return;

            _screenParameters = new ScreenParameters(Width, Height, _centerScreenPosition.X, _centerScreenPosition.Y);

            Scheduler.Instance.ScheduleTask(100, 100, RefreshControl);
        }

        private void RefreshControl()
        {
            this.PerformSafely(Refresh);
        }

        private void Event_DrawControl(object sender, PaintEventArgs e)
        {
            if (DebugTools.IsInDesignMode()) return;

            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            var currentTurnBoardInfo = new BoardInfo
            {
                GraphicSurface = graphics,
                ScreenInfo = _screenParameters,
                TurnInfo = null,
                TurnStep = 1
            };

            DrawMapTools.DrawGrid(currentTurnBoardInfo);

            BackgroundImage = image;
        }
    }
}
