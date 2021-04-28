using System;

namespace EngineCore.Universe.Equipment.Weapon
{
    [Serializable]
    public class RailGun : BaseModule, IModule, IWeaponModule
    {
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public CategoryAmmo UsedWith { get; set; } = CategoryAmmo.SmallHybridCharge;
        public int AmmoId { get; set; } = 501;

    }
}
