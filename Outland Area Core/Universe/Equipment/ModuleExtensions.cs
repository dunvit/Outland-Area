using EngineCore.Universe.Equipment.Weapon;

namespace EngineCore.Universe.Equipment
{
    public static class ModuleExtensions
    {
        public static IWeaponModule ToWeapon(this IModule module)
        {
            return (IWeaponModule)module;
        }
    }
}
