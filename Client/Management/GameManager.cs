using System;
using System.Diagnostics;
using System.Drawing;
using Engine.Gui;
using Engine.Layers.Tactical;
using Engine.Layers.Tactical.Objects;
using Engine.Layers.Tactical.Objects.Spaceships;
using Engine.Management.Server;
using Engine.Tools;
using log4net;

namespace Engine.Management
{
    public class GameManager
    {
        private readonly IGameServer _gameServer;

        private readonly Settings _applicationSettings;
        private GameSession _gameSession;

        public event Action<GameSession> OnEndTurn;
        public event Action<ICelestialObject> OnMouseMoveCelestialObject;
        public event Action<ICelestialObject> OnMouseLeaveCelestialObject;
        public event Action<ICelestialObject> OnSelectCelestialObject;

        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        

        private IUiManager _ui;

        public GameManager()
        {
            _applicationSettings = LoadConfiguration();

            switch (_applicationSettings.ServerType)
            {
                case 1:
                    _gameServer = new ScalaGameServer(_applicationSettings, null);
                    break;
                case 2:
                    _gameServer = new LocalStaticGameServer();
                    break;

                case 3:
                    _gameServer = new LocalGameServer();
                    break;
            }
        }

        public void Initialization(IUiManager uiManager)
        {
            _ui = uiManager;
        }

        public void StartNewGameSession()
        {
            _ui.StartNewGameSession();

            _gameSession = Initialization();

            OnEndTurn?.Invoke(_gameSession.DeepClone());
        }

        private static Settings LoadConfiguration()
        {
            return new Settings();
        }

        public void ResumeSession()
        {
            _gameServer.ResumeSession(_gameSession.Id);
        }

        public void PauseSession()
        {
            _gameServer.PauseSession(_gameSession.Id);
        }

        public void Command(int gameSessionId, int celestialObjectId, int targetCelestialObjectId, int memberId, int targetCell, int typeId)
        {
            _gameServer.Command(gameSessionId, celestialObjectId, targetCelestialObjectId, memberId, targetCell, typeId);
        }

        public void MouseMoveCelestialObject(ICelestialObject celestialObject)
        {
            OnMouseMoveCelestialObject?.Invoke(celestialObject);
        }

        public void MouseLeaveCelestialObject(ICelestialObject celestialObject)
        {
            OnMouseLeaveCelestialObject?.Invoke(celestialObject);
        }

        public void SelectCelestialObject(ICelestialObject celestialObject)
        {
            Logger.Info("A celestial object is selected.");

            _gameSession.SelectedObject = celestialObject.DeepClone();

            OnSelectCelestialObject?.Invoke(celestialObject);
        }

        public void SelectPointInSpace(Point pointInSpace)
        {
            Logger.Debug("A point in space is selected.");

            ICelestialObject celestialObject = new PointInSpace
            {
                PositionX = pointInSpace.X, 
                PositionY = pointInSpace.Y, 
                Id = -1, 
                Name = "Point in Space",
                Classification = -1
            };

            _gameSession.SelectedObject = celestialObject.DeepClone();

            OnSelectCelestialObject?.Invoke(celestialObject);
        }

        public GameSession Initialization()
        {
            _gameSession = _gameServer.Initialization();

            Logger.Info("Initialization finished successful.");

            Scheduler.Instance.ScheduleTask(100, 100, GetDataFromServer, null);

            return _gameSession;
        }

        private int turn = -1;

        private void GetDataFromServer()
        {
            var timeMetricGetGameSession = Stopwatch.StartNew();
            
            var gameSession = _gameServer.RefreshGameSession(_gameSession.Id);

            if (gameSession != null)
            {
                _gameSession = gameSession;
            }
            else
            {
                Logger.Error($"Critical error on refresh game.");
                return;
            }

            timeMetricGetGameSession.Stop();

            if (_gameSession.Turn > turn)
            {
                EndTurn(_gameSession);
            }

            Logger.Debug($"Get game session parsing finished for {timeMetricGetGameSession.Elapsed.TotalMilliseconds}. " +
                    $"Game session id = {_gameSession.Id}." +
                    $" Turn = {_gameSession.Turn}." +
                    $" Map objects count is {_gameSession.Map.CelestialObjects.Count}.");
        }

        private void EndTurn(GameSession gameSession)
        {
            turn = gameSession.Turn;
            Logger.Debug($"[EndTurn] {turn}");

            OnEndTurn?.Invoke(gameSession);
        }

        public void AddCommandAlignTo(ICelestialObject celestialObject)
        {
            var playerShip = _gameSession.GetPlayerSpaceShip();

            celestialObject.Id = new Random().NextInt();
            celestialObject.Name = "Point in space";
            celestialObject.Classification = (int) CelestialObjectTypes.PointInMap;

            AddCelestialObject(celestialObject);

            Command(_gameSession.Id, playerShip.Id, celestialObject.Id, 0, 0, (int) CommandTypes.AlignTo);
        }

        public void AddCommandOpenFire(ICelestialObject celestialObject)
        {
            var playerShip = _gameSession.GetPlayerSpaceShip();

            Missile missile = new Missile
            {
                OwnerId = playerShip.Id,
                PositionY = playerShip.PositionY,
                PositionX = playerShip.PositionX,
                Speed = 40,
                Direction = playerShip.Direction,
                Name = "Missile",
                Signature = 1,
                Classification = (int)CelestialObjectTypes.Missile,
                IsScanned = true
            };
            // TODO: Set direction to target ship

            AddCelestialObject(missile);

            Command(_gameSession.Id, missile.Id, celestialObject.Id, 0, 0, (int)CommandTypes.Fire);
        }

        public void AddCelestialObject(ICelestialObject celestialObject)
        {
            _gameServer.AddCelestialObject(_gameSession.Id, celestialObject.Id, celestialObject.PositionX, celestialObject.PositionY, (int)celestialObject.Direction, celestialObject.Speed, celestialObject.Classification, celestialObject.Name);
        }
    }
}
