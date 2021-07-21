using EngineCore.Session;
using System;

namespace EngineCore.Universe.Equipment.General.Reactor
{
    [Serializable]
    public class Reactor : AbstractModule, IModule, IReactor
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public double Power { get; set; }

    }
}
