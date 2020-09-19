using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Newtonsoft.Json;
using OutlandArea.BL;
using OutlandArea.Map;
using OutlandAreaLogic.Configuration;


namespace OutlandArea
{
    public class GameManager
    {
        private Settings _applicationSettings;
        private GameSession _gameSession;

        public event Action<ICelestialObject> OnMouseMoveCelestialObject;
        public event Action<ICelestialObject> OnMouseLeaveCelestialObject;
        public event Action<ICelestialObject> OnSelectCelestialObject;
        public event Action OnRefreshMap;

        private Action<string> _logger;

        public List<string> History { get; private set; } = new List<string>();

        public GameManager()
        {
            _applicationSettings = LoadConfiguration();
        }

        private Settings LoadConfiguration()
        {
            return new Settings();
        }

        public GameSession MapInitialization()
        {
            _logger($"Generate celestial map");
            return RefreshCelestialMapInternal(@"/init/10000/10000");
        }

        public GameSession RefreshCelestialMap()
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                _logger($"Refresh celestial map {_gameSession.Id}");

                var celestialMap = RefreshCelestialMapInternal(@"/status/" + _gameSession.Id);

                History.Add(_gameSession.Id + " / " + _gameSession.Map.Turn);

                stopwatch.Stop();

                _logger($"Refresh celestial map {_gameSession.Id} finished for {stopwatch.Elapsed.TotalMilliseconds}");

                OnRefreshMap?.Invoke();

                return celestialMap;
            }
            catch (Exception e)
            {
                return _gameSession;
            }

        }

        public void ResumeSession()
        {
            ExecuteRequest(@"/resume/" + _gameSession.Id);
        }

        public void PauseSession()
        {
            ExecuteRequest(@"/pause/" + _gameSession.Id);
        }

        public void Command()
        {
            // (gameMapID, spaceshipID, moduleID, personID)
            ExecuteRequest($@"/command/{_gameSession.Id}/5005/201/401");
        }

        private void ExecuteRequest(string route)
        {
            var stopwatch = Stopwatch.StartNew();

            // Create a request for the URL.
            var request = WebRequest.Create(_applicationSettings.ServerAddress + route);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.
            var response = request.GetResponse();
            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            var mapContent = "";
            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (var dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                var reader = new StreamReader(dataStream);
                // Read the content.
                mapContent = reader.ReadToEnd();
                // Display the content.
                //Console.WriteLine(responseFromServer);
            }

            response.Close();

            stopwatch.Stop();

            _logger($"Get answer from server finished for {stopwatch.Elapsed.TotalMilliseconds}");

            stopwatch.Start();
        }

        private GameSession RefreshCelestialMapInternal(string route)
        {
            var stopwatch = Stopwatch.StartNew();

            // Create a request for the URL.
            var request = WebRequest.Create(_applicationSettings.ServerAddress + route);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.
            var response = request.GetResponse();
            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            var mapContent = "";
            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (var dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                var reader = new StreamReader(dataStream);
                // Read the content.
                mapContent = reader.ReadToEnd();
                // Display the content.
                //Console.WriteLine(responseFromServer);
            }

            response.Close();

            //mapContent = GetSavedMap("Map_001");

            stopwatch.Stop();

            _logger($"Get game session from server {_applicationSettings.ServerAddress + route} finished for {stopwatch.Elapsed.TotalMilliseconds}.");

            stopwatch.Start();

            var stopwatchParsing = Stopwatch.StartNew();

            //mapContent = GetSavedMap("Map_001"); //responseFromServer;

            dynamic jsonResponse = JsonConvert.DeserializeObject(mapContent);

            var gameSession = new GameSession
            {
                Id = (int) jsonResponse.id,
                Turn = (int)jsonResponse.turn
            };

            var celestialMap = new CelestialMap
            {
                Id = jsonResponse.celestialMap.id, 
                IsEnabled = jsonResponse.celestialMap.isEnabled,
                Turn = jsonResponse.celestialMap.turn
            };
 
            foreach (var celestialObjects in jsonResponse.celestialMap.celestialObjects)
            {
                var id = celestialObjects.name.Value;

                var asteroid = new Asteroid
                {
                    Id = (int)celestialObjects.id.Value,
                    Name = celestialObjects.name.Value,
                    PositionX = (int)celestialObjects.positionX.Value,
                    PositionY = (int)celestialObjects.positionY.Value,
                    Direction = (int)celestialObjects.direction.Value,
                    Signature = (int)celestialObjects.signature.Value,
                    Speed = (int)celestialObjects.speed.Value,
                    Classification = (int)celestialObjects.classification.Value,
                    IsScanned = (bool)celestialObjects.isScanned.Value
                };

                celestialMap.CelestialObjects.Add(asteroid);
            }

            stopwatchParsing.Stop();

            gameSession.Map = celestialMap;

            _logger($"Get game session parsing finished for {stopwatchParsing.Elapsed.TotalMilliseconds}. " +
                    $"Game session id = {gameSession.Id}. " +
                    $" Turn = {gameSession.Turn}. " +
                    $" Map objects count is {gameSession.Map.CelestialObjects.Count}.");

            return gameSession;
        }

        private string GetSavedMap(string mapName)
        {
            var fileLocation = Path.Combine(Environment.CurrentDirectory, @"Data\Maps\" + mapName + @".json");

            // Open the text file using a stream reader.
            using (var sr = new StreamReader(fileLocation))
            {
                // Read the stream as a string, and write the string to the console.
                return sr.ReadToEnd();
            }
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

        public GameSession Initialization(Action<string> logger)
        {
            _logger = logger;

            _gameSession = MapInitialization();

            Logger("Initialization finished successful.");

            InitializationGameSessionUpdater(logger);

            return _gameSession;
        }

        private void InitializationGameSessionUpdater(Action<string> logger)
        {
            TaskScheduler.Instance.ScheduleTask(5000, 100, GameSessionUpdater, logger);
        }

        private void GameSessionUpdater()
        {
            var timeMetricGetGameSession = Stopwatch.StartNew();

            var gameSession = RefreshCelestialMap();

            timeMetricGetGameSession.Stop();

            //GameTurnsCollection.AddOrUpdate(cell, "value is " + cell, (key, oldValue) => "value is " + cell);

            _logger($"Get game session parsing finished for {timeMetricGetGameSession.Elapsed.TotalMilliseconds}. " +
                    $"Game session id = {gameSession.Id}." +
                    $" Turn = {gameSession.Turn}." +
                    $" Map objects count is {gameSession.Map.CelestialObjects.Count}.");
        }

        private void Logger(string message)
        {
            _logger(" " + message);
        }
    }
}
