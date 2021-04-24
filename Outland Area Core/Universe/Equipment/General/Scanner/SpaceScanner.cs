using System;
using EngineCore.Universe.Equipment.Weapon;

namespace EngineCore.Universe.Equipment.General.Scanner
{
    [Serializable]
    public class SpaceScanner : BaseModule, IModule, IScanner, IWeaponModule
    {
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public double ScanRange { get; set; }
        public double Power { get; set; }
        public bool IsEnabled { get; set; } = true;

        public SpaceScanner()
        {
            IsAutoRun = true;
        }

        public CategoryAmmo UsedWith { get; set; } = CategoryAmmo.None;
        public int AmmoId { get; set; }
        public double ReloadTime { get; set; }
        public double Reloading { get; set; }
    }
}
