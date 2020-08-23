using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using OutlandArea.Map;
using OutlandArea.TacticalBattleLayer;
using OutlandArea.Tools;
using ICelestialObject = OutlandArea.Map.ICelestialObject;

namespace OutlandArea.UI.Screens
{
    public partial class WindowBattleBoard : Form
    {
        private readonly Point _centerScreenPosition = new Point(10000, 10000);
        private readonly GameManager _gameManager;
        private CelestialMap _celestialMap;
        private readonly ScreenParameters _screenParameters;
        private Point MouseScreenCoordinates { get; set; }
        private Point MouseMapCoordinates { get; set; }
        private ICelestialObject _activeCelestialObject;
        private ICelestialObject _selectedCelestialObject;

        public event Action<ICelestialObject> OnMouseMoveCelestialObject;
        public event Action<ICelestialObject> OnMouseLeaveCelestialObject;
        public event Action<ICelestialObject> OnSelectCelestialObject;

        public WindowBattleBoard(GameManager manager)
        {
            InitializeComponent();

            _screenParameters = new ScreenParameters(Width, Height, _centerScreenPosition.X, _centerScreenPosition.Y);
            _gameManager = manager;

            manager.OnMouseLeaveCelestialObject += Event_MouseLeaveCelestialObject;
            manager.OnMouseMoveCelestialObject += Event_MouseMoveCelestialObject;
        }

        private void Event_MouseMoveCelestialObject(ICelestialObject obj)
        {
            crlPanelCelestialObjectInfo.ShowCelestialObjectInfo(obj);
        }

        private void Event_MouseLeaveCelestialObject(ICelestialObject obj)
        {
            crlPanelCelestialObjectInfo.ClearCelestialObjectInfo();
        }

        private void WindowBattleBoard_Load(object sender, EventArgs e)
        {
            crlRefreshMapTrigger.Enabled = true;
        }

        private void commandApplicationExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private ICelestialObject tempCelestialObject;

        private void crlRefreshMapTrigger_Tick(object sender, EventArgs e)
        {
            if (_celestialMap != null)
            {
                if (tempCelestialObject == null)
                {
                    tempCelestialObject = new Asteroid{Name = "MORE", PositionX = 10000, PositionY = 10000, Classification = 1};
                }
                else
                {
                    tempCelestialObject.PositionX = tempCelestialObject.PositionX - 5;
                    tempCelestialObject.PositionY = tempCelestialObject.PositionY - 5;
                }

                _celestialMap.UpdateCelestialObjects(tempCelestialObject);
                // Only for debug in static map.
                DrawScreen(_celestialMap);
                return;
            }

            _celestialMap = _gameManager.RefreshCelestialMap();

            if (DebugTools.IsInDesignMode()) return;

            

            // Refresh view by celestial objects map each 1000 milliseconds 
            DrawScreen(_celestialMap);
        }

        private void DrawScreen(CelestialMap celestialMap)
        {
            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            DrawCenterScreenCross(graphics);

            foreach (var celestialObject in celestialMap.CelestialObjects)
            {
                // TODO: Draw Spacecrafts
                //if (celestialObject is BaseSpacecraft)
                //{
                //    DrawSpacecraft(graphics, celestialObject);
                //}
                if (celestialObject.Classification == 1)
                {
                    DrawAsteroid(celestialObject, graphics);
                }
            }

            // TODO: Create configuration for show/hide Mouse Coordinates
            //DrawMouseCoordinates(graphics);

            DrawActiveCelestialObject(_activeCelestialObject, graphics);

            DrawCelestialObjectCoordinates(celestialMap, graphics);

            pictureBox1.Image = image;
        }

        private void DrawCelestialObjectCoordinates(CelestialMap celestialMap, Graphics graphics)
        {
            foreach (var celestialObject in celestialMap.CelestialObjects)
            {
                var screenCoordinates = Common.ToScreenCoordinates(_screenParameters, 
                    new Point(celestialObject.PositionX - 25, celestialObject.PositionY + 5));

                using (var font = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel))
                {
                    graphics.DrawString($"({celestialObject.PositionX} : {celestialObject.PositionY})", font, new SolidBrush(Color.DimGray), new PointF(screenCoordinates.X - 15, screenCoordinates.Y));
                }

            }
        }

        private void DrawActiveCelestialObject(ICelestialObject celestialObject, Graphics graphics)
        {
            if (_activeCelestialObject == null) return;

            var screenCoordinates = Common.ToScreenCoordinates(_screenParameters, new Point(celestialObject.PositionX, celestialObject.PositionY));

            graphics.FillEllipse(new SolidBrush(Color.WhiteSmoke), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);

            graphics.FillEllipse(new SolidBrush(Color.WhiteSmoke), screenCoordinates.X - 5, screenCoordinates.Y - 5, 10, 10);

        }



