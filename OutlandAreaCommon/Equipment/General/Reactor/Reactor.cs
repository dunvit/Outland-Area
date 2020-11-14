using System;

namespace OutlandAreaCommon.Equipment.General.Reactor
{
    [Serializable]
    public class Reactor :  IModule, IReactor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public double Power { get; set; }
    }
}
