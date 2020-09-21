using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;
using OutlandArea.BL;
using OutlandArea.BL.Data;
using OutlandArea.Map;
using OutlandAreaLogic.Configuration;


namespace OutlandArea
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

        private Action<string> _logger;


        public GameManager(Action<string> logger)
        {
            _logger = logger;

            _applicationSettings = LoadConfiguration();

            switch (_applicationSettings.ServerType)
            {
                case 1:
                    _gameServer = new ScalaGameServer(_applicationSettings, _logger);
                    break;
            }
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

        public void Command()
        {
            _gameServer.Command(_gameSession.Id, 100, 200, 300);
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
            



            _gameSession = _gameServer.Initialization(_logger);

            Logger("Initialization finished successful.");

            TaskScheduler.Instance.ScheduleTask(5000, 100, GetDataFromServer, _logger);

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
                _logger("Critical error.");
                return;
            }

            timeMetricGetGameSession.Stop();

            if (_gameSession.Turn > turn)
            {
                EndTurn(_gameSession);
            }

            _logger($"Get game session parsing finished for {timeMetricGetGameSession.Elapsed.TotalMilliseconds}. " +
                    $"Game session id = {_gameSession.Id}." +
                    $" Turn = {_gameSession.Turn}." +
                    $" Map objects count is {_gameSession.Map.CelestialObjects.Count}.");
        }

        private void EndTurn(GameSession gameSession)
        {
            turn = gameSession.Turn;

            OnEndTurn?.Invoke(gameSession);
        }

        private void Logger(string message)
        {
            _logger(" " + message);
        }
    }
}
