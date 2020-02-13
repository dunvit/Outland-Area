using System;
using System.IO;
using System.Web.Script.Serialization;
using log4net;
using OutlandAreaLogic.CharacterSystem.Schemes;

namespace OutlandAreaLogic.CharacterSystem
{
    public class Character
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Character));

        public long Id { get; set; }

        public string Name { get; set; }

        // TODO: Add ranks classification
        public string Rank { get; set; }

        // TODO: Add ranks relations
        public string Relation { get; set; } = "Дружелюбие";

        public Character(long id)
        {
            Id = id;

            LoadCharacterData(id);
        }

        private void LoadCharacterData(long id)
        {
            var fileLocation = Path.Combine(Environment.CurrentDirectory, @"Data\Characters\" + id + @"\Info.json");

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
                }
            }
            catch (Exception e)
            {
                Log.Error($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Critical error on read data from file {fileLocation} for character object {id}. Exception is {e.Message}");

                throw new InvalidOperationException("Critical error on read character data from file.");
            }
        }
    }
}
