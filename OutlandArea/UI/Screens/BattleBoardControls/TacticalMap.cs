using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using OutlandArea.TacticalBattleLayer;

namespace OutlandArea.UI.Screens.BattleBoardControls
{
    public partial class TacticalMap : UserControl
    {
        private Turn CurrentTurn { get; set; }

        private Timer _refreshScreenTimer;
        private ScreenParameters _screenParameters;

        public TacticalMap()
        {
            InitializeComponent();
        }

        private void Event_MapLoad(object sender, EventArgs e)
        {
            _screenParameters = new ScreenParameters(Width, Height);
            _refreshScreenTimer = new Timer();
            _refreshScreenTimer.Tick += Event_RefreshScreenTimer;
            _refreshScreenTimer.Interval = 100;
            _refreshScreenTimer.Enabled = true;
        }

        public void Refresh(Turn turn)
        {
            CurrentTurn = turn;

            
        }

        private void Event_RefreshScreenTimer(object sender, EventArgs e)
        {
            if (CurrentTurn != null)
            {

            }

            DrawScreen();
        }

        private void DrawScreen()
        {
            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            var pen = new Pen(Color.FromArgb(0, 19, 0));

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            //for (var i = 1; i < 5; i++)
            //{
            //    graphics.DrawEllipse(new Pen(Color.DimGray, 1),
            //        _screenParameters.Center.X - i * 100 - 25,
            //        _screenParameters.Center.Y - i * 100 - 25,
            //        i * 200 + 50,
            //        i * 200 + 50);
            //}

            graphics.DrawLine(new Pen(Color.WhiteSmoke, 4), new Point(_screenParameters.Center.X + 10, _screenParameters.Center.Y), new Point(_screenParameters.Center.X - 10, _screenParameters.Center.Y));
            graphics.DrawLine(new Pen(Color.WhiteSmoke, 4), new Point(_screenParameters.Center.X, _screenParameters.Center.Y + 10), new Point(_screenParameters.Center.X, _screenParameters.Center.Y - 10));


            pictureBox1.Image = image;
        }


    }
}
