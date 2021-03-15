using System;
using OutlandAreaCommon.Common;

namespace OutlandAreaCommon.Universe.Objects.Spaceships
{
    [Serializable]
    public class Missile : BaseCelestialObject, ICelestialObject
    {
        public float Damage { get; set; }
        public float Radius { get; set; }

        public Missile()
        {
            Id = RandomGenerator.GetId();
        }
    }
}
