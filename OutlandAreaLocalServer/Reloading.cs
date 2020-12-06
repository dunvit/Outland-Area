using System.Linq;
using System.Reflection;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.Weapon;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaLocalServer
{
    public class Reloading
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public CelestialMap Recalculate(GameSession gameSession)
        {
            var result = gameSession.SpaceMap.DeepClone();

            foreach (var celestialObject in result.CelestialObjects)
            {
                if(celestialObject.IsSpaceship() == false) continue;

                foreach (var module in celestialObject.ToSpaceship().Modules.Where(m => m is IWeaponModule))
                {
                    if (!(module.ToWeapon().Reloading < module.ToWeapon().ReloadTime)) continue;

                    Logger.Debug($"Object {celestialObject.Name} reload module {module.Name} from {module.ToWeapon().Reloading} to +1 second.");
                    module.ToWeapon().Reloading++;

                    if (module.ToWeapon().Reloading >= module.ToWeapon().ReloadTime)
                    {
                        module.ToWeapon().Reloading = module.ToWeapon().ReloadTime;
                        gameSession.History.Add($"'{celestialObject.Name}' finished reload module '{module.Name}'");
                    }
                }
            }

            return result;
        }
    }
}
