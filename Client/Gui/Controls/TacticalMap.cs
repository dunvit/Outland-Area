﻿using System;
using System.Collections.Generic;
using Engine.Configuration;
using Engine.Tools;
using log4net;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Engine.Gui.Controller;
using Engine.Gui.Controls.TacticalLayer;
using MicroLibrary;
using OutlandAreaCommon;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace Engine.Gui.Controls
{
    public partial class TacticalMap : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Point _centerScreenPosition = new Point(10000, 10000);
        private ScreenParameters _screenParameters;
        private GameSession _gameSession;
        //private MapSettings mapSettings = new MapSettings();
        
        private MicroTimer crlRefreshMap;
        private bool refreshInProgress;

        private PointF pointInSpace = PointF.Empty;
        private ICelestialObject destinationPoint = null;
        private ICelestialObject MouseMoveCelestialObject { get; set; }
        private SortedDictionary<int, GranularObjectInformation> granularTurnInformation;
        private FixedSizedQueue<SortedDictionary<int, GranularObjectInformation>> History;

        private MovementLog HistoryMovementLog = new MovementLog();

        private CelestialObjectTypes _activeModule = CelestialObjectTypes.None;
        private ICelestialObject _activeCelestialObject;

        private int turnStep;

        public event Action<ICelestialObject, ICelestialObject> OnRefreshSelectedCelestialObject;
        public event Action<ICelestialObject> OnAlignToCelestialObject;
        public event Action<ICelestialObject> OnLaunchMissile;

        private PointF mouseCoordinates = PointF.Empty;

        IEnumerable<ICelestialObject> _connectorsShow = new List<ICelestialObject>();
        IEnumerable<ICelestialObject> _connectorsSelect = new List<ICelestialObject>();

        private TacticalMapMode _mode = TacticalMapMode.General;

        public TacticalMap()
        {
            InitializeComponent();

            History = new FixedSizedQueue<SortedDictionary<int, GranularObjectInformation>>(4);

            if (DebugTools.IsInDesignMode())
                return;

            Global.Game.OnEndTurn += CalculateTurnInformation;

            
        }

        private void Initialization()
        {
            Logger.Info(TraceMessage.Execute(this, "Celestial map control - Initialization"));

            _screenParameters = new ScreenParameters(Width, Height, _centerScreenPosition.X, _centerScreenPosition.Y);

            if (DebugTools.IsInDesignMode())
                return;

            crlRefreshMap = new MicroTimer();
            crlRefreshMap.MicroTimerElapsed += Event_Refresh;

            var intervalMilliseconds = 50;

            crlRefreshMap.Interval = 1000 * intervalMilliseconds; // 1000 = 1ms

            crlRefreshMap.Enabled = true;

            _screenParameters.DrawInterval = 1000 / intervalMilliseconds;
        }

        private void Event_Refresh(object sender, MicroTimerEventArgs timereventargs)
        {
            Logger.Debug(TraceMessage.Execute(this, "Refresh celestial map control."));

            if (refreshInProgress) return;

            var timeDrawScreen = Stopwatch.StartNew();

            refreshInProgress = true;

            DrawTacticalMapScreen();

            if (_gameSession.SpaceMap.IsEnabled) turnStep++;

            RefreshSelectedInfoControl(MouseMoveCelestialObject, granularTurnInformation, turnStep);

            refreshInProgress = false;

            Logger.Debug(TraceMessage.Execute(this, $"Time {timeDrawScreen.Elapsed.TotalMilliseconds} ms."));
        }

        private void DrawTacticalMapScreen()
        {
            Logger.Debug(TraceMessage.Execute(this, $"Turn { _gameSession.Turn}.{turnStep}"));

            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            var currentTurnBoardInfo = new BoardInfo
            {
                GraphicSurface = graphics, 
                ScreenInfo = _screenParameters, 
                TurnInfo = granularTurnInformation ,
                TurnStep = turnStep
            };


            DrawMapTools.DrawGrid(currentTurnBoardInfo);

            DrawMapTools.DrawSelectedObject(graphics, _mode, _gameSession , MouseMoveCelestialObject, _connectorsSelect, granularTurnInformation, turnStep, _screenParameters);

            DrawMapTools.DrawConnectors(graphics, _gameSession, _connectorsShow, granularTurnInformation, turnStep, _screenParameters);

            DrawMapTools.DrawConnectors(graphics, _gameSession, _connectorsSelect, granularTurnInformation, turnStep, _screenParameters);

            DrawMapTools.DrawDestinationPoint(graphics, _gameSession, destinationPoint, _screenParameters);

            DrawMapTools.DrawChangeMovementDestination(graphics, _gameSession, pointInSpace, granularTurnInformation, turnStep, _screenParameters);

            DrawMapTools.DrawSpaceShipMovement(graphics, _gameSession, granularTurnInformation, turnStep, HistoryMovementLog, _screenParameters);

            DrawMapTools.DrawMissiles(graphics, _gameSession, granularTurnInformation, turnStep, _screenParameters);

            DrawMapTools.DrawExplosions(graphics, _gameSession, granularTurnInformation, turnStep, _screenParameters);

            DrawMapTools.DrawSpaceShipTrajectories(graphics, _gameSession, granularTurnInformation, _screenParameters);

            DrawMapTools.DrawScreen(graphics, _gameSession, granularTurnInformation, turnStep, _screenParameters);

            DrawMapTools.DrawActiveModule(graphics, _activeModule, mouseCoordinates, _gameSession, granularTurnInformation, turnStep, _screenParameters);
            
            DrawMapTools.DrawMouseMoveObject(graphics, _gameSession, MouseMoveCelestialObject, granularTurnInformation, turnStep, _screenParameters);

            

            BackgroundImage = image;
        }

        private void RefreshSelectedInfoControl(ICelestialObject celestialObject, SortedDictionary<int, GranularObjectInformation> granularObjectInformations, int i)
        {
            if (celestialObject == null)
            {
                OnRefreshSelectedCelestialObject?.Invoke(null, null);

                return;
            }

            var location = DrawMapTools.GetCurrentLocation(granularTurnInformation, celestialObject, turnStep, _screenParameters.DrawInterval);

            var selectedCelestialObject = celestialObject.DeepClone();

            selectedCelestialObject.PositionX = location.X;
            selectedCelestialObject.PositionY = location.Y;

            OnRefreshSelectedCelestialObject?.Invoke(selectedCelestialObject, _gameSession.GetPlayerSpaceShip());
        }

        private void MapClick(object sender, MouseEventArgs e)
        {
            var mouseScreenCoordinates = OutlandAreaCommon.Tools.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            var mouseMapCoordinates = OutlandAreaCommon.Tools.ToTacticalMapCoordinates(mouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            var celestialObjectInRange = SessionTools.GetObjectInRange(_gameSession, 15, new PointF(mouseMapCoordinates.X, mouseMapCoordinates.Y));


            switch (_activeModule)
            {
                case CelestialObjectTypes.PointInMap:
                    break;
                case CelestialObjectTypes.Missile:
                    if (e.Button == MouseButtons.Right)
                    {
                        _activeModule = CelestialObjectTypes.None;
                        return;
                    }

                    if (e.Button == MouseButtons.Left)
                    {
                        _activeCelestialObject.PositionX = mouseMapCoordinates.X;
                        _activeCelestialObject.PositionY = mouseMapCoordinates.Y;

                        _activeModule = CelestialObjectTypes.None;

                        OnLaunchMissile?.Invoke(_activeCelestialObject);
                        return;
                    }

                    break;
                case CelestialObjectTypes.SpaceshipPlayer:
                    break;
                case CelestialObjectTypes.SpaceshipNpcNeutral:
                    break;
                case CelestialObjectTypes.SpaceshipNpcEnemy:
                    break;
                case CelestialObjectTypes.SpaceshipNpcFriend:
                    break;
                case CelestialObjectTypes.Asteroid:
                    break;
                case CelestialObjectTypes.None:
                    _connectorsShow = new List<ICelestialObject>();
                    break;
            }



            Logger.Info(TraceMessage.Execute(this, $"MapClick"));

            //if (e.Button == MouseButtons.Right)
            //{
            //    AlignToCommand(null, e);
            //    return;
            //}


            if (celestialObjectInRange != null)
            {
                Global.Game.SelectCelestialObject(celestialObjectInRange);
            }
            else
            {
                // Movement by mouse click
                //Global.Game.SelectPointInSpace(mouseMapCoordinates);
            }

            //pointInSpace = mouseMapCoordinates;
        }

        private void MapMouseMove(object sender, MouseEventArgs e)
        {
            Logger.Debug(TraceMessage.Execute(this, $"MapMouseMove]"));

            mouseCoordinates = e.Location;

            var mouseCoordinatesInternal = OutlandAreaCommon.Tools.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            var mouseMapCoordinates = OutlandAreaCommon.Tools.ToTacticalMapCoordinates(mouseCoordinatesInternal, _screenParameters.CenterScreenOnMap);

            var celestialObjectInRange = SessionTools.GetObjectInRange(_gameSession, 15, new PointF(mouseMapCoordinates.X, mouseMapCoordinates.Y));

            MouseMoveCelestialObject = celestialObjectInRange?.DeepClone();
        }

        private void CalculateTurnInformation(GameSession gameSession)
        {
            if (crlRefreshMap == null)
            {
                Initialization();
            }

            Logger.Debug(TraceMessage.Execute(this, $"Turn: {gameSession.Turn}."));

            HistoryMovementLog.Update(_gameSession);

            _gameSession = gameSession;

            turnStep = 0;

            granularTurnInformation = CalculateGranularTurnInformation(_gameSession);

            

            var timeDrawScreen = Stopwatch.StartNew();

            History.Enqueue(granularTurnInformation.DeepClone());

            Logger.Debug(TraceMessage.Execute(this, $"Time {timeDrawScreen.Elapsed.TotalMilliseconds} ms."));
        }

        private SortedDictionary<int, GranularObjectInformation> CalculateGranularTurnInformation(GameSession gameSession)
        {
            var result = new SortedDictionary<int, GranularObjectInformation>();

            foreach (var mapCelestialObject in gameSession.SpaceMap.CelestialObjects)
            {
                if(mapCelestialObject.Classification < 1) continue;

                try
                {
                    result.Add(mapCelestialObject.Id, new GranularObjectInformation(mapCelestialObject, _screenParameters.DrawInterval));
                }
                catch
                {
                    // ignored
                }
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

        public void ExecuteModule(IModule module, ICelestialObject celestialObject)
        {
            _activeCelestialObject = celestialObject;
            _activeModule = (CelestialObjectTypes) celestialObject.Classification;
        }

        public void Connectors(GameSession gameSession, IModule module,IEnumerable<ICelestialObject> objects, bool show)
        {
            _connectorsShow = objects;
            //_connectorsSelect = new List<ICelestialObject>();
            _mode = TacticalMapMode.ShowObjects;
        }

        public void ExecuteModuleForSelectSelectObject(IModule module, Func<GameSession, List<ICelestialObject>> objectsInMap)
        {
            _mode = TacticalMapMode.SelectObjects;

            _connectorsSelect = objectsInMap(_gameSession);
            //_connectorsShow = new List<ICelestialObject>();

            _mode = TacticalMapMode.SelectObjects;
        }
    }
}
