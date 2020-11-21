using System;
using System.Collections;
using System.Collections.Generic;
using Engine.Configuration;
using Engine.Layers.Tactical;
using Engine.Tools;
using log4net;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Timers;
using System.Windows.Forms;
using Engine.Common.Geometry;
using Engine.Common.Geometry.Trajectory;
using Engine.Gui.Controls.TacticalLayer;
using Engine.ScreenDrawing;
using MicroLibrary;
using OutlandArea.Tools;
using OutlandAreaCommon;
using OutlandAreaCommon.Geometry;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using Timer = System.Timers.Timer;

namespace Engine.Gui.Controls
{
    public partial class TacticalMap : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Point _centerScreenPosition = new Point(10000, 10000);
        private ScreenParameters _screenParameters;
        private GameSession _gameSession;
        private MapSettings mapSettings = new MapSettings();
        private int turn;
        private MicroTimer crlRefreshMap;
        private bool refreshInProgress;
        private int drawInterval = 0;
        private PointF pointInSpace = PointF.Empty;
        private ICelestialObject MouseMoveCelestialObject { get; set; }

        private int turnStep;

        public TacticalMap()
        {
            InitializeComponent();

            if (DebugTools.IsInDesignMode())
                return;

            Global.Game.OnEndTurn += Event_RefreshCelestialMap;

            
        }

        private void Initialization()
        {
            Logger.Info($"[{GetType().Name}]\t Celestial map control - Initialization.");

            _screenParameters = new ScreenParameters(Width, Height, _centerScreenPosition.X, _centerScreenPosition.Y);

            if (DebugTools.IsInDesignMode())
                return;

            crlRefreshMap = new MicroTimer();
            crlRefreshMap.MicroTimerElapsed += Event_Refresh;

            var intervalMilliseconds = 50;

            crlRefreshMap.Interval = 1000 * intervalMilliseconds; // 1000 = 1ms

            crlRefreshMap.Enabled = true;

            drawInterval = 1000 / intervalMilliseconds;
        }

        private void Event_Refresh(object sender, MicroTimerEventArgs timereventargs)
        {
            Logger.Debug($"[{GetType().Name}]\t Refresh celestial map control.");

            if (refreshInProgress) return;

            var timeDrawScreen = Stopwatch.StartNew();

            refreshInProgress = true;

            DrawTacticalMapScreen();

            if (_gameSession.Map.IsEnabled) turnStep++;

            //Logger.Info($"[{GetType().Name}]\t [DrawScreen] Turn {turn}.{turnStep}");

            refreshInProgress = false;

            Logger.Debug($"[{GetType().Name}]\t [DrawScreen] Time {timeDrawScreen.Elapsed.TotalMilliseconds} ms.");
        }

        private void DrawTacticalMapScreen()
        {
            Logger.Debug($"[{GetType().Name}]\t [DrawTacticalMapScreen] Turn {turn}.{turnStep}");

            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            DrawTrajectories(graphics); 

            DrawScreen(graphics);

            BackgroundImage = image;
        }

        private void DrawTrajectories(Graphics graphics)
        {
            if (pointInSpace != PointF.Empty)
            {
                var playerSpaceship = _gameSession.GetPlayerSpaceShip();

                PointF location;

                try
                {
                    location = granularTurnInformation[playerSpaceship.Id].WayPoints[turnStep];
                }
                catch
                {
                    try
                    {
                        location = granularTurnInformation[playerSpaceship.Id].WayPoints[drawInterval - 1];
                    }
                    catch
                    {
                        return;
                    }
                }

                var results = Approach.Calculate(location, pointInSpace, playerSpaceship.Direction);

                var points = new List<PointF>();

                foreach (var position in results)
                {
                    var screenCoordinates = UI.ToScreenCoordinates(_screenParameters, new PointF(position.Coordinates.X, position.Coordinates.Y));

                    points.Add(new PointF(screenCoordinates.X, screenCoordinates.Y));

                }

                var lastPoint = results[results.Count - 1];

                var pointInSpaceCoordinates = UI.ToScreenCoordinates(_screenParameters, new PointF(pointInSpace.X, pointInSpace.Y));

                var step = SpaceMapTools.Move(pointInSpaceCoordinates, 4000, 0, lastPoint.Direction);

                graphics.DrawCurve(new Pen(Color.FromArgb(44, 44, 44)), points.ToArray());

                graphics.DrawLine(new Pen(Color.FromArgb(44, 44, 44)), step.PointFrom, step.PointTo);

                var move = SpaceMapTools.Move(pointInSpaceCoordinates, 0, 0, lastPoint.Direction);
                SpaceMapGraphics.DrawArrow(graphics, move, Color.FromArgb(44, 44, 44), 12);
            }

        }

