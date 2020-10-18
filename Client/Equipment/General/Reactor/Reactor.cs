using System;

namespace Engine.Equipment.General
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
