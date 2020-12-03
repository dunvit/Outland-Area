using System;

namespace OutlandAreaCommon.Universe.Objects.Spaceships
{
    [Serializable]
    public class Missile : BaseCelestialObject, ICelestialObject
    {
        public float Damage { get; set; }
        public float Radius { get; set; }

        public Missile()
        {
            Id = new Random().NextInt();
        }
    }
}
