using System;
using OutlandAreaCommon.Common;

namespace OutlandAreaCommon.Universe.Objects.Spaceships
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