        private void DrawScreen(Graphics graphics)
        {
            foreach (GranularObjectInformation turnInformation in granularTurnInformation.Values)
            {
                var currentObject = turnInformation.CelestialObject;

                PointF location;

                try
                {
                    location = granularTurnInformation[currentObject.Id].WayPoints[turnStep];
                }
                catch 
                {
                    try
                    {
                        location = granularTurnInformation[currentObject.Id].WayPoints[drawInterval - 1];
                    }
                    catch
                    {
                        continue;
                    }
                }

                var celestialObjectType = (CelestialObjectTypes) currentObject.Classification;

                switch (celestialObjectType)
                {
                    case CelestialObjectTypes.Asteroid:
                        // Regular asteroid
                        DrawTacticalMap.DrawAsteroid(currentObject, location, graphics, _screenParameters);
                        break;
                    case CelestialObjectTypes.SpaceshipPlayer:
                    case CelestialObjectTypes.SpaceshipNpcEnemy:
                    case CelestialObjectTypes.SpaceshipNpcFriend:
                    case CelestialObjectTypes.SpaceshipNpcNeutral:
                        //if (mapSettings.IsDrawSpaceshipInformation)
                        //    DrawTacticalMap.DrawSpaceshipInformation(currentObject, location, graphics, _screenParameters);

                        DrawTacticalMap.DrawSpaceship(currentObject, location, graphics, _screenParameters);

                        break;
                    case CelestialObjectTypes.Missile:
                        //DrawTacticalMap.DrawMissile(currentObject, location, graphics, _screenParameters);
                        break;
                }

                if (mapSettings.IsDrawCelestialObjectDirections)
                {
                    try
                    {
                        DrawTacticalMap.DrawCelestialObjectDirection(currentObject, location, graphics, _screenParameters);
                    }
                    catch (Exception e)
                    {
                        Logger.Error(e.Message);
                    }

                }

                if (mapSettings.IsDrawCelestialObjectCoordinates)
                {
                    if (currentObject.Classification > 0)
                        DrawTacticalMap.DrawCelestialObjectCoordinates(currentObject, graphics, _screenParameters);
                }
            }
        }

        private void MapClick(object sender, MouseEventArgs e)
        {
            Logger.Info($"[{GetType().Name}]\t [MapClick]");

            var mouseScreenCoordinates = OutlandAreaCommon.Tools.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            var mouseMapCoordinates = OutlandAreaCommon.Tools.ToTacticalMapCoordinates(mouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            var celestialObjectInRange = SessionTools.GetObjectInRange(_gameSession, 15, new PointF(mouseMapCoordinates.X, mouseMapCoordinates.Y));

            if (celestialObjectInRange != null)
            {
                Global.Game.SelectCelestialObject(celestialObjectInRange);
            }
            else
            {
                Global.Game.SelectPointInSpace(mouseMapCoordinates);
            }

            pointInSpace = mouseMapCoordinates;
        }

        private void MapMouseMove(object sender, MouseEventArgs e)
        {
            Logger.Debug($"[{GetType().Name}]\t [MapMouseMove]");

            var mouseScreenCoordinates = OutlandAreaCommon.Tools.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            var mouseMapCoordinates = OutlandAreaCommon.Tools.ToTacticalMapCoordinates(mouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            var celestialObjectInRange = SessionTools.GetObjectInRange(_gameSession, 15, new PointF(mouseMapCoordinates.X, mouseMapCoordinates.Y));

            MouseMoveCelestialObject = celestialObjectInRange?.DeepClone();
        }

        private SortedDictionary<int, GranularObjectInformation> granularTurnInformation;

        private void Event_RefreshCelestialMap(GameSession gameSession)
        {
            turn = gameSession.Turn;

            if (crlRefreshMap == null)
            {
                Initialization();
            }

            Logger.Debug($"[{GetType().Name}]\t [Refresh] Turn: {turn}.");

            _gameSession = gameSession;

            turnStep = 0;

            granularTurnInformation = CalculateGranularTurnInformation(_gameSession);
        }

        private SortedDictionary<int, GranularObjectInformation> CalculateGranularTurnInformation(GameSession gameSession)
        {
            var result = new SortedDictionary<int, GranularObjectInformation>();

            foreach (var mapCelestialObject in gameSession.Map.CelestialObjects)
            {
                result.Add(mapCelestialObject.Id, new GranularObjectInformation(mapCelestialObject, drawInterval));
            }

            return result;
        }

        public void CloseTacticalMap()
        {
            // Stop the timer, wait for up to 1 sec for current event to finish,
            //  if it does not finish within this time abort the timer thread
            if (!crlRefreshMap.StopAndWait(1000))
            {
                crlRefreshMap.Abort();
            }
        }
    }
}
