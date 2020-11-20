using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Timers;
using System.Windows.Forms;
using Engine.Configuration;
using Engine.Layers.Tactical;
using Engine.Tools;
using log4net;
using OutlandArea.Tools;
using OutlandAreaCommon;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using Timer = System.Timers.Timer;

namespace Engine.Gui.Controls.TacticalLayer
{
    public partial class CelestialMapControl : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Point _centerScreenPosition = new Point(10000, 10000);
        private MapSettings mapSettings = new MapSettings();
        private ScreenParameters _screenParameters;
        private GameSession _gameSession;
        private int turn;
        private Timer crlRefreshMap;

        private ICelestialObject MouseMoveCelestialObject { get; set; }

        private Hashtable DrawTurns { get;} = new Hashtable();

        public CelestialMapControl()
        {
            InitializeComponent();

            if (DebugTools.IsInDesignMode())
                return;

            Global.Game.OnEndTurn += Event_RefreshCelestialMap;
        }

        private void Initialization()
        {
            Logger.Info("Celestial map control - Initialization.");

            _screenParameters = new ScreenParameters(Width, Height, _centerScreenPosition.X, _centerScreenPosition.Y);

            if (DebugTools.IsInDesignMode())
                return;

            crlRefreshMap = new Timer();
            crlRefreshMap.Elapsed += Event_Refresh;
            crlRefreshMap.Interval = 100;
            crlRefreshMap.Enabled = true;
        }

        private void Event_Refresh(object sender, ElapsedEventArgs e)
        {
            Logger.Debug("Refresh celestial map control.");


            if (refreshInProgress) return;

            if (DrawTurns.ContainsKey(turn) == false) return;

            var timeDrawScreen = Stopwatch.StartNew();

            refreshInProgress = true;

            DrawScreen();

            refreshInProgress = false;

            Logger.Debug($"[DrawScreen] Time {timeDrawScreen.Elapsed.TotalMilliseconds} ms.");
        }

        private GameSession previousGameSession;

        private void Event_RefreshCelestialMap(GameSession gameSession)
        {
            turn = gameSession.Turn;
            Logger.Info("[TurnChange]" + turn);

            if (_gameSession == null)
            {
                Initialization();
                previousGameSession = gameSession;
            }
            else
            {
                previousGameSession = _gameSession;
            }

            _gameSession = gameSession;

            if (DrawTurns.ContainsKey(_gameSession.Turn) == false)
            {
                var turnDrawMapData = new DrawMapData(previousGameSession, _gameSession);

                DrawTurns.Add(_gameSession.Turn, turnDrawMapData);
            }

            turnCurrentStep = 0;
        }

        

        private bool refreshInProgress;



        private int turnAllSteps = 11;
        private int turnCurrentStep = 0;

