using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using Engine.Common.Geometry;
using Engine.Common.Geometry.Trajectory;
using Engine.Configuration;
using Engine.ScreenDrawing;
using log4net;
using OutlandArea.Tools;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaCommon.Universe.Objects.Spaceships;
using ObjectLocation = Engine.Common.Geometry.ObjectLocation;

namespace Engine.Gui.Controls.TacticalLayer
{
    public class DrawMapTools
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void DrawSpaceShipTrajectories(Graphics graphics, GameSession gameSession, SortedDictionary<int, GranularObjectInformation> turnMapInformation, ScreenParameters screenParameters)
        {
            var playerSpaceship = gameSession.GetPlayerSpaceShip();

            var commands = gameSession.GetSpaceShipCommands(playerSpaceship.Id);

            foreach (var command in commands)
            {
                switch (command.Type)
                {
                    case CommandTypes.MoveForward:
                        break;
                    case CommandTypes.Fire:
                        break;
                    case CommandTypes.AlignTo:
                        var target = gameSession.GetCelestialObject(command.TargetCelestialObjectId).GetLocation();
                        var results = Approach.Calculate(playerSpaceship.GetLocation(), target, playerSpaceship.Direction, playerSpaceship.Speed);

                        DrawCurveTrajectory(graphics, results.Trajectory, Color.FromArgb(45, 100, 145), screenParameters);

                        break;
                    case CommandTypes.Orbit:
                        break;

                }
            }

        }

        public static void DrawDestinationPoint(Graphics graphics, GameSession gameSession, ICelestialObject point, ScreenParameters screenParameters)
        {
            if (point == null) return;

            var playerSpaceship = gameSession.GetPlayerSpaceShip();

            DrawTacticalMap.DrawPointInSpace(point, playerSpaceship, graphics, screenParameters);
        }

        public static void DrawChangeMovementDestination(Graphics graphics, GameSession gameSession, PointF pointInSpace, SortedDictionary<int, GranularObjectInformation> turnMapInformation, int turnStep, ScreenParameters screenParameters)
        {
            if (pointInSpace != PointF.Empty)
            {
                var playerSpaceship = gameSession.GetPlayerSpaceShip();

                var location = GetCurrentLocation(turnMapInformation, playerSpaceship, turnStep, screenParameters.DrawInterval);

                var results = Approach.Calculate(location, pointInSpace, playerSpaceship.Direction, playerSpaceship.Speed);

                if (results.IsCorrect)
                    DrawCurveTrajectory(graphics, results.Trajectory, Color.FromArgb(44, 44, 44), screenParameters, true);
            }

        }

        public static void DrawSpaceShipMovement(Graphics graphics, GameSession gameSession, SortedDictionary<int, GranularObjectInformation> turnMapInformation, int turnStep, FixedSizedQueue<SortedDictionary<int, GranularObjectInformation>> history, ScreenParameters screenParameters)
        {
            var playerSpaceship = gameSession.GetPlayerSpaceShip();

            #region Direction forward
            foreach (var turnInformation in turnMapInformation.Values)
            {
                if (playerSpaceship.Id == turnInformation.CelestialObject.Id) continue;

                if (gameSession.GetCelestialObject(turnInformation.CelestialObject.Id).IsSpaceship() == false) return;

                var currentObject = turnInformation.CelestialObject;

                var location = GetCurrentLocation(turnMapInformation, currentObject, turnStep, screenParameters.DrawInterval).ToScreen(screenParameters);

                var step = SpaceMapTools.Move(location, 4000, 0, currentObject.Direction);

                graphics.DrawLine(new Pen(Color.FromArgb(24, 24, 24)), step.PointFrom, step.PointTo);

            }
            #endregion

            #region Direction back
            foreach (var turnInformation in turnMapInformation.Values)
            {
                if (turnInformation.CelestialObject.IsSpaceship() == false) continue;

                var currentObject = turnInformation.CelestialObject;

                var points = new List<PointF>();

                var data = history.GetData();
                var turnId = 0;

                foreach (var turnData in data)
                {
                    var stepId = 0;

                    foreach (var wayPoint in turnData[currentObject.Id].WayPoints.Values)
                    {
                        if (turnId > 0 || stepId > turnStep)
                            points.Add(wayPoint.ToScreen(screenParameters));

                        stepId++;
                    }

                    turnId++;
                }

                if (points.Count > 2)
                {
                    graphics.DrawCurve(new Pen(Color.FromArgb(200, 44, 44)) { DashStyle = DashStyle.Dash }, points.ToArray());
                }
            }
            #endregion
        }

