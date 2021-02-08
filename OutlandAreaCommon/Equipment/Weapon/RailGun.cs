using System;

namespace OutlandAreaCommon.Equipment.Weapon
{
    [Serializable]
    public class RailGun : BaseModule, IModule, IWeaponModule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public CategoryAmmo UsedWith { get; set; } = CategoryAmmo.SmallHybridCharge;
        public int AmmoId { get; set; } = 501;
        public double ReloadTime { get; set; }
        public double Reloading { get; set; }
    }
}
