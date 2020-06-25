using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.Tools;

namespace Engine.UserControls
{
    public sealed partial class BattleMapControl : UserControl
    {
        private Timer refreshScreenTimer;

        private ScreenParameters screenParameters;

        Image _baseImage;

        public BattleMapControl()
        {
            InitializeComponent();

            //DrawBaseImage();

            //Refresh();
        }

        private void DrawBaseImage()
        {
            if (Common.IsApplicationModeRuntime() == false) return;

            Image image = new Bitmap(Width, Height);
            var graphics = Graphics.FromImage(image);
            var pen = new Pen(Color.FromArgb(0, 19, 0));

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            for (int i = 1; i < 5; i++)
            {
                graphics.DrawEllipse(new Pen(Color.DimGray, 1),
                    screenParameters.Center.X - i * 100 - 25,
                    screenParameters.Center.Y - i * 100 - 25,
                    i * 200 + 50,
                    i * 200 + 50);
            }

            

            //graphics.DrawEllipse(new Pen(Color.DimGray, 1),
            //    screenParameters.Center.X - 200,
            //    screenParameters.Center.Y - 200,
            //    400,
            //    400);

            //graphics.DrawEllipse(new Pen(Color.DarkGray, 1),
            //    screenParameters.Center.X - 300,
            //    screenParameters.Center.Y - 300,
            //    600,
            //    600);

            graphics.DrawLine(new Pen(Color.DimGray, 1), new Point(screenParameters.Center.X + 450, screenParameters.Center.Y), new Point(screenParameters.Center.X - 450, screenParameters.Center.Y));
            graphics.DrawLine(new Pen(Color.DimGray, 1), new Point(screenParameters.Center.X, screenParameters.Center.Y + 450), new Point(screenParameters.Center.X, screenParameters.Center.Y - 450));

            graphics.FillEllipse(new SolidBrush(Color.Black),
                screenParameters.Center.X - 40,
                screenParameters.Center.Y - 40,
                80,
                80);

            graphics.DrawEllipse(new Pen(Color.DimGray, 1),
                screenParameters.Center.X - 50,
                screenParameters.Center.Y - 50,
                100,
                100);

            graphics.Dispose();
            // update the base image
            _baseImage = image;
        }

        private void DrawScreen(PaintEventArgs e)
        {
            if (Common.IsApplicationModeRuntime() == false) return;

            // create a copy of the base image to draw on
            var outputImage = (Image)_baseImage.Clone();
            // create the circular path for clipping the output
            var graphics = Graphics.FromImage(outputImage);

            var path = new GraphicsPath { FillMode = FillMode.Winding };


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

        private void Event_Load(object sender, EventArgs e)
        {
            if (Common.IsApplicationModeRuntime() == false) return;

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
