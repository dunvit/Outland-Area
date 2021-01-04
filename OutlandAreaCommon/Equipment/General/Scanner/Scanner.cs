
using System;
using OutlandAreaCommon.Equipment.Weapon;

namespace OutlandAreaCommon.Equipment.General.Scanner
{
    [Serializable]
    public class Scanner : BaseModule, IModule, IScanner, IWeaponModule
    {
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public double ScanRange { get; set; }
        public double Power { get; set; }
        public bool IsEnabled { get; set; } = true;

        public Scanner()
        {
            IsAutoRun = true;

        }

        public CategoryAmmo UsedWith { get; set; } = CategoryAmmo.None;
        public int AmmoId { get; set; }
        public double ReloadTime { get; set; }
        public double Reloading { get; set; }
    }
}
