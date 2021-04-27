﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Engine.Configuration;
using Engine.UI.DrawEngine;
using Engine.UI.Model;
using EngineCore.DataProcessing;
using EngineCore.Geometry;
using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Objects;
using log4net;

namespace Engine.UI.Controls
{
    public partial class TacticalMap : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        private readonly Point _centerScreenPosition = new Point(10000, 10000);
        private ScreenParameters _screenParameters;
        private GameSession _gameSession;
        private bool _refreshInProgress;
        private Hashtable _history = new Hashtable();

        public TacticalMap()
        {
            InitializeComponent();

            if (Global.Game is null) return;

            Global.Game.OnEndTurn += Event_EndTurn;
            Global.Game.OnStartGameSession += Event_StartGameSession;
        }

        private void Event_StartGameSession(GameSession gameSession)
        {
            _gameSession = gameSession.DeepClone();

            Logger.Info($"[TacticalMap] Start game session for id '{_gameSession.Id}'.");

            RefreshControl();
        }


        private void Event_EndTurn(GameSession gameSession)
        {
            _gameSession = gameSession.DeepClone();

            UpdateTrajectoryHistory(_gameSession);

            Logger.Info($"[TacticalMap] Refresh space map for turn '{_gameSession.Turn}'.");

            RefreshControl();
        }

        private void UpdateTrajectoryHistory(GameSession gameSession)
        {
            var settings = new TurnSettings();

            foreach (var currentObject in gameSession.SpaceMap.CelestialObjects)
            {
                if (_history.ContainsKey(currentObject.Id))
                {
                    var queueHistoryPoints = (FixedSizedQueue<PointF>)_history[currentObject.Id];
                    queueHistoryPoints.Enqueue(currentObject.GetLocation());
                    _history[currentObject.Id] = queueHistoryPoints;
                }
                else
                {
                    var celestialObjectTrajectoryHistory = new FixedSizedQueue<PointF>(settings.UnitsPerSecond * settings.HistoryPeriodInSeconds);

                    var reverseDirection = (currentObject.Direction - 180).To360Degrees();

                    var speedInTick = currentObject.Speed / settings.UnitsPerSecond;

                    var previousPosition = currentObject.GetLocation();

                    var positionsReverse = new List<PointF>();

                    for (int i = 0; i < settings.UnitsPerSecond * settings.HistoryPeriodInSeconds; i++)
                    {
                        var position = SpaceMapTools.Move(
                            previousPosition,
                            speedInTick,
                            reverseDirection
                            ).PointTo;

                        previousPosition = new PointF(position.X, position.Y);

                        positionsReverse.Add(position);
                    }

                    for (var i = positionsReverse.Count - 1; i > 0; i--)
                    {
                        celestialObjectTrajectoryHistory.Enqueue(positionsReverse[i]);
                    }

                    _history.Add(currentObject.Id, celestialObjectTrajectoryHistory);
                }
            }
        }

        private void RefreshControl()
        {
            if (_refreshInProgress) return;

            var timeDrawScreen = Stopwatch.StartNew();

            _refreshInProgress = true;

            //UpdateTrajectoryHistory(_gameSession);

            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            _screenParameters =
                new ScreenParameters(Width, Height, _centerScreenPosition.X, _centerScreenPosition.Y)
                {
                    GraphicSurface = graphics
                };

            DrawTacticalMapScreen(_screenParameters, _gameSession);

            BackgroundImage = image; 

            _refreshInProgress = false;

            Logger.Info($"[TacticalMap] Refresh space map for turn '{_gameSession.Turn}' was finished successful. Time {timeDrawScreen.Elapsed.TotalMilliseconds} ms.");
        }



        private void DrawTacticalMapScreen(IScreenInfo screenParameters, GameSession gameSession)
        {
            // TODO: - Draw back ground only once
            DrawTacticalMap.DrawBackGround(screenParameters);

            DrawTacticalMap.DrawGrid(screenParameters);

            DrawTacticalMap.DrawCelestialObjects(screenParameters, gameSession);

            DrawTacticalMap.DrawDirections(screenParameters, gameSession);

            DrawTacticalMap.DrawHistoryTrajectory(screenParameters, gameSession, _history);
        }
    }
}