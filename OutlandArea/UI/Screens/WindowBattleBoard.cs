using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using log4net;
using OutlandArea.BL;
using OutlandArea.BL.Data.Calculation;
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
        private GameSession _gameSession;
        private readonly ScreenParameters _screenParameters;

        private Point MouseScreenCoordinates { get; set; }
        private Point MouseMapCoordinates { get; set; }

        private MapSettings mapSettings = new MapSettings();

        private ICelestialObject _activeCelestialObject;
        private ICelestialObject _selectedCelestialObject;

        public event Action<ICelestialObject> OnMouseMoveCelestialObject;
        public event Action<ICelestialObject> OnMouseLeaveCelestialObject;
        public event Action<ICelestialObject> OnSelectCelestialObject;

        private readonly ILog _log = LogManager.GetLogger(typeof(BattleBoard));

        public WindowBattleBoard()
        {
            InitializeComponent();

            _screenParameters = new ScreenParameters(Width, Height, _centerScreenPosition.X, _centerScreenPosition.Y);
            _gameManager = new GameManager(LogWrite);

            _gameManager.OnMouseLeaveCelestialObject += Event_MouseLeaveCelestialObject;
            _gameManager.OnMouseMoveCelestialObject += Event_MouseMoveCelestialObject;
            _gameManager.OnEndTurn += Event_NewTurnDataRefresh;
            _gameSession = _gameManager.Initialization();

            controlNavigationCommands.OnSelectCommand += Event_SendCommand;
        }

        private void Event_NewTurnDataRefresh(GameSession gameSession)
        {
            _gameSession = gameSession;

            Event_RefreshMap(gameSession);
        }

        private void Event_SendCommand(ICommand obj)
        {
            //_gameManager.Command();
        }

        private delegate void SetGameSessionCallback(GameSession gameSession);

        private void Event_RefreshMap(GameSession gameSession)
        {
            try
            {
                var delegateRefresh_UpdateLastTime = new SetGameSessionCallback(Refresh_UpdateLastTime);
                Invoke(delegateRefresh_UpdateLastTime, gameSession);

                var delegatRefresh_MapInfoStatus = new SetGameSessionCallback(Refresh_MapInfoStatus);
                Invoke(delegatRefresh_MapInfoStatus, gameSession);

            }
            catch (Exception e)
            {
                
            }
            
        }

        private void Refresh_UpdateLastTime(GameSession gameSession)
        {
            txtUpdateLastTime.Text = $@"Turn #{gameSession.Turn} Updated: " +
                                     DateTime.UtcNow.Minute.ToString("D2") + @":" +
                                     DateTime.UtcNow.Second.ToString("D2") + @":" +
                                     DateTime.UtcNow.Millisecond.ToString("D3") + @" ";
        }

        private void Refresh_MapInfoStatus(GameSession gameSession)
        {
            txtMapInfoStatus.Text = _gameSession.Map.IsEnabled ? "active" : "paused";
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

        private void crlRefreshMapTrigger_Tick(object sender, EventArgs e)
        {
            if (DebugTools.IsInDesignMode()) return;

            if (_gameSession == null)
                return;

            // Refresh view by celestial objects map each 1000 milliseconds 
            DrawScreen(_gameSession.Map);
        }

        private delegate void SetTextCallback(string text);

        private void LogWrite(string message)
        {
            if (txtLog.InvokeRequired)
            {
                var d = new SetTextCallback(LogWrite);
                Invoke(d, message);
            }
            else
            {
                txtLog.Text = DateTime.Now.ToString("HH:mm:ss") + @" - " + message + Environment.NewLine + txtLog.Text;

                if (txtLog.Lines.Length > 35)
                {
                    var newLines = new string[35];

                    Array.Copy(txtLog.Lines, 0, newLines, 0, 35);

                    txtLog.Lines = newLines;
                }

                txtLog.Refresh();

                _log.Debug(message);
            }

        }

        // TODO: ReDraw tactical map once for turn
        private int lastRenderedTurn = -1;

        private void DrawScreen(CelestialMap celestialMap)
        {
            //if (celestialMap.Turn == lastRenderedTurn)
            //{
            //    // No need to draw the game board twice.
            //    return;
            //}

            lastRenderedTurn = celestialMap.Turn;

            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            DrawCenterScreenCross(graphics);

            if (mapSettings.IsDrawCelestialObjectDirections)
                DrawTacticalMap.DrawCelestialObjectDirections(celestialMap, graphics, _screenParameters);

            foreach (var celestialObject in celestialMap.CelestialObjects)
            {
                // TODO: Draw Spacecrafts
                /* classification
                    1 - Asteroid
                    2 - Spacecraft
                    3 - Drone
                    4 - Missile
                 */
                //if (celestialObject is BaseSpacecraft)
                //{
                //    DrawSpacecraft(graphics, celestialObject);
                //}

                switch (celestialObject.Classification)
                {
                    case 1:
                        // Regular asteroid
                        DrawTacticalMap.DrawAsteroid(celestialObject, graphics, _screenParameters);
                        break;
                    case 2:
                        // Spaceship

                        //if (mapSettings.IsDrawSpaceshipInformation)
                        //    DrawTacticalMap.DrawSpaceshipInformation(celestialObject, graphics, _screenParameters);

                        //DrawTacticalMap.DrawSpaceship(celestialObject, graphics, _screenParameters);
                        
                        break;
                }
            }

            // TODO: Create configuration for show/hide Mouse Coordinates
            //DrawMouseCoordinates(graphics);

            DrawTacticalMap.DrawActiveCelestialObject(_activeCelestialObject, graphics, _screenParameters);

            if(mapSettings.IsDrawCelestialObjectCoordinates)
                DrawTacticalMap.DrawCelestialObjectCoordinates(celestialMap, graphics, _screenParameters);

            if (_selectedCelestialObject != null)
            {
                DrawTrajectory(celestialMap.GetPlayerSpaceShip(), _selectedCelestialObject, graphics, _screenParameters);
            }

            

            pictureBox1.Image = image;
        }

        readonly ILog _mapCalculationLog = LogManager.GetLogger("MapCalculation");

        private void DrawTrajectory(ICelestialObject spaceShip, ICelestialObject targetObject, Graphics graphics, ScreenParameters screenParameters)
        {
            

            var pointCurrentLocation = new Point(spaceShip.PositionX, spaceShip.PositionY);
            var pointTargetLocation = new Point(targetObject.PositionX, targetObject.PositionY);
            var prevPointCurrentLocation = new Point(spaceShip.PositionX, spaceShip.PositionY);

            var result = Coordinates.GetTrajectoryApproach(pointCurrentLocation, pointTargetLocation, spaceShip.Direction, spaceShip.Speed, 200);

            int temp = 0;
            int iteration = 0;

            var screenCurrentObjectLocation = new Point(0,0);
            var screenPreviousObjectLocation = new Point(0, 0);

            bool isDrawConnectionLine = true;

            var points = new List<Point>(); ;

            foreach (var objectLocation in result)
            {
                screenCurrentObjectLocation = Common.ToScreenCoordinates(screenParameters, objectLocation.Coordinates);

                points.Add(new Point(screenCurrentObjectLocation.X, screenCurrentObjectLocation.Y));
            }

            //var screenTargetLocation = Common.ToScreenCoordinates(screenParameters, pointTargetLocation);

            //graphics.DrawLine(new Pen(Color.DimGray, 1), screenCurrentObjectLocation.X, screenCurrentObjectLocation.Y, screenTargetLocation.X, screenTargetLocation.Y);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // Draw arc to screen.
            graphics.DrawLines(new Pen(Color.FromArgb(18, 18, 18), 4), points.ToArray());
            graphics.DrawLines(new Pen(Color.FromArgb(22, 22, 22), 2), points.ToArray());
            graphics.DrawLines(new Pen(Color.FromArgb(28, 28, 28), 1), points.ToArray());

            foreach (var objectLocation in result)
            {
                iteration++;

                var pen = new Pen(Color.Black, 1);// { StartCap = LineCap.ArrowAnchor };

                screenCurrentObjectLocation = Common.ToScreenCoordinates(screenParameters, objectLocation.Coordinates);
                screenPreviousObjectLocation = Common.ToScreenCoordinates(screenParameters, prevPointCurrentLocation);

                Point[] linePoints =
                {
                    new Point(screenCurrentObjectLocation.X, screenCurrentObjectLocation.Y),
                    new Point(screenPreviousObjectLocation.X, screenPreviousObjectLocation.Y)
                };

                graphics.DrawLines(pen, linePoints);

                prevPointCurrentLocation = new Point(objectLocation.Coordinates.X, objectLocation.Coordinates.Y);

                temp++;
                if (temp == 5)
                {
                    temp = 0;
                    graphics.FillEllipse(new SolidBrush(Color.DarkOliveGreen), screenCurrentObjectLocation.X - 1, screenCurrentObjectLocation.Y - 1, 3, 3);
                }

                if (objectLocation.IsLinearMotion && isDrawConnectionLine)
                {
                    graphics.FillEllipse(new SolidBrush(Color.Yellow), screenCurrentObjectLocation.X - 1, screenCurrentObjectLocation.Y - 1, 3, 3);

                    isDrawConnectionLine = false;
                }

                _mapCalculationLog.Debug($"iteration = {iteration} Coordinates = {objectLocation.Coordinates} IsLinearMotion = {objectLocation.IsLinearMotion} VectorToTarget = {objectLocation.VectorToTarget} Direction = {objectLocation.Direction} Distance = {objectLocation.Distance}");
            }
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

            //txtLog.Text = Environment.NewLine + $"({e.Location.X},{e.Location.Y}) e.Location" +
            //              Environment.NewLine + $"({MouseScreenCoordinates.X},{MouseScreenCoordinates.Y}) MapCoordinates" + 
            //              Environment.NewLine + $"({MouseMapCoordinates.X},{MouseMapCoordinates.Y}) ScreenCoordinates";

            //if (_activeCelestialObject != null)
            //{
            //    txtLog.Text = txtLog.Text + Environment.NewLine + $@"Active object is '{_activeCelestialObject.Name}'";
            //}
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
            else
            {
                _selectedCelestialObject = null;
            }
        }

        private void crlRefreshMousePosition_Tick(object sender, EventArgs e)
        {
            if (_gameSession == null) return;

            CalculateMouseEvents(_gameSession.Map);
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            btnPause.Visible = true;
            btnResume.Visible = false;

            _gameManager.ResumeSession();
        }

        private void Event_MapSettingsChange_SetCoordinatesVisibility(object sender, EventArgs e)
        {
            mapSettings.IsDrawCelestialObjectCoordinates = crlMapSettingsCoordinadesVisibility.Checked;
        }

        private void oaButton1_Click(object sender, EventArgs e)
        {
            btnPause.Visible = false;
            btnResume.Visible = true;

            _gameManager.PauseSession();
        }

        private void oaButton1_Click_1(object sender, EventArgs e)
        {
            Event_RefreshMap(_gameSession);
        }

        private void commandIncreaseSpeed_Click(object sender, EventArgs e)
        {
            _gameManager.Command(_gameSession.Id, 5005, 5005, 1001, 100001, 1);
        }
    }
}
