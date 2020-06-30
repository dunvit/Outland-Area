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
        private readonly Pen _radarLinePen = new Pen(Color.FromArgb(100, 130, 90), 1);
        private Turn CurrentTurn { get; set; }

        private Timer _refreshScreenTimer;
        
        private ScreenParameters _screenParameters;

        private Point currentMouseCoordinates;

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
            if (CurrentTurn == null) return;

            DrawScreen();
        }

        private void DrawScreen()
        {
            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            DrawRadarCircle(new Pen(Color.BlanchedAlmond), graphics, 2, _screenParameters.Center);

            DrawRadarCircles(graphics);

            DrawRadarCross(graphics);

            DrawCelestialObjects(graphics);

            DrawMouseCoordinates(graphics);

            pictureBox1.Image = image;
        }

        private void DrawCelestialObjects(Graphics graphics)
        {
            if (CurrentTurn.CelestialObjects == null) return;

            foreach (var celestialObject in CurrentTurn.CelestialObjects)
            {
                var absoluteCoordinates = ToAbsoluteCoordinates(_screenParameters.CenterScreenOnMap, _screenParameters.Center, celestialObject.Location);

                if (celestialObject is BaseSpacecraft)
                {
                    var spaceCraft = celestialObject as BaseSpacecraft;

                    if (spaceCraft.IsPlayerSpacecraft)
                    {
                        graphics.DrawLine(new Pen(Color.CadetBlue, 4), absoluteCoordinates.X, absoluteCoordinates.Y - 8, absoluteCoordinates.X, absoluteCoordinates.Y + 8);
                        graphics.DrawLine(new Pen(Color.CadetBlue, 4), absoluteCoordinates.X - 8, absoluteCoordinates.Y, absoluteCoordinates.X + 8, absoluteCoordinates.Y);

                        continue;
                    }
                }

                var directionCoordinates = MoveCelestialObjects(absoluteCoordinates, 50, celestialObject.Direction);

                float[] dashValues = { 2, 2, 2, 2 };
                Pen blackPen = new Pen(Color.Black, 1);
                blackPen.DashPattern = dashValues;
                graphics.DrawLine(new Pen(Color.Gray, 1), absoluteCoordinates.X - 1, absoluteCoordinates.Y - 1, directionCoordinates.X - 1, directionCoordinates.Y - 1);
                graphics.DrawLine(blackPen, new Point(absoluteCoordinates.X - 1, absoluteCoordinates.Y - 1), new Point(directionCoordinates.X - 1, directionCoordinates.Y - 1));


                graphics.DrawLine(new Pen(Color.Crimson, 4), absoluteCoordinates.X, absoluteCoordinates.Y - 8, absoluteCoordinates.X, absoluteCoordinates.Y + 8);
                graphics.DrawLine(new Pen(Color.Crimson, 4), absoluteCoordinates.X - 8, absoluteCoordinates.Y, absoluteCoordinates.X + 8, absoluteCoordinates.Y);
            }
        }

        #region Draw radar parts

        private void DrawRadarCross(Graphics graphics)
        {
            graphics.DrawLine(_radarLinePen, Width / 2, 20, Width / 2, Height - 20);

            graphics.DrawLine(_radarLinePen, 20, Height / 2, Width - 20, Height / 2);
        }

        private void DrawRadarCircles(Graphics graphics)
        {
            for (var i = 0; i < 6; i++)
            {
                DrawRadarCircle(_radarLinePen, graphics, 50 + i * 100, _screenParameters.Center);
            }
        }

        private void DrawRadarCircle(Pen pen, Graphics graphics, int radius, Point center)
        {
            graphics.DrawEllipse(pen, center.X - radius / 2, center.Y - radius / 2, radius, radius);
        }

        #endregion

        private void DrawMouseCoordinates(Graphics graphics)
        {
            var relativeLocation = ToRelativeCoordinates(currentMouseCoordinates, _screenParameters.CenterScreenOnMap);


            var coordinatesScreen = " Screen (x,y) (" + currentMouseCoordinates.X.ToString("D3") + ":" + currentMouseCoordinates.Y.ToString("D3") + ")";

            using (var font = new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Pixel))
            {
                graphics.DrawString(coordinatesScreen, font, new SolidBrush(Color.BlanchedAlmond), new PointF(_screenParameters.Center.X / 2, 10));
            }

            var coordinatesMap = "Map (x,y) (" + Math.Abs(relativeLocation.X).ToString("D5") + ":" + Math.Abs(relativeLocation.Y).ToString("D5") + ")";

            using (var font = new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Pixel))
            {
                graphics.DrawString(coordinatesMap, font, new SolidBrush(Color.BlanchedAlmond), new PointF(_screenParameters.Center.X / 2, 30));
            }



        }

        private void Event_MouseMove(object sender, MouseEventArgs e)
        {
            currentMouseCoordinates = ToRelativeCoordinates(e.Location, _screenParameters.Center);
        }



        public Point ToAbsoluteCoordinates(Point centerRadarLocation, Point centerPosition, Point celestialObjectPosition)
        {
            var relativeX = (celestialObjectPosition.X - centerRadarLocation.X);
            var relativeY = (celestialObjectPosition.Y - centerRadarLocation.Y);

            return new Point(centerPosition.X + relativeX, centerPosition.Y + relativeY);
        }

        public Point MoveCelestialObjects(Point currentLocation, int speed, int angleInGraduses)
        {
            var angleInRadians = (angleInGraduses - 90) * (Math.PI) / 180;

            var x = (int)(currentLocation.X + speed * Math.Cos(angleInRadians));
            var y = (int)(currentLocation.Y + speed * Math.Sin(angleInRadians));

            return new Point(x, y);
        }

        public static Point ToRelativeCoordinates(Point mouseLocation, Point centerPosition)
        {
            var relativeX = (mouseLocation.X - centerPosition.X);
            var relativeY = (mouseLocation.Y - centerPosition.Y);

            return new Point(relativeX, relativeY);
        }

        
    }
}
