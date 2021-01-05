using System.Linq;
using OutlandAreaCommon;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.Weapon;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaLocalServer.Actions
{
    public class AutomaticLaunchModules
    {
        public GameSession Execute(GameSession gameSession)
        {
            gameSession.AddHistoryMessage($"AutomaticLaunchModules started.", GetType().Name, true);

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

        private bool Flow(GameSession gameSession, IModule module)
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

            var spaceship = gameSession.GetCelestialObject(module.OwnerId).ToSpaceship();

            gameSession.AddHistoryMessage($"Spaceship '{spaceship.Name}' automatic launch module '{module.Name}'", GetType().Name);

            return true;
        }
    }
}
