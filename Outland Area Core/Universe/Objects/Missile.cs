using System;
using EngineCore.Tools;
using EngineCore.Universe.Model;

namespace EngineCore.Universe.Objects
{
    [Serializable]
    public class Missile : BaseCelestialObject, ICelestialObject
    {
        public float Damage { get; set; }
        public double Chance { get; set; }

        public int ModuleId { get; set; }

        public int ActionId { get; set; }

        public int Dice { get; set; }

        public int TargetId { get; set; }

        public Missile()
        {
            Id = RandomGenerator.GetId();
        }
    }
}
