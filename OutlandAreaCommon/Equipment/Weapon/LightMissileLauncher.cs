using System;

namespace OutlandAreaCommon.Equipment.Weapon
{
    [Serializable]
    public class LightMissileLauncher : BaseModule, IModule, IWeaponModule
    {
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public CategoryAmmo UsedWith { get; set; } = CategoryAmmo.LightMissile;
        public int AmmoId { get; set; }
        public double ReloadTime { get; set; }
        public double Reloading { get; set; }
    }
}
