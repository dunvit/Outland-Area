using System;
using System.Collections.Generic;
using System.IO;
using log4net;
using Newtonsoft.Json;
using OutlandAreaLogic.DialogSystems.Schemes;
using OutlandAreaLogic.Items.Types;

namespace OutlandAreaLogic.Items
{
    public class Items
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Items));

        public List<IItem> List = new List<IItem>();

        public Items()
        {
            Initialization();
        }

        private List<IItem> Initialization()
        {
            ReadDialogsFromDirectory(Path.Combine(Environment.CurrentDirectory, @"Data\Items"));

            return List;
        }

        private void ReadDialogsFromDirectory(string currentDirectory)
        {
            try
            {
                var d = new DirectoryInfo(currentDirectory);

                foreach (var directory in d.GetDirectories())
                {
                    ReadDialogsFromDirectory(Path.Combine(currentDirectory, directory.Name));
                }

                Log.Info($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Read items files from folder {currentDirectory}");

                foreach (var file in d.GetFiles("*.json"))
                {
                    ReadFile(file.FullName);
                }
            }
            catch (Exception e)
            {
                Log.Error($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Critical error. Exception is {e.Message}");
                throw;
            }
        }

        private void ReadFile(string fileLocation)
        {
            try
            {
                Log.Info($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Read items data from file {fileLocation}");
                var items = JsonConvert.DeserializeObject<List<BaseItem>>(File.ReadAllText(fileLocation));

                AddItems(items);
            }
            catch (Exception e)
            {
                Log.Error($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Critical error. Exception is {e.Message}");
                throw;
            }
        }

        private void AddItems(IEnumerable<IItem> dialogs)
        {
            try
            {
                foreach (var dialogRowScheme in dialogs)
                {
                    List.Add(new BaseItem
                    {
                        Id = dialogRowScheme.Id,
                        Name = dialogRowScheme.Name,
                        Description = dialogRowScheme.Description,
                        Picture = dialogRowScheme.Picture
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
