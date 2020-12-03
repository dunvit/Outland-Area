using System;

namespace OutlandAreaCommon.Universe.Objects.Spaceships
{
    [Serializable]
    public class Explosion : BaseCelestialObject, ICelestialObject
    {
        public float Damage { get; set; }
        public float Radius { get; set; }

        public Explosion()
        {
            Id = new Random().NextInt();
        }
    }
}
