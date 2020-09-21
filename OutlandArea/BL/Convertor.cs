using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OutlandArea.Map;

namespace OutlandArea.BL
{
    public class Convertor
    {
        public static GameSession GetDebugGameSession()
        {
            var mapContent = GetSavedMap("Map_003");

            return ToGameSession(mapContent);
        }

        public static string GetSavedMap(string mapName)
        {
            var fileLocation = Path.Combine(Environment.CurrentDirectory, @"Data\Maps\" + mapName + @".json");

            // Open the text file using a stream reader.
            using (var sr = new StreamReader(fileLocation))
            {
                // Read the stream as a string, and write the string to the console.
                return sr.ReadToEnd().Replace("\r", "").Replace("\n", "");
            }
        }

        public static GameSession ToGameSession(string body)
        {
            var jObject = JObject.Parse(body);
            var iCelestialMap = jObject["celestialMap"];

            var gameSession = new GameSession
            {
                Id = (int)jObject["id"],
                Turn = (int)jObject["turn"]
            };

            var celestialMap = new CelestialMap
            {
                Id = (string)iCelestialMap["id"],
                IsEnabled = (bool)iCelestialMap["isEnabled"],
                Turn = (int)iCelestialMap["turn"]
            };

            foreach (var celestialObject in iCelestialMap["celestialObjects"].ToArray())
            {
                var jsonCelestialObject = celestialObject.ToString();

                var jCelestialObject = JObject.Parse(jsonCelestialObject);

                var asteroid = new Asteroid
                {
                    Id = (int)jCelestialObject["id"],
                    Name = (string)jCelestialObject["name"],
                    PositionX = (int)jCelestialObject["positionX"],
                    PositionY = (int)jCelestialObject["positionY"],
                    Direction = (int)jCelestialObject["direction"],
                    Signature = (int)jCelestialObject["signature"],
                    Speed = (int)jCelestialObject["speed"],
                    Classification = (int)jCelestialObject["classification"],
                    IsScanned = (bool)jCelestialObject["isScanned"]
                };

                celestialMap.CelestialObjects.Add(asteroid);
            }

            gameSession.Map = celestialMap;

            return gameSession;
        }

        public static GameSession pConvertStringToGameSession(string body)
        {
            dynamic jsonResponse = JsonConvert.DeserializeObject(body);

            var gameSession = new GameSession
            {
                Id = (int)jsonResponse.id,
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

            gameSession.Map = celestialMap;

            return gameSession;
        }
    }
}
