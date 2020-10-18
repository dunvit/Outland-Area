using System;

namespace Engine.Equipment.Propulsion
{
    [Serializable]
    public class MicroWarpDrive: IModule, IPropulsionModule
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double ActivationCost { get; set; }


        public double Power { get; set; }
    }
}
