namespace EngineCore.Universe.Equipment.Weapon
{
    public interface IWeaponModule
    {
        CategoryAmmo UsedWith { get; set; }
        int AmmoId { get; set; }
        
    }
}
