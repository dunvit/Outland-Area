using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Engine.Configuration;
using Engine.Layers.Tactical;
using Engine.Layers.Tactical.Objects.Spaceships;
using Engine.Management.Server.DataProcessing;
using Engine.Tools;
using log4net;
using OutlandArea.Tools;

namespace Engine.Gui.Controls.TacticalLayer
{
    public partial class CelestialMapControl : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // TODO: [T-102] Calculate center screen position on first End Turn Event (Board initialization)
        private readonly Point _centerScreenPosition = new Point(10000, 10000);
        // TODO: [T-103] Save/Load map settings from configuration file
        private MapSettings mapSettings = new MapSettings();
        private ScreenParameters _screenParameters;
        private GameSession _gameSession;
        //private ICelestialObject _activeCelestialObject;
        //private ICelestialObject _selectedCelestialObject;

        // TODO: [T-106] Add event Mouse move to celestial object
        // TODO: [T-107] Add event Mouse click to celestial object
        // TODO: [T-108] Add event Mouse click on empty space(Remove selection)

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

            Scheduler.Instance.ScheduleTask(100, 100, RefreshCelestialMap, null);
        }

        private void Event_RefreshCelestialMap(GameSession gameSession)
        {
            if (_gameSession == null)
            {
                Initialization();
            }

            _gameSession = gameSession;
        }

        private void RefreshCelestialMap()
        {
            Logger.Debug("Refresh celestial map event.");

            if (_gameSession == null)
            {
                Initialization();
            }

            DrawScreen(_gameSession.Map);
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

            if (mapSettings.IsDrawCelestialObjectDirections)
                DrawTacticalMap.DrawCelestialObjectDirections(celestialMap, graphics, _screenParameters);

            foreach (var celestialObject in celestialMap.CelestialObjects)
            {
                
                /* classification
                    1 - Asteroid
                    2 - Spacecraft
                    3 - Drone
                    4 - Missile
                 */

                switch (celestialObject.Classification)
                {
                    case 1:
                        // Regular asteroid
                        DrawTacticalMap.DrawAsteroid(celestialObject, graphics, _screenParameters);
                        break;
                    case 2:
                        // TODO: [T-104] Draw Spacecrafts
                        // Spaceship

                        //if (mapSettings.IsDrawSpaceshipInformation)
                        //    DrawTacticalMap.DrawSpaceshipInformation(celestialObject, graphics, _screenParameters);

                        //DrawTacticalMap.DrawSpaceship(celestialObject, graphics, _screenParameters);

                        break;
                }
            }

            // TODO: [T-101] Create configuration for show/hide Mouse Coordinates
            //DrawMouseCoordinates(graphics);

            // TODO: [T-100] Draw selected celestial object
            //DrawTacticalMap.DrawActiveCelestialObject(_activeCelestialObject, graphics, _screenParameters);

            if (mapSettings.IsDrawCelestialObjectCoordinates)
                DrawTacticalMap.DrawCelestialObjectCoordinates(celestialMap, graphics, _screenParameters);

            //if (_selectedCelestialObject != null)
            //{
            //    DrawTrajectory(celestialMap.GetPlayerSpaceShip(), _selectedCelestialObject, graphics, _screenParameters);
            //}

            // TODO: [T-105] Add/Get player active spaceship to game session
            var playerShip = SessionTools.GetCelestialObject(5005, _gameSession);

            var a = new SpaceShipInfo((Spaceship)playerShip);


            BackgroundImage = image;
        }

        private void DrawCenterScreenCross(Graphics graphics)
        {
            var radarLinePen = new Pen(Color.FromArgb(30, 30, 30), 1);

            graphics.DrawLine(radarLinePen, _screenParameters.Center.X - 45, _screenParameters.Center.Y, _screenParameters.Center.X + 45, _screenParameters.Center.Y);

            graphics.DrawLine(radarLinePen, _screenParameters.Center.X, _screenParameters.Center.Y - 45, _screenParameters.Center.X, _screenParameters.Center.Y + 45);

            graphics.FillEllipse(new SolidBrush(Color.Black), _screenParameters.Center.X - 10, _screenParameters.Center.Y - 10, 20, 20);
        }

        private void DrawTrajectory(ICelestialObject spaceShip, ICelestialObject targetObject, Graphics graphics, ScreenParameters screenParameters)
        {


            var pointCurrentLocation = new Point(spaceShip.PositionX, spaceShip.PositionY);
            var pointTargetLocation = new Point(targetObject.PositionX, targetObject.PositionY);
            var prevPointCurrentLocation = new Point(spaceShip.PositionX, spaceShip.PositionY);

            var result = Coordinates.GetTrajectoryApproach(pointCurrentLocation, pointTargetLocation, spaceShip.Direction, spaceShip.Speed, 200);

            int temp = 0;
            int iteration = 0;

            var screenCurrentObjectLocation = new Point(0, 0);
            var screenPreviousObjectLocation = new Point(0, 0);

            bool isDrawConnectionLine = true;

            var points = new List<Point>(); ;

            foreach (var objectLocation in result)
            {
                screenCurrentObjectLocation = UI.ToScreenCoordinates(screenParameters, objectLocation.Coordinates);

                points.Add(new Point(screenCurrentObjectLocation.X, screenCurrentObjectLocation.Y));
            }


            if (points.Count < 2)
                return;
            //var screenTargetLocation = UI.ToScreenCoordinates(screenParameters, pointTargetLocation);

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

                screenCurrentObjectLocation = UI.ToScreenCoordinates(screenParameters, objectLocation.Coordinates);
                screenPreviousObjectLocation = UI.ToScreenCoordinates(screenParameters, prevPointCurrentLocation);

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

                //Logger.Debug($"iteration = {iteration} Coordinates = {objectLocation.Coordinates} IsLinearMotion = {objectLocation.IsLinearMotion} VectorToTarget = {objectLocation.VectorToTarget} Direction = {objectLocation.Direction} Distance = {objectLocation.Distance}");
            }
        }

        private void MapClick(object sender, MouseEventArgs e)
        {
            var mouseScreenCoordinates = Tools.Common.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            var mouseMapCoordinates = Tools.Common.ToTacticalMapCoordinates(mouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            var celestialObjectInRange = SessionTools.GetObjectInRange(_gameSession, 15, new Point(mouseMapCoordinates.X, mouseMapCoordinates.Y));

            if (celestialObjectInRange != null)
            {
                Global.Game.SelectCelestialObject(celestialObjectInRange);
            }

        }
    }
}
