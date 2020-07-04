using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using OutlandArea.TacticalBattleLayer;
using OutlandArea.Tools;

namespace OutlandArea.UI.Screens.BattleBoardControls
{
    public partial class TacticalMap : UserControl
    {
        public event Action<ICelestialObject> OnMouseMoveCelestialObject;
        public event Action<ICelestialObject> OnMouseLeaveCelestialObject;

        private readonly Pen _radarLinePenSecond = new Pen(Color.FromArgb(45, 45, 45), 1);
        private readonly Pen _radarLinePen = new Pen(Color.FromArgb(30, 30, 30), 1);
        private Turn CurrentTurn { get; set; }

        private Timer _refreshScreenTimer;
        
        private ScreenParameters _screenParameters;

        private ICelestialObject _selectedCelestialObject = null;

        private Point currentMouseCoordinates;
        private Point MouseMapCoordinates { get; set; }

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

            if (DebugTools.IsInDesignMode()) return;

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

            DrawSelectedCelestialObjectConnector(graphics);

            DrawCelestialObjects(graphics);

            DrawMouseCoordinates(graphics);

            

            pictureBox1.Image = image;
        }

        private void DrawSelectedCelestialObjectConnector(Graphics graphics)
        {
            var i = 0;

            foreach (var celestialObject in CurrentTurn.CelestialObjects)
            {
                var absoluteCoordinates = ToAbsoluteCoordinates(_screenParameters.CenterScreenOnMap, _screenParameters.Center, celestialObject.Location);

                if (celestialObject is BaseSpacecraft)
                {
                    i++;

                    var coordinatesMap = " (" + Math.Abs(celestialObject.Location.X).ToString("D5") + ":" + Math.Abs(celestialObject.Location.Y).ToString("D5") + ") " + celestialObject.Name + "";

                    using (var font = new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Pixel))
                    {
                        graphics.DrawString(coordinatesMap, font, new SolidBrush(Color.DimGray), new PointF(_screenParameters.Center.X / 2, i * 30 + 90));
                    }

                    if (celestialObject.Location.X < MouseMapCoordinates.X + 15 &&
                        celestialObject.Location.X > MouseMapCoordinates.X - 15 &&
                        celestialObject.Location.Y < MouseMapCoordinates.Y + 15 &&
                        celestialObject.Location.Y > MouseMapCoordinates.Y - 15)
                    {
                        if (_selectedCelestialObject == null || ( _selectedCelestialObject.Id != celestialObject.Id))
                        {
                            _selectedCelestialObject = celestialObject;

                            OnMouseMoveCelestialObject?.Invoke(celestialObject);
                        }

                        graphics.DrawLine(new Pen(Color.Bisque, 1), absoluteCoordinates.X, absoluteCoordinates.Y, _screenParameters.Center.X, _screenParameters.Center.Y);

                        graphics.FillEllipse(new SolidBrush(Color.Black), absoluteCoordinates.X - 21, absoluteCoordinates.Y - 21, 42, 42);

                        graphics.DrawEllipse(new Pen(Color.LightGray, 1), absoluteCoordinates.X - 21, absoluteCoordinates.Y - 21, 42, 42);
                    }
                    else
                    {
                        if (_selectedCelestialObject != null && _selectedCelestialObject.Id == celestialObject.Id)
                        {
                            OnMouseLeaveCelestialObject?.Invoke(null);
                            _selectedCelestialObject = null;
                        }
                    }
                }
            }
        }

        private void DrawCelestialObjects(Graphics graphics)
        {
            if (CurrentTurn.CelestialObjects == null) return;

            foreach (var celestialObject in CurrentTurn.CelestialObjects)
            {
                if (celestialObject is BaseSpacecraft)
                {
                    DrawSpacecraft(graphics, celestialObject);
                }
            }
        }

        private void DrawSpacecraft(Graphics graphics, ICelestialObject celestialObject)
        {
            //TODO: Create colors ENUM by relation ships color
            //TODO: Add previous spacecraft movement steps
            var spaceCraft = celestialObject as BaseSpacecraft;

            var absoluteCoordinates = ToAbsoluteCoordinates(_screenParameters.CenterScreenOnMap, _screenParameters.Center, celestialObject.Location);

            float[] dashValues = { 2, 2, 2, 2 };
            var blackPen = new Pen(Color.Black, 1) {DashPattern = dashValues};

            var mainColor = Color.DarkRed;
            var mainIcon = "EnemySpaceship";

            if (spaceCraft != null && spaceCraft.IsPlayerSpacecraft)
            {
                mainColor = Color.DarkOliveGreen;
                mainIcon = "PlayerSpaceship";
            }

            var directionCoordinates = MoveCelestialObjects(absoluteCoordinates, 50, celestialObject.Direction);

            graphics.DrawLine(new Pen(Color.DimGray, 1), absoluteCoordinates.X, absoluteCoordinates.Y, directionCoordinates.X, directionCoordinates.Y);
            graphics.DrawLine(blackPen, new Point(absoluteCoordinates.X, absoluteCoordinates.Y), new Point(directionCoordinates.X, directionCoordinates.Y));

            graphics.FillEllipse(new SolidBrush(Color.DimGray), directionCoordinates.X - 2, directionCoordinates.Y - 2, 4, 4);

            var target = LoadImage(mainIcon);

            var bmpSpacecraft = RotateImage(target, celestialObject.Direction);

            graphics.DrawImage(bmpSpacecraft, new PointF(absoluteCoordinates.X - 15, absoluteCoordinates.Y - 15));

            graphics.FillEllipse(new SolidBrush(mainColor), new Rectangle(absoluteCoordinates.X - 1, absoluteCoordinates.Y - 1, 2, 2));

        }

        #region Draw radar parts

        private void DrawRadarCross(Graphics graphics)
        {
            graphics.DrawLine(_radarLinePen, Width / 2, 20, Width / 2, Height - 20);

            graphics.DrawLine(_radarLinePen, 20, Height / 2, Width - 20, Height / 2);

            graphics.FillEllipse(new SolidBrush(Color.Black),
                _screenParameters.Center.X - 40,
                _screenParameters.Center.Y - 40,
                80,
                80);
        }

        private void DrawRadarCircles(Graphics graphics)
        {
            for (var i = 0; i < 5; i++)
            {
                var colorCircle = _radarLinePen;
                if (IsEven(i))
                {
                    colorCircle = _radarLinePenSecond;
                }

                DrawRadarCircle(colorCircle, graphics, 50 + i * 200, _screenParameters.Center);
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


            var coordinatesScreen = "(" + currentMouseCoordinates.X.ToString("D3") + ":" + currentMouseCoordinates.Y.ToString("D3") + ") - Screen";

            using (var font = new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Pixel))
            {
                graphics.DrawString(coordinatesScreen, font, new SolidBrush(Color.BlanchedAlmond), new PointF(_screenParameters.Center.X / 2, 10));
            }

            var coordinatesMap = "(" + Math.Abs(MouseMapCoordinates.X).ToString("D5") + ":" + Math.Abs(MouseMapCoordinates.Y).ToString("D5") + ") - Map";

            using (var font = new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Pixel))
            {
                graphics.DrawString(coordinatesMap, font, new SolidBrush(Color.BlanchedAlmond), new PointF(_screenParameters.Center.X / 2, 30));
            }

        }

        private void Event_MouseMove(object sender, MouseEventArgs e)
        {
            currentMouseCoordinates = ToRelativeCoordinates(e.Location, _screenParameters.Center);

            //var relativeX = (currentMouseCoordinates.X + _screenParameters.CenterScreenOnMap.X);
            //var relativeY = (currentMouseCoordinates.Y + _screenParameters.CenterScreenOnMap.Y);

            //MouseMapCoordinates = new Point(relativeX, relativeY);

            MouseMapCoordinates =
                ToTacticalMapCoordinates(currentMouseCoordinates, _screenParameters.CenterScreenOnMap);
        }

        public Point ToTacticalMapCoordinates(Point currentMouseCoordinates, Point centerPosition)
        {
            var relativeX = (centerPosition.X + currentMouseCoordinates.X);
            var relativeY = (centerPosition.Y + currentMouseCoordinates.Y);

            return new Point(relativeX, relativeY);
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

        public Point ToRelativeCoordinates(Point mouseLocation, Point centerPosition)
        {
            var relativeX = (mouseLocation.X - centerPosition.X);
            var relativeY = (mouseLocation.Y - centerPosition.Y);

            return new Point(relativeX, relativeY);
        }

        public static Bitmap LoadImage(string file)
        {
            var patternsFolder = Path.Combine(Environment.CurrentDirectory, "Images", "Ships");

            var fileFullName = Path.Combine(patternsFolder, file + ".png");

            if (File.Exists(fileFullName))
            {
                var orig = new Bitmap(fileFullName);
                var clone = new Bitmap(orig.Width, orig.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                using (var gr = Graphics.FromImage(clone))
                {
                    gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
                }

                return clone;
            }

            return null;
        }

        private bool IsEven(int a)
        {
            return (a % 2) == 0;
        }

        public Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }
    }
}
