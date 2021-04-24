namespace EngineCore.Universe.Equipment.Weapon
{
    public interface IWeaponModule
    {
        CategoryAmmo UsedWith { get; set; }
        int AmmoId { get; set; }
        double ReloadTime { get; set; }
        double Reloading { get; set; }
    }
}
