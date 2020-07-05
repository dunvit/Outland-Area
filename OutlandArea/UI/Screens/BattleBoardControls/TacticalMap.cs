using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
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

        private Point circlesCenter;

        private Point currentMouseCoordinates;
        private Point MouseMapCoordinates { get; set; }

        private bool isCenterOnPlayerShip = false;

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

            if (turn.Number == 1)
            {
                circlesCenter = _screenParameters.Center;
            }
            else
            {
                var coordinates = turn.GetPlayerSpacecraftLocation();

                if (isCenterOnPlayerShip)
                {
                    _screenParameters.CenterScreenOnMap = coordinates;
                }
                else
                {
                    circlesCenter = Common.ToAbsoluteCoordinates(_screenParameters.CenterScreenOnMap, _screenParameters.Center, coordinates);
                }

            }
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

            DrawRadarElements(graphics, circlesCenter);

            DrawSelectedCelestialObjectConnector(graphics, circlesCenter);

            DrawCelestialObjects(graphics);

            DrawMouseCoordinates(graphics);

            pictureBox1.Image = image;
        }

        private void DrawRadarElements(Graphics graphics, Point center)
        {
            DrawRadarCircle(new Pen(Color.BlanchedAlmond), graphics, 2, circlesCenter);

            DrawRadarCircles(graphics, circlesCenter);

            DrawRadarCross(graphics, circlesCenter);
        }

        private void DrawSelectedCelestialObjectConnector(Graphics graphics, Point center)
        {
            var i = 0;

            foreach (var celestialObject in CurrentTurn.CelestialObjects)
            {
                var absoluteCoordinates = Common.ToAbsoluteCoordinates(_screenParameters.CenterScreenOnMap, center, celestialObject.Location);

                if (celestialObject is BaseSpacecraft)
                {
                    i++;

                    var coordinatesMap = " (" + Math.Abs(celestialObject.Location.X).ToString("D5") + ":" + Math.Abs(celestialObject.Location.Y).ToString("D5") + ") " + celestialObject.Name + "";

                    using (var font = new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Pixel))
                    {
                        graphics.DrawString(coordinatesMap, font, new SolidBrush(Color.DimGray), new PointF(center.X / 2, i * 30 + 90));
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

                        graphics.DrawLine(new Pen(Color.Bisque, 1), absoluteCoordinates.X, absoluteCoordinates.Y, center.X, center.Y);

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

            var absoluteCoordinates = Common.ToAbsoluteCoordinates(_screenParameters.CenterScreenOnMap, _screenParameters.Center, celestialObject.Location);

            float[] dashValues = { 2, 2, 2, 2 };
            var blackPen = new Pen(Color.Black, 1) {DashPattern = dashValues};

            var mainColor = Color.DarkRed;
            var mainIcon = "EnemySpaceship";

            if (spaceCraft != null && spaceCraft.IsPlayerSpacecraft)
            {
                mainColor = Color.DarkOliveGreen;
                mainIcon = "PlayerSpaceship";
            }

            var directionCoordinates = Common.MoveCelestialObjects(absoluteCoordinates, 50, celestialObject.Direction);

            graphics.DrawLine(new Pen(Color.DimGray, 1), absoluteCoordinates.X, absoluteCoordinates.Y, directionCoordinates.X, directionCoordinates.Y);
            graphics.DrawLine(blackPen, new Point(absoluteCoordinates.X, absoluteCoordinates.Y), new Point(directionCoordinates.X, directionCoordinates.Y));

            graphics.FillEllipse(new SolidBrush(Color.DimGray), directionCoordinates.X - 2, directionCoordinates.Y - 2, 4, 4);

            var target = Tools.UI.LoadImage(mainIcon);

            var bmpSpacecraft = Tools.UI.RotateImage(target, celestialObject.Direction);

            graphics.DrawImage(bmpSpacecraft, new PointF(absoluteCoordinates.X - 15, absoluteCoordinates.Y - 15));

            graphics.FillEllipse(new SolidBrush(mainColor), new Rectangle(absoluteCoordinates.X - 1, absoluteCoordinates.Y - 1, 2, 2));

        }

        #region Draw radar parts

        private void DrawRadarCross(Graphics graphics, Point center)
        {
            graphics.DrawLine(_radarLinePen, center.X - 450, center.Y, center.X + 450, center.Y);

            graphics.DrawLine(_radarLinePen, center.X , center.Y - 450, center.X, center.Y + 450);

            graphics.FillEllipse(new SolidBrush(Color.Black), center.X - 40, center.Y - 40, 80, 80);
        }

        private void DrawRadarCircles(Graphics graphics, Point center)
        {
            for (var i = 0; i < 5; i++)
            {
                var colorCircle = _radarLinePen;
                if (Common.IsEven(i))
                {
                    colorCircle = _radarLinePenSecond;
                }

                DrawRadarCircle(colorCircle, graphics, 50 + i * 200, center);
            }
        }

        private void DrawRadarCircle(Pen pen, Graphics graphics, int radius, Point center)
        {
            graphics.DrawEllipse(pen, center.X - radius / 2, center.Y - radius / 2, radius, radius);
        }

        #endregion

        private void DrawMouseCoordinates(Graphics graphics)
        {
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
            currentMouseCoordinates = Common.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            MouseMapCoordinates = Common.ToTacticalMapCoordinates(currentMouseCoordinates, _screenParameters.CenterScreenOnMap);
        }


        

        

        

        

        
    }
}