        private void CalculateMouseEvents(CelestialMap celestialMap)
        {
            // Types of mouse position
            // 1. Out of all objects
            // 2. In active object
            // 3. In new object

            ICelestialObject objectInRange = null; 

            foreach (var celestialObject in celestialMap.CelestialObjects)
            {
                if(IsObjectInRange(celestialObject, 15, new Point(MouseMapCoordinates.X, MouseMapCoordinates.Y)))
                {
                    objectInRange = celestialObject;
                }
            }

            // Case 1. Out of all objects signatures in map
            if (objectInRange == null)
            {
                if (_activeCelestialObject != null)
                {
                    textBox1.Text = DateTime.UtcNow.Minute.ToString("D2") + @":" +
                                    DateTime.UtcNow.Second.ToString("D2") + @":" +
                                    DateTime.UtcNow.Millisecond.ToString("D2") + @":" +
                                    $@"MouseLeave {_activeCelestialObject.Name}" + Environment.NewLine + textBox1.Text;
                    OnMouseLeaveCelestialObject?.Invoke(null);
                    _gameManager.MouseLeaveCelestialObject(null);
                    _activeCelestialObject = null;
                }

                return;
            }

            // Case 3. In new object. Previous object not selected.
            if (_activeCelestialObject == null)
            {
                textBox1.Text = DateTime.UtcNow.Minute.ToString("D2") + @":" +
                                DateTime.UtcNow.Second.ToString("D2") + @":" +
                                DateTime.UtcNow.Millisecond.ToString("D2") + @":" +
                                $@"MouseMove {objectInRange.Name}" + Environment.NewLine + textBox1.Text;

                OnMouseMoveCelestialObject?.Invoke(objectInRange);
                _gameManager.MouseMoveCelestialObject(objectInRange);

                _activeCelestialObject = objectInRange;
            }

            // Case 3. In new object
            if (_activeCelestialObject == null || objectInRange.Name != _activeCelestialObject.Name)
            {
                textBox1.Text = DateTime.UtcNow.Minute.ToString("D2") + @":" +
                                DateTime.UtcNow.Second.ToString("D2") + @":" +
                                DateTime.UtcNow.Millisecond.ToString("D2") + @":" +
                                $@"MouseMove {_activeCelestialObject.Name}" + Environment.NewLine + textBox1.Text;
                    
                OnMouseMoveCelestialObject?.Invoke(objectInRange);
                _gameManager.MouseMoveCelestialObject(objectInRange);

                _activeCelestialObject = objectInRange;
            }

            // Case 2. In active object
        }

        private static bool IsObjectInRange(ICelestialObject celestialObject, int distance, Point point)
        {
            var w = Math.Abs(celestialObject.PositionX - point.X);
            var h = Math.Abs(celestialObject.PositionY - point.Y);

            return w < distance && h < distance;
        }

        private void DrawAsteroid(ICelestialObject celestialObject, Graphics graphics)
        {
            // Convert celestial object coordinates to screen coordinates
            var screenCoordinates = Common.ToScreenCoordinates(_screenParameters, new Point(celestialObject.PositionX, celestialObject.PositionY));

            graphics.FillEllipse(new SolidBrush(Color.WhiteSmoke), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);
        }

        private void DrawCenterScreenCross(Graphics graphics)
        {
            var _radarLinePen = new Pen(Color.FromArgb(30, 30, 30), 1);

            graphics.DrawLine(_radarLinePen, _screenParameters.Center.X - 45, _screenParameters.Center.Y, _screenParameters.Center.X + 45, _screenParameters.Center.Y);

            graphics.DrawLine(_radarLinePen, _screenParameters.Center.X, _screenParameters.Center.Y - 45, _screenParameters.Center.X, _screenParameters.Center.Y + 45);

            graphics.FillEllipse(new SolidBrush(Color.Black), _screenParameters.Center.X - 10, _screenParameters.Center.Y - 10, 20, 20);
        }

        private void Event_MapMouseMove(object sender, MouseEventArgs e)
        {
            MouseScreenCoordinates = Common.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            MouseMapCoordinates = Common.ToTacticalMapCoordinates(MouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            txtLog.Text = Environment.NewLine + $"({e.Location.X},{e.Location.Y}) e.Location" +
                          Environment.NewLine + $"({MouseScreenCoordinates.X},{MouseScreenCoordinates.Y}) MapCoordinates" + 
                          Environment.NewLine + $"({MouseMapCoordinates.X},{MouseMapCoordinates.Y}) ScreenCoordinates";

            if (_activeCelestialObject != null)
            {
                txtLog.Text = txtLog.Text + Environment.NewLine + $@"Active object is '{_activeCelestialObject.Name}'";
            }
        }

        private void DrawMouseCoordinates(Graphics graphics)
        {
            var coordinatesScreen = "(" + MouseScreenCoordinates.X.ToString("D3") + ":" + MouseScreenCoordinates.Y.ToString("D3") + ") - Screen";

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

        private void Event_MapMouseClick(object sender, MouseEventArgs e)
        {
            MouseScreenCoordinates = Common.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            MouseMapCoordinates = Common.ToTacticalMapCoordinates(MouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            if(_activeCelestialObject != null && 
               IsObjectInRange(_activeCelestialObject, 15, new Point(MouseMapCoordinates.X, MouseMapCoordinates.Y)))
            {
                _selectedCelestialObject = _activeCelestialObject;

                textBox1.Text = DateTime.UtcNow.Minute.ToString("D2") + @":" +
                                DateTime.UtcNow.Second.ToString("D2") + @":" +
                                DateTime.UtcNow.Millisecond.ToString("D2") + @":" +
                                $"MouseLeave {_selectedCelestialObject.Name}" + Environment.NewLine + textBox1.Text;

                OnSelectCelestialObject?.Invoke(_selectedCelestialObject);
                _gameManager.SelectCelestialObject(_selectedCelestialObject);
            }
        }

        private void crlRefreshMousePosition_Tick(object sender, EventArgs e)
        {
            if (_celestialMap == null) return;

            CalculateMouseEvents(_celestialMap);
        }
    }
}
