using EngineCore.Session;

namespace EngineCore.Universe.Equipment.Weapon
{
    public interface IWeaponModule
    {
        CategoryAmmo UsedWith { get; set; }
        int AmmoId { get; set; }

        dynamic Shot(int objectId, int targetId, int moduleId, int actionId);
    }
}
