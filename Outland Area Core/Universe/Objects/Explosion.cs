using System;
using EngineCore.Tools;
using EngineCore.Universe.Model;

namespace EngineCore.Universe.Objects
{
    [Serializable]
    public class Explosion : BaseCelestialObject, ICelestialObject
    {
        public float Damage { get; set; }
        public float Radius { get; set; }

        public Explosion()
        {
            Id = RandomGenerator.GetId();
        }
    }
}
