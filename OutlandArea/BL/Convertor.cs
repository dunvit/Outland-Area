using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OutlandArea.Map;
using OutlandArea.Map.Objects;

namespace OutlandArea.BL
{
    public class Convertor
    {
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

                var classification = (int) jCelestialObject["classification"];

                switch (classification)
                {
                    case 1:
                        var asteroid = new Asteroid
                        {
                            Id = (int)jCelestialObject["id"],
                            Name = (string)jCelestialObject["name"],
                            PositionX = (int)jCelestialObject["positionX"],
                            PositionY = (int)jCelestialObject["positionY"],
                            Direction = (int)jCelestialObject["direction"],
                            Signature = (int)jCelestialObject["signature"],
                            Speed = (int)jCelestialObject["speed"],
                            Classification = classification,
                            IsScanned = (bool)jCelestialObject["isScanned"]
                        };

                        celestialMap.CelestialObjects.Add(asteroid);
                        break;

                    case 2:
                        var spaceship = new Spaceship()
                        {
                            Id = (int)jCelestialObject["id"],
                            Name = (string)jCelestialObject["name"],
                            PositionX = (int)jCelestialObject["positionX"],
                            PositionY = (int)jCelestialObject["positionY"],
                            Direction = (int)jCelestialObject["direction"],
                            Signature = (int)jCelestialObject["signature"],
                            Speed = (int)jCelestialObject["speed"],
                            MaxSpeed = (int)jCelestialObject["maxSpeed"],
                            Classification = classification,
                            IsScanned = (bool)jCelestialObject["isScanned"]
                        };

                        celestialMap.CelestialObjects.Add(spaceship);
                        break;
                }

                
            }

            gameSession.Map = celestialMap;

            return gameSession;
        }
    }
}
