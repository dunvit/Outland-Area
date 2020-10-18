using System;

namespace Engine.Equipment.Shield
{
    [Serializable]
    public class ShieldModule : IModule, IShieldModule
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public double Power { get; set; }
    }
}