        public static void DrawMissiles(Graphics graphics, GameSession gameSession, SortedDictionary<int, GranularObjectInformation> turnMapInformation, int turnStep, ScreenParameters screenParameters)
        {
            foreach (GranularObjectInformation turnInformation in turnMapInformation.Values)
            {
                var currentObject = turnInformation.CelestialObject;

                var location = GetCurrentLocation(turnMapInformation, currentObject, turnStep, screenParameters.DrawInterval);

                if((CelestialObjectTypes)currentObject.Classification != CelestialObjectTypes.Missile) continue;

                var a = "Missile";

                var b = gameSession.GetSpaceShipCommands(currentObject.Id);

                foreach (var command in b)
                {
                    if (command.Type == CommandTypes.Fire)
                    {
                        var targetPoint = gameSession.GetCelestialObject(command.TargetCelestialObjectId);
                    }
                }

            }
        }

        public static void DrawExplosions(Graphics graphics, GameSession gameSession, SortedDictionary<int, GranularObjectInformation> turnMapInformation, int turnStep, ScreenParameters screenParameters)
        {
            foreach (GranularObjectInformation turnInformation in turnMapInformation.Values)
            {
                var currentObject = turnInformation.CelestialObject;

                

                if ((CelestialObjectTypes)currentObject.Classification != CelestialObjectTypes.Explosion) continue;

                var explosion = (Explosion) currentObject;

                var screenCoordinates = UI.ToScreenCoordinates(screenParameters, explosion.GetLocation());

                graphics.FillEllipse(new SolidBrush(Color.IndianRed),
                    screenCoordinates.X - explosion.Radius,
                    screenCoordinates.Y - explosion.Radius,
                    explosion.Radius * 2,
                    explosion.Radius * 2
                    );

                graphics.DrawEllipse(new Pen(Color.Red, 1),
                    screenCoordinates.X - explosion.Radius,
                    screenCoordinates.Y - explosion.Radius,
                    explosion.Radius * 2,
                    explosion.Radius * 2
                );

                // Explosive epicenter
                graphics.FillEllipse(new SolidBrush(Color.Red),
                    screenCoordinates.X - 2,
                    screenCoordinates.Y - 2,
                    4,
                    4
                );

            }
        }

        public static void DrawScreen(Graphics graphics, GameSession gameSession, SortedDictionary<int, GranularObjectInformation> turnMapInformation, int turnStep, ScreenParameters screenParameters)
        {
            foreach (GranularObjectInformation turnInformation in turnMapInformation.Values)
            {
                var currentObject = turnInformation.CelestialObject;

                var location = GetCurrentLocation(turnMapInformation, currentObject, turnStep, screenParameters.DrawInterval);

                var celestialObjectType = (CelestialObjectTypes)currentObject.Classification;

                switch (celestialObjectType)
                {
                    case CelestialObjectTypes.Asteroid:
                        // Regular asteroid
                        DrawTacticalMap.DrawAsteroid(currentObject, location, graphics, screenParameters);
                        break;
                    case CelestialObjectTypes.SpaceshipPlayer:
                    case CelestialObjectTypes.SpaceshipNpcEnemy:
                    case CelestialObjectTypes.SpaceshipNpcFriend:
                    case CelestialObjectTypes.SpaceshipNpcNeutral:
                        //if (mapSettings.IsDrawSpaceshipInformation)
                        //    DrawTacticalMap.DrawSpaceshipInformation(currentObject, location, graphics, _screenParameters);

                        DrawTacticalMap.DrawSpaceship(currentObject, location, graphics, screenParameters);

                        break;
                    case CelestialObjectTypes.Missile:
                        DrawTacticalMap.DrawMissile(currentObject, location, graphics, screenParameters);
                        break;
                }

                if (screenParameters.Settings.IsDrawCelestialObjectDirections)
                {
                    try
                    {
                        DrawTacticalMap.DrawCelestialObjectDirection(currentObject, location, graphics, screenParameters);
                    }
                    catch (Exception e)
                    {
                        Logger.Error(e.Message);
                    }

                }

                if (screenParameters.Settings.IsDrawCelestialObjectCoordinates)
                {
                    if (currentObject.Classification > 0)
                        DrawTacticalMap.DrawCelestialObjectCoordinates(currentObject, graphics, screenParameters);
                }
            }
        }

