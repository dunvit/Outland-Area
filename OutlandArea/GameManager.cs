using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using OutlandArea.Map;
using OutlandAreaLogic.Configuration;


namespace OutlandArea
{
    public class GameManager
    {
        private Settings _applicationSettings;
        private CelestialMap _celestialMap;

        public event Action<ICelestialObject> OnMouseMoveCelestialObject;
        public event Action<ICelestialObject> OnMouseLeaveCelestialObject;
        public event Action<ICelestialObject> OnSelectCelestialObject;
        public event Action OnRefreshMap;

        private Action<string> _logger;

        public GameManager()
        {
            _applicationSettings = LoadConfiguration();
        }

        private Settings LoadConfiguration()
        {
            return new Settings();
        }

        public CelestialMap MapInitialization()
        {
            _logger($"Generate celestial map");
            return RefreshCelestialMapInternal(@"/init/10000/10000");
        }

        public CelestialMap RefreshCelestialMap()
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                _logger($"Refresh celestial map {_celestialMap.Id}");

                var celestialMap = RefreshCelestialMapInternal(@"/status/" + _celestialMap.Id);

                stopwatch.Stop();

                _logger($"Refresh celestial map {_celestialMap.Id} finished for {stopwatch.Elapsed.TotalMilliseconds}");

                OnRefreshMap?.Invoke();

                return celestialMap;
            }
            catch (Exception e)
            {
                return _celestialMap;
            }

        }

        public void ResumeSession()
        {
            ExecuteRequest(@"/resume/" + _celestialMap.Id);
        }

        public void Command()
        {
            // (gameMapID, spaceshipID, moduleID, personID)
            ExecuteRequest($@"/command/{_celestialMap.Id}/5005/201/401");
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

        private CelestialMap RefreshCelestialMapInternal(string route)
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

            _logger($"Get celestial map from server finished for {stopwatch.Elapsed.TotalMilliseconds}");

            stopwatch.Start();

            var stopwatch1 = Stopwatch.StartNew();

            //mapContent = GetSavedMap("Map_001"); //responseFromServer;

            dynamic jsonResponse = JsonConvert.DeserializeObject(mapContent);

            var celestialMap = new CelestialMap
            {
                Id = jsonResponse.id, 
                IsEnabled = jsonResponse.isEnabled,
                Turn = jsonResponse.turn
            };

            foreach (var celestialObjects in jsonResponse.celestialObjects)
            {
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

            stopwatch1.Stop();

            //_logger($"Rebuild celestial map finished for {stopwatch1.Elapsed.TotalMilliseconds}");

            //_logger($"[RefreshCelestialMapInternal] finished for {stopwatch.Elapsed.TotalMilliseconds}");

            return celestialMap;
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

        public void Initialization(Action<string> logger)
        {
            _logger = logger;

            _celestialMap = MapInitialization();

            Logger("Initialization finished successful.");
        }

        private void Logger(string message)
        {
            _logger(" " + message);
        }
    }
}
