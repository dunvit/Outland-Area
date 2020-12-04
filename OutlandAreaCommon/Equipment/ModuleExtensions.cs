using OutlandAreaCommon.Equipment.Weapon;

namespace OutlandAreaCommon.Equipment
{
    public static class ModuleExtensions
    {
        public static IWeaponModule ToWeapon(this IModule module)
        {
            return (IWeaponModule)module;
        }
    }
}
