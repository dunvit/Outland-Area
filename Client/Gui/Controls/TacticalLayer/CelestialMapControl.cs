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

        private ICelestialObject MouseMoveCelestialObject { get; set; }
        private Point PointInSpace { get; set; }

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

        private bool refreshInProgress = false;

        private void RefreshCelestialMap()
        {
            Logger.Debug("Refresh celestial map event.");

            if (_gameSession == null)
            {
                Initialization();
            }

            if (refreshInProgress) return;

            refreshInProgress = true;

            DrawScreen(_gameSession.Map);

            refreshInProgress = false;
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

            DrawMouseMoveCross(graphics);

            DrawPointInSpaceCross(graphics);

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
                DrawTrajectory(_gameSession, graphics, _screenParameters);
            //}

            // TODO: [T-105] Add/Get player active spaceship to game session
            //var playerShip = _gameSession.GetCelestialObject(5005);

            //var a = new SpaceShipInfo((Spaceship)playerShip);


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

                    DrawTacticalMap.DrawTrajectory(spaceShip, targetObject, graphics, screenParameters);
                }
            }
        }

        private void MapClick(object sender, MouseEventArgs e)
        {
            var mouseScreenCoordinates = Tools.Common.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            var mouseMapCoordinates = Tools.Common.ToTacticalMapCoordinates(mouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            var celestialObjectInRange = SessionTools.GetObjectInRange(_gameSession, 15, new Point(mouseMapCoordinates.X, mouseMapCoordinates.Y));

            PointInSpace = new Point(0, 0);

            if (celestialObjectInRange != null)
            {
                Global.Game.SelectCelestialObject(celestialObjectInRange);
            }
            else
            {
                Global.Game.SelectPointInSpace(mouseMapCoordinates);
                PointInSpace = mouseMapCoordinates;
            }

        }

        private void Event_MapMouseMove(object sender, MouseEventArgs e)
        {
            var mouseScreenCoordinates = Tools.Common.ToRelativeCoordinates(e.Location, _screenParameters.Center);

            var mouseMapCoordinates = Tools.Common.ToTacticalMapCoordinates(mouseScreenCoordinates, _screenParameters.CenterScreenOnMap);

            var celestialObjectInRange = SessionTools.GetObjectInRange(_gameSession, 15, new Point(mouseMapCoordinates.X, mouseMapCoordinates.Y));

            MouseMoveCelestialObject = celestialObjectInRange?.DeepClone();
        }
    }
}
