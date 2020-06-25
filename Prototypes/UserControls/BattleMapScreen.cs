using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.UserControls
{
    public partial class BattleMapScreen : BaseResizeWindowForm
    {
        private Timer refreshScreenTimer;

        private ScreenParameters screenParameters;

        Image _baseImage;

        public BattleMapScreen()
        {
            InitializeComponent();

            Initialization();
        }

        private void DrawBaseImage()
        {
            Image i = new Bitmap(Width, Height);
            var graphics = Graphics.FromImage(i);
            var pen = new Pen(Color.FromArgb(0, 19, 0));

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;



            graphics.DrawEllipse(new Pen(Color.DimGray, 1), 
                screenParameters.Center.X - 100,
                screenParameters.Center.Y - 100,
                200,
                200);

            graphics.DrawEllipse(new Pen(Color.DimGray, 1),
                screenParameters.Center.X - 200,
                screenParameters.Center.Y - 200,
                400,
                400);

            graphics.DrawEllipse(new Pen(Color.DarkGray, 1),
                screenParameters.Center.X - 300,
                screenParameters.Center.Y - 300,
                600,
                600);

            graphics.DrawLine(new Pen(Color.DimGray, 1), new Point(screenParameters.Center.X + 330, screenParameters.Center.Y), new Point(screenParameters.Center.X - 330, screenParameters.Center.Y));
            graphics.DrawLine(new Pen(Color.DimGray, 1), new Point(screenParameters.Center.X, screenParameters.Center.Y + 330), new Point(screenParameters.Center.X, screenParameters.Center.Y - 330));

            graphics.FillEllipse(new SolidBrush(Color.Black), 
                screenParameters.Center.X - 40,
                screenParameters.Center.Y - 40,
                80,
                80);



            graphics.Dispose();
            // update the base image
            _baseImage = i;
        }

        private void DrawScreen(PaintEventArgs e)
        {
            // create a copy of the base image to draw on
            var outputImage = (Image)_baseImage.Clone();
            // create the circular path for clipping the output
            var graphics = Graphics.FromImage(outputImage);

            var path = new GraphicsPath {FillMode = FillMode.Winding};


            graphics.DrawLine(new Pen(Color.WhiteSmoke, 4), new Point(screenParameters.Center.X + 10, screenParameters.Center.Y), new Point(screenParameters.Center.X - 10, screenParameters.Center.Y));
            graphics.DrawLine(new Pen(Color.WhiteSmoke, 4), new Point(screenParameters.Center.X, screenParameters.Center.Y + 10), new Point(screenParameters.Center.X, screenParameters.Center.Y - 10));



            e.Graphics.DrawImage(outputImage, 0, 0);
        }

        Image BackBuffer;
        Image FrontBuffer;

        private void RotateImages()
        {
            lock (this.BackBuffer)
            {
                var temp = this.BackBuffer;
                this.BackBuffer = this.FrontBuffer;
                this.FrontBuffer = temp;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // Important - makes sure the Paint event fires

            DrawScreen(e);

        }


        private void oaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Event_WindowLoad(object sender, EventArgs e)
        {
            refreshScreenTimer = new Timer();
            refreshScreenTimer.Tick += Event_RefreshScreenTimer;
            refreshScreenTimer.Interval = 100;

            screenParameters = new ScreenParameters(Width, Height);

            DrawBaseImage();

            refreshScreenTimer.Enabled = true;
        }



        private void Event_RefreshScreenTimer(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
