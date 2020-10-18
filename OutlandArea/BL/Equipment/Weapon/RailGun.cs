using System;

namespace OutlandArea.BL.Equipment.Weapon
{
    [Serializable]
    public class RailGun : IModule, IWeaponModule
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public double ReloadTime { get; set; }
        public double ShieldDamage { get; set; }
        public double CriticalHit { get; set; }
    }
}