        private void DrawScreen()
        {
            var drawTurn = turn;

            var currentTurnCelestialMapData = DrawTurns[turn] as DrawMapData;

            if (currentTurnCelestialMapData == null) return;

            var stopwatch1 = Stopwatch.StartNew();

            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            if (_gameSession.Map.IsEnabled)
            {
                turnCurrentStep++;
                if (turnCurrentStep > turnAllSteps)
                    turnCurrentStep = turnAllSteps;
            }

            DrawCenterScreenCross(graphics);

            DrawMouseMoveCross(graphics);

            DrawPointInSpaceCross(graphics);

            DrawTrajectory(_gameSession, graphics, _screenParameters);

            foreach (DrawMapDataObject dataObject in currentTurnCelestialMapData.GetData().Values)
            {
                if (drawTurn != turn) return;

                var currentObject = dataObject.GetCelestialObject(turn, turnCurrentStep);

                /* classification
                    1 - Asteroid
                    200 - Spacecraft
                    3 - Drone
                    4 - Missile
                 */

                switch ((CelestialObjectTypes)currentObject.Classification)
                {
                    case CelestialObjectTypes.Asteroid:
                        // Regular asteroid
                        DrawTacticalMap.DrawAsteroid(currentObject, currentObject.GetLocation(), graphics, _screenParameters);
                        break;
                    case CelestialObjectTypes.SpaceshipPlayer:
                        if (mapSettings.IsDrawSpaceshipInformation)
                            DrawTacticalMap.DrawSpaceshipInformation(currentObject, graphics, _screenParameters);

                        DrawTacticalMap.DrawSpaceship(currentObject, new PointF(currentObject.PositionX, currentObject.PositionY),  graphics, _screenParameters);

                        break;
                    case CelestialObjectTypes.Missile:
                        DrawTacticalMap.DrawMissile(currentObject, graphics, _screenParameters);
                        break;
                }

                if (mapSettings.IsDrawCelestialObjectDirections)
                {
                    try
                    {
                        DrawTacticalMap.DrawCelestialObjectDirection(currentObject, currentObject.GetLocation(), graphics, _screenParameters);
                    }
                    catch (Exception e)
                    {
                        Logger.Error(e.Message);
                    }

                }

                if (mapSettings.IsDrawCelestialObjectCoordinates)
                {
                    if(currentObject.Classification > 0)
                        DrawTacticalMap.DrawCelestialObjectCoordinates(currentObject, graphics, _screenParameters);
                }
            }

            stopwatch1.Stop();

            var workTime = stopwatch1.Elapsed.TotalMilliseconds;

            var logInformation = $"[WeyPoints] Turn = {_gameSession.Turn}.{turnCurrentStep} workTime = {workTime} ms";
            Logger.Debug(logInformation);

            using (var font = new Font("Times New Roman", 10, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                graphics.DrawString(logInformation, font, new SolidBrush(Color.WhiteSmoke), new PointF(0, 0));
            }

            BackgroundImage = image;

            
        }

        private void DrawPointInSpaceCross(Graphics graphics)
        {
            if (_gameSession.SelectedObject == null) return;

            var playerShip = _gameSession.GetPlayerSpaceShip();

            DrawTacticalMap.DrawPointInSpace(_gameSession.SelectedObject, playerShip, graphics, _screenParameters);
        }

        private void DrawMouseMoveCross(Graphics graphics)
        {
            if (MouseMoveCelestialObject == null) return;

            DrawTacticalMap.DrawPreTarget(MouseMoveCelestialObject, graphics, _screenParameters);
        }

        private void DrawCenterScreenCross(Graphics graphics)
        {
            var radarLinePen = new Pen(Color.FromArgb(30, 30, 30), 1);

            graphics.DrawLine(radarLinePen, _screenParameters.Center.X - 45, _screenParameters.Center.Y, _screenParameters.Center.X + 45, _screenParameters.Center.Y);

            graphics.DrawLine(radarLinePen, _screenParameters.Center.X, _screenParameters.Center.Y - 45, _screenParameters.Center.X, _screenParameters.Center.Y + 45);

            graphics.FillEllipse(new SolidBrush(Color.Black), _screenParameters.Center.X - 10, _screenParameters.Center.Y - 10, 20, 20);
        }

        private void DrawTrajectory(GameSession gameSession, Graphics graphics, ScreenParameters screenParameters)
        {
            var spaceShip = gameSession.GetPlayerSpaceShip();

            foreach (var command in gameSession.Commands)
            {
                if (command.CelestialObjectId == spaceShip.Id)
                {
                    var targetObject = gameSession.GetCelestialObject(command.TargetCelestialObjectId);

                    DrawTacticalMap.DrawTrajectory(gameSession, spaceShip, targetObject, graphics, screenParameters);
                }
            }
        }

        private void MapClick(object sender, MouseEventArgs e)
        {
            var mouseScreenCoordinates = OutlandAreaCommon.Tools.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            var mouseMapCoordinates = OutlandAreaCommon.Tools.ToTacticalMapCoordinates(mouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            var celestialObjectInRange = SessionTools.GetObjectInRange(_gameSession, 15, new PointF(mouseMapCoordinates.X, mouseMapCoordinates.Y));

            //PointInSpace = new Point(0, 0);

            if (celestialObjectInRange != null)
            {
                Global.Game.SelectCelestialObject(celestialObjectInRange);
            }
            else
            {
                Global.Game.SelectPointInSpace(mouseMapCoordinates);
                //PointInSpace = mouseMapCoordinates;
            }

        }

        private void Event_MapMouseMove(object sender, MouseEventArgs e)
        {
            var mouseScreenCoordinates = OutlandAreaCommon.Tools.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            var mouseMapCoordinates = OutlandAreaCommon.Tools.ToTacticalMapCoordinates(mouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            var celestialObjectInRange = SessionTools.GetObjectInRange(_gameSession, 15, new PointF(mouseMapCoordinates.X, mouseMapCoordinates.Y));

            MouseMoveCelestialObject = celestialObjectInRange?.DeepClone();
        }
    }
}
