using System.Linq;
using OutlandAreaCommon;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.Weapon;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;

namespace OutlandAreaLocalServer.Actions
{
    public class AutomaticLaunchModules
    {
        public GameSession Execute(GameSession gameSession)
        {
            var result = gameSession.DeepClone();

            result.GetSpaceShips()
                .Select
                (spaceship => spaceship.Modules
                    .Where(_ => _.IsAutoRun)
                    .Map(_ => (IWeaponModule)_)
                    .Where(_ => _.Reloading >= _.ReloadTime)
                    .Map(_ => (IModule)_)
                )
                .SelectMany(activeModules => activeModules).ForAll(p => Flow(result, p));

            return result;
        }

        private static bool Flow(GameSession gameSession, IModule module)
        {
            module.ToWeapon().Reloading = 0;

            gameSession.AddCommand(new Command
            {
                Type = CommandTypes.Scanning,
                CelestialObjectId = module.OwnerId,
                TargetCellId = (int)module.Id
            });

            gameSession.AddCommand(new Command
            {
                Type = CommandTypes.ReloadWeapon,
                CelestialObjectId = module.OwnerId,
                TargetCellId = (int)module.Id
            });

            return true;
        }
    }
}