        //------------------------------------------------------------------------------------

        private static void DrawCurveTrajectory(Graphics graphics, List<ObjectLocation> results, Color color, ScreenParameters screenParameters, bool isDrawArrow = false)
        {
            var points = new List<PointF>();

            foreach (var position in results)
            {
                var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(position.Coordinates.X, position.Coordinates.Y));

                points.Add(new PointF(screenCoordinates.X, screenCoordinates.Y));

            }

            var lastPoint = results[results.Count - 1];

            var pointInSpaceCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(lastPoint.Coordinates.X, lastPoint.Coordinates.Y));

            var step = SpaceMapTools.Move(pointInSpaceCoordinates, 4000, 0, lastPoint.Direction);

            if (points.Count > 2)
                graphics.DrawCurve(new Pen(color), points.ToArray());

            graphics.DrawLine(new Pen(color), step.PointFrom, step.PointTo);

            var move = SpaceMapTools.Move(pointInSpaceCoordinates, 0, 0, lastPoint.Direction);
            SpaceMapGraphics.DrawArrow(graphics, move, color, 12);

            #region Show linear movement 
            //foreach (var position in results)
            //{
            //    var screenCoordinates = UI.ToScreenCoordinates(_screenParameters, new PointF(position.Coordinates.X, position.Coordinates.Y));

            //    if (position.Status == MovementType.Linear)
            //    {
            //        graphics.DrawEllipse(new Pen(Color.Brown, 1), screenCoordinates.X, screenCoordinates.Y, 2, 2 );
            //    }
            //}
            #endregion
        }

        public static PointF GetCurrentLocation(SortedDictionary<int, GranularObjectInformation> granularTurnInformation, ICelestialObject celestialObject, int turnStep, int drawInterval)
        {
            try
            {
                return granularTurnInformation[celestialObject.Id].WayPoints[turnStep];
            }
            catch
            {
                try
                {
                    try
                    {
                        return granularTurnInformation[celestialObject.Id].WayPoints[drawInterval - 1];
                    }
                    catch
                    {
                        try
                        {
                            return granularTurnInformation[celestialObject.Id].WayPoints[drawInterval - 2];
                        }
                        catch 
                        {
                            return granularTurnInformation[celestialObject.Id].WayPoints[drawInterval - 3];
                        }
                    }
                }
                catch
                {
                    return PointF.Empty;
                }
            }
        }

        public static void DrawActiveModule(Graphics graphics, CelestialObjectTypes activeModule, PointF mousePosition, GameSession gameSession, SortedDictionary<int, GranularObjectInformation> granularTurnInformation, int turnStep, ScreenParameters screenParameters)
        {
            var playerSpaceship = gameSession.GetPlayerSpaceShip();

            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(playerSpaceship.PositionX, playerSpaceship.PositionY));

            var mouseCoordinatesInternal = OutlandAreaCommon.Tools.ToRelativeCoordinates(mousePosition, screenParameters.Center);

            var mouseMapCoordinates = OutlandAreaCommon.Tools.ToTacticalMapCoordinates(mouseCoordinatesInternal, screenParameters.CenterScreenOnMap);

            

            switch (activeModule)
            {
                case CelestialObjectTypes.PointInMap:
                    break;
                case CelestialObjectTypes.Missile:
                    var radarLinePen = new Pen(Color.FromArgb(60, 60, 60), 1);
                    graphics.DrawLine(radarLinePen, screenCoordinates.X, screenCoordinates.Y, mousePosition.X, mousePosition.Y);
                    
                    var missile = new Missile
                    {
                        PositionY = mouseMapCoordinates.Y,
                        PositionX = mouseMapCoordinates.X
                    };
                    DrawTacticalMap.DrawPreTarget(missile, graphics, screenParameters);


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
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        public static void DrawMouseMoveObject(Graphics graphics, GameSession gameSession, ICelestialObject celestialObject, SortedDictionary<int, GranularObjectInformation> granularTurnInformation, int turnStep, ScreenParameters screenParameters)
        {
            if (celestialObject == null) return;

            var location = GetCurrentLocation(granularTurnInformation, celestialObject, turnStep, screenParameters.DrawInterval);

            var screenCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(location.X, location.Y));

            var rectangle = new RectangleF(screenCoordinates.X + 30, screenCoordinates.Y + 30, 100, 40);

            graphics.FillRectangle(new SolidBrush(Color.DimGray), rectangle);
            graphics.DrawRectangle(new Pen(Color.Gray), rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            graphics.DrawRectangle(new Pen(Color.Black), rectangle.X+1, rectangle.Y+1, rectangle.Width-2, rectangle.Height-2);
            graphics.DrawLine(new Pen(Color.Gray), rectangle.X, rectangle.Y, screenCoordinates.X, screenCoordinates.Y);
        }

        public static void DrawConnectors(Graphics graphics, GameSession gameSession, IEnumerable<ICelestialObject> connectors, SortedDictionary<int, GranularObjectInformation> granularTurnInformation, int turnStep, ScreenParameters screenParameters)
        {
            if (connectors == null || !connectors.Any()) return;

            var playerSpaceship = gameSession.GetPlayerSpaceShip();

            var connectorPen = new Pen(Color.DimGray);

            //var objectsInScreenArea = connectors.Where(o => 
            //    o.PositionX > screenParameters.CenterScreenOnMap.X - screenParameters.Width / 2 &&
            //    o.PositionX < screenParameters.CenterScreenOnMap.X + screenParameters.Width / 2 &&
            //    o.PositionY > screenParameters.CenterScreenOnMap.Y - screenParameters.Height / 2 &&
            //    o.PositionY < screenParameters.CenterScreenOnMap.Y + screenParameters.Height / 2);

            var objectsInScreenArea = connectors.Where(o => screenParameters.PointInVisibleScreen(o.PositionX, o.PositionY));

            foreach (var celestialObject in objectsInScreenArea)
            {
                var objectLocation = GetCurrentLocation(granularTurnInformation, celestialObject, turnStep, screenParameters.DrawInterval);
                var shipLocation = GetCurrentLocation(granularTurnInformation, playerSpaceship, turnStep, screenParameters.DrawInterval);


                var directionFromShipToTarget = Coordinates.GetRotation(objectLocation, shipLocation);
                var directionFromTargetToShip = Coordinates.GetRotation(shipLocation, objectLocation);

                var shipLocationStep = SpaceMapTools.Move(shipLocation, 12, 0, directionFromShipToTarget);
                var targetLocationStep = SpaceMapTools.Move(objectLocation, 20, 0, directionFromTargetToShip);

                var shipScreenCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(shipLocationStep.PointTo.X, shipLocationStep.PointTo.Y));

                var objectScreenCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(targetLocationStep.PointTo.X, targetLocationStep.PointTo.Y));

                var targetScreenCoordinates = UI.ToScreenCoordinates(screenParameters, new PointF(objectLocation.X, objectLocation.Y));
                                                                                    
                graphics.DrawLine(connectorPen, shipScreenCoordinates.X, shipScreenCoordinates.Y,
                    objectScreenCoordinates.X, objectScreenCoordinates.Y);

                graphics.DrawEllipse(connectorPen, targetScreenCoordinates.X - 20, targetScreenCoordinates.Y - 20, 40, 40);

            }
        }
    }
}
