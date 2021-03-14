using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using log4net;
using Newtonsoft.Json;
using OutlandAreaCommon.Schemes;

namespace OutlandAreaCommon.Tactical.Scenario
{
    [Serializable]
    public class Dialogs
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Dialogs));

        public List<DialogRowScheme> List = new List<DialogRowScheme>();

        public Dialogs(string scenarioName)
        {
            List = Initialization(scenarioName);
        }

        public List<DialogRowScheme> Initialization(string scenarioName)
        {
            ReadDialogsFromDirectory(scenarioName);

            return List;
        }

        public DialogRowScheme Get(long id)
        {
            foreach (var dialogRowScheme in List.Where(dialogRowScheme => dialogRowScheme.Id == id))
            {
                return dialogRowScheme;
            }

            throw  new ArgumentException("Dialog not found.");
        }

        private void ReadDialogsFromDirectory(string scenarioName)
        {
            try
            {
                var folderLocation = Path.Combine(Environment.CurrentDirectory, @"Data\Scenarios\" + scenarioName + @"\Dialogs");
                var d = new DirectoryInfo(folderLocation);

                Log.Info($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Read dialogs from folder {folderLocation}");

                foreach (var file in d.GetFiles("*.json"))
                {
                    ReadFile(file.FullName);
                }
            }
            catch (Exception e)
            {
                Log.Error($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Critical error. Exception is {e.Message}");
            }
        }

        private void ReadFile(string fileLocation)
        {
            try
            {
                Log.Info($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Read dialogs from file {fileLocation}");
                var dialogs = JsonConvert.DeserializeObject<List<DialogRowScheme>>(File.ReadAllText(fileLocation));

                AddDialogs(dialogs);
            }
            catch (Exception e)
            {
                Log.Error($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Critical error. Exception is {e.Message}");
                throw;
            }
        }

        private void AddDialogs(IEnumerable<DialogRowScheme> dialogs)
        {
            try
            {
                foreach (var dialogRowScheme in dialogs)
                {
                    List.Add(new DialogRowScheme
                    {
                        Align = dialogRowScheme.Align,
                        Id = dialogRowScheme.Id,
                        Message = dialogRowScheme.Message,
                        Exits = dialogRowScheme.Exits,
                        CharacterId = dialogRowScheme.CharacterId
                    });
                }
            }
            catch (Exception e)
            {
                Log.Error($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Critical error. Exception is {e.Message}");
                throw;
            }
        }
    }
}
