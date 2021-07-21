using System;
using EngineCore.Session;
using EngineCore.Universe.Equipment.Weapon;

namespace EngineCore.Universe.Equipment.General.Scanner
{
    [Serializable]
    public class DeepScanner: AbstractModule, IModule, IScanner
    {
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public double ScanRange { get; set; }
        public double Power { get; set; }
        public bool IsEnabled { get; set; }
        public CategoryAmmo UsedWith { get; set; } = CategoryAmmo.DeepScanProbe;
    }
}
