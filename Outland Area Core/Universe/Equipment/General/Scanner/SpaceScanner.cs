using System;

namespace EngineCore.Universe.Equipment.General.Scanner
{
    [Serializable]
    public class SpaceScanner : AbstractModule, IModule, IScanner
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
    }
}
