using System;
using System.Reflection;
using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Objects;
using log4net;

namespace EngineCore.DataProcessing
{
    public class Reloading
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public CelestialMap Recalculate(GameSession gameSession, TurnSettings settings)
        {
            var result = gameSession.SpaceMap.DeepClone();

            

            foreach (var celestialObject in result.CelestialObjects)
            {
                if (celestialObject.IsSpaceship() == false) continue;

                foreach (var module in celestialObject.ToSpaceship().Modules)
                {
                    if (gameSession.Turn % 150 == 0)
                    {
                        // Only for debug. Emulation use modules.
                        module.Reloading = 0;
                        continue;
                    }


                    if ((module.Reloading == module.ReloadTime)) continue;

                    if (!(module.Reloading <= module.ReloadTime)) continue;

                    Logger.Info($"Object {celestialObject.Name} reload module {module.Name} from {module.Reloading} to {1 / settings.UnitsPerSecond} second.");

                    var reloadingprogress = Math.Round((1.0 / settings.UnitsPerSecond), 2);

                    module.Reloading += reloadingprogress;

                    if (module.Reloading == module.ReloadTime)
                    {
                        module.Reloading = module.ReloadTime;
                        gameSession.AddHistoryMessage($"'{celestialObject.Name}' finished reload module '{module.Name}'", GetType().Name);
                    }

                    if (module.Reloading > module.ReloadTime)
                    {
                        module.Reloading = module.ReloadTime;
                    }
                }
            }

            return result;
        }
    }
}
