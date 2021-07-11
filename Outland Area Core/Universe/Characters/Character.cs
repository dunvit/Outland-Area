using System;
using System.IO;
using EngineCore.Universe.Objects;
using log4net;
using Nancy.Json;

namespace EngineCore.Universe.Characters
{
    public class Character
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public long Id { get; set; }

        public string Name { get; set; }

        public long CelestialId { get; set; }

        public string CelestialName { get; set; }

        // TODO: Add ranks classification
        public string Rank { get; set; }

        // TODO: Add ranks relations
        public string Relation { get; set; } = "Дружелюбие";

        public Character(string scenarioName, long id)
        {
            Id = id;

            LoadCharacterData(scenarioName, id);
            LoadCelestialData(scenarioName, CelestialId);
        }

        private void LoadCharacterData(string scenarioName, long id)
        {
            var fileLocation = Path.Combine(Environment.CurrentDirectory, @"Data\Scenarios\" + scenarioName + @"\Characters\" + id + @"\Info.json");

            Log.Info($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Read data from file {fileLocation} for character {id}");

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var ser = new JavaScriptSerializer();

                    var buffer = ser.Deserialize<CharacterScheme>(sr.ReadToEnd());

                    Id = buffer.Id;
                    Name = buffer.Name;
                    Rank = buffer.Rank;
                    CelestialId = buffer.CelestialObjectId;
                }
            }
            catch (Exception e)
            {
                Log.Error($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Critical error on read data from file {fileLocation} for character object {id}. Exception is {e.Message}");

                throw new InvalidOperationException("Critical error on read character data from file.");
            }
        }

        private void LoadCelestialData(string scenarioName, long celestialId)
        {
            var fileLocation = Path.Combine(Environment.CurrentDirectory, @"Data\Scenarios\" + scenarioName + @"\CelestialObjects\" + celestialId + ".json");

            Log.Info($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Read data from file {fileLocation} for celestial object {celestialId}");

            try
            {
                using (var sr = new StreamReader(fileLocation))
                {
                    var ser = new JavaScriptSerializer();

                    var buffer = ser.Deserialize<CelestialScheme>(sr.ReadToEnd());

                    CelestialName = buffer.Name;
                }
            }
            catch (Exception e)
            {
                Log.Error($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Critical error on read data from file {fileLocation} for celestial object {celestialId}. Exception is {e.Message}");

                throw new InvalidOperationException("Critical error on read celestial object data from file.");
            }
        }
    }
}
