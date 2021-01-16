using System;
using OutlandAreaCommon.Equipment.Weapon;

namespace OutlandAreaCommon.Equipment.General.Scanner
{
    [Serializable]
    public class DeepScanner: BaseModule, IModule, IScanner, IWeaponModule
    {
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public double ScanRange { get; set; }
        public double Power { get; set; }
        public bool IsEnabled { get; set; }
        public CategoryAmmo UsedWith { get; set; } = CategoryAmmo.DeepScanProbe;
        public int AmmoId { get; set; }
        public double ReloadTime { get; set; }
        public double Reloading { get; set; }
    }
}
