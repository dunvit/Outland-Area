
using System;

namespace OutlandAreaCommon.Equipment.General.Scanner
{
    [Serializable]
    public class Scanner : BaseModule, IModule, IScanner
    {
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public double ScanRange { get; set; }
        public double Power { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
