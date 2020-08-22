using System;
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

        public GameManager()
        {
            _applicationSettings = LoadConfiguration();

            _celestialMap = MapInitialization();
        }

        private Settings LoadConfiguration()
        {
            return new Settings();
        }

        public CelestialMap MapInitialization()
        {
            return RefreshCelestialMap(@"/init/9000/9000");
        }

        public CelestialMap RefreshCelestialMap(string route = @"/init/9000/9000")
        {
            // Create a request for the URL.
            var request = WebRequest.Create(_applicationSettings.ServerAddress + route);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.
            var response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

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

            // mapContent = GetSavedMap("Map_001"); //responseFromServer;

            dynamic jsonResponse = JsonConvert.DeserializeObject(mapContent);

            var celestialMap = new CelestialMap {Id = jsonResponse.Id};
            
            foreach (var celestialObjects in jsonResponse.CelestialObjects)
            {
                var asteroid = new Asteroid
                {
                    Name = celestialObjects.Name.Value,
                    PositionX = (int)celestialObjects.PositionX.Value,
                    PositionY = (int)celestialObjects.PositionY.Value,
                    Direction = (int)celestialObjects.Direction.Value,
                    Signature = (int)celestialObjects.Signature.Value,
                    Speed = (int)celestialObjects.Speed.Value,
                    Classification = (int)celestialObjects.Classification.Value,
                    IsScanned = (bool)celestialObjects.IsScanned.Value
                };

                celestialMap.CelestialObjects.Add(asteroid);
            }

            response.Close();

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
    }
}
