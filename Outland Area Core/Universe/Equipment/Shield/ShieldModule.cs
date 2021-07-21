using EngineCore.Session;
using System;

namespace EngineCore.Universe.Equipment.Shield
{
    [Serializable]
    public class ShieldModule : AbstractModule, IModule, IShieldModule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public double Power { get; set; }

    }
}
