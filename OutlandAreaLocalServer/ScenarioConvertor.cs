using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Tactical.Model;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaCommon.Universe.Objects.Spaceships;

namespace OutlandAreaLocalServer
{
    public class ScenarioConvertor
    {
        public static string GetSavedMap(string mapName)
        {
            var fileLocation = Path.Combine(Environment.CurrentDirectory, @"Data\Scenarios\" + mapName + @".json");

            // Open the text file using a stream reader.
            using (var sr = new StreamReader(fileLocation))
            {
                // Read the stream as a string, and write the string to the console.
                return sr.ReadToEnd().Replace("\r", "").Replace("\n", "");
            }
        }

        public static GameSession LoadGameSession(string mapName)
        {
            var mapBody = GetSavedMap(mapName);
            var gameSession = ToGameSession(mapBody);

            gameSession.ScenarioEvents = LoadScenarioEvents(@"Data\Scenarios\Events\" + mapName);

            return gameSession;
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

            if (jObject["spawn.rules"] != null)
            {
                var spawnRules = jObject["spawn.rules"];

                gameSession.SpawnRules.AsteroidSmallSize = (double)spawnRules["asteroidSmall"];
            }

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
                            PreviousPositionX = (int)jCelestialObject["positionX"],
                            PreviousPositionY = (int)jCelestialObject["positionY"],
                            Direction = (int)jCelestialObject["direction"],
                            Signature = (int)jCelestialObject["signature"],
                            Speed = (int)jCelestialObject["speed"],
                            Classification = classification,
                            IsScanned = (bool)jCelestialObject["isScanned"]
                        };

                        celestialMap.CelestialObjects.Add(asteroid);
                        break;

                    case 201:
                    case 202:
                    case 203:
                    case 2: case 200:
                        var spaceship = new Spaceship()
                        {
                            Id = (int)jCelestialObject["id"],
                            Name = (string)jCelestialObject["name"],
                            PositionX = (int)jCelestialObject["positionX"],
                            PositionY = (int)jCelestialObject["positionY"],
                            PreviousPositionX = (int)jCelestialObject["positionX"],
                            PreviousPositionY = (int)jCelestialObject["positionY"],
                            Direction = (int)jCelestialObject["direction"],
                            Signature = (int)jCelestialObject["signature"],
                            Speed = (int)jCelestialObject["speed"],
                            MaxSpeed = (int)jCelestialObject["maxSpeed"],
                            Classification = classification,
                            IsScanned = (bool)jCelestialObject["isScanned"]
                        };

                        if (jCelestialObject["systems"] != null)
                        {
                            foreach (var allModulesSystems in jCelestialObject["systems"].ToArray())
                            {
                                if (allModulesSystems["propulsion"] != null)
                                {
                                    foreach (var propulsionModule in allModulesSystems["propulsion"].ToArray())
                                    {
                                        var compartment = 0;
                                        var slot = 0;

                                        if (propulsionModule["compartment"] != null)
                                        {
                                            compartment = (int)propulsionModule["compartment"];
                                        }

                                        if (propulsionModule["slot"] != null)
                                        {
                                            slot = (int)propulsionModule["slot"];
                                        }


                                        var module = Factory.CreateMicroWarpDrive(spaceship.Id, (string)propulsionModule["id"]);

                                        module.Compartment = compartment;
                                        module.Slot = slot;

                                        spaceship.Modules.Add(module);
                                    }
                                }

                                if (allModulesSystems["weapon"] != null)
                                {
                                    foreach (var weaponModule in allModulesSystems["weapon"].ToArray())
                                    {
                                        var compartment = 0;
                                        var slot = 0;

                                        if (weaponModule["compartment"] != null)
                                        {
                                            compartment = (int)weaponModule["compartment"];
                                        }

                                        if (weaponModule["slot"] != null)
                                        {
                                            slot = (int)weaponModule["slot"];
                                        }

                                        var module = Factory.CreateWeaponModule(spaceship.Id, (string)weaponModule["id"]);

                                        module.Compartment = compartment;
                                        module.Slot = slot;

                                        spaceship.Modules.Add(module);
                                    }
                                }

                                if (allModulesSystems["general"] != null)
                                {
                                    foreach (var generalModule in allModulesSystems["general"].ToArray())
                                    {
                                        var compartment = 0;
                                        var slot = 0;

                                        if (generalModule["compartment"] != null)
                                        {
                                            compartment = (int) generalModule["compartment"];
                                        }

                                        if (generalModule["slot"] != null)
                                        {
                                            slot = (int) generalModule["slot"];
                                        }

                                        var module = Factory.CreateGeneralModule(spaceship.Id, (string) generalModule["id"]);

                                        module.Compartment = compartment;
                                        module.Slot = slot;

                                        spaceship.Modules.Add(module);
                                    }
                                }

                                if (allModulesSystems["shields"] != null)
                                {
                                    foreach (var generalModule in allModulesSystems["shields"].ToArray())
                                    {
                                        spaceship.Modules.Add(Factory.CreateShieldModule(spaceship.Id, (string)generalModule["id"]));
                                    }
                                }

                            }
                        }

                        spaceship.Initialization();

                        celestialMap.CelestialObjects.Add(spaceship);
                        break;

                    case 300:
                        var a = "";
                        break;
                }

                
            }

            gameSession.SpaceMap = celestialMap;

            

            return gameSession;
        }

        private static IEnumerable<IScenarioEvent> LoadScenarioEvents(string folder)
        {
            var results = new List<IScenarioEvent>();

            var directoryLocation = Path.Combine(Environment.CurrentDirectory, folder);

            var d = new DirectoryInfo(directoryLocation);

            foreach (var file in d.GetFiles())
            {
                
            }

            return results;
        }
    }
}
