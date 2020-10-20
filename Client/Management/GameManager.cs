using System;
using System.Diagnostics;
using Engine.Gui;
using Engine.Layers.Tactical;
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

        private IUiManager ui;

        public GameManager(IUiManager uiManager)
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

            ui = uiManager;
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
            OnSelectCelestialObject?.Invoke(celestialObject);
        }

        public GameSession Initialization()
        {
            _gameSession = _gameServer.Initialization();

            Logger.Info("Initialization finished successful.");

            Scheduler.Instance.ScheduleTask(5000, 100, GetDataFromServer, null);

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

            OnEndTurn?.Invoke(gameSession);
        }
    }
}
