using System;

namespace EngineCore.Universe.Equipment.Propulsion
{
    [Serializable]
    public class MicroWarpDrive: BaseModule, IModule, IPropulsionModule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double ActivationCost { get; set; }


        public double Power { get; set; }
    }
}
