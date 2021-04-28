using System;

namespace EngineCore.Universe.Equipment.Weapon
{
    [Serializable]
    public class LightMissileLauncher : BaseModule, IModule, IWeaponModule
    {
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public CategoryAmmo UsedWith { get; set; } = CategoryAmmo.LightMissile;
        public int AmmoId { get; set; }
        
    }
}
