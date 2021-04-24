using System;
using EngineCore.Tools;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;

namespace EngineCore.Universe.Equipment.Ammunition.Missiles.LightMissiles
{
    [Serializable]
    public class InfernoLightMissile: BaseCelestialObject, IMissile, ICelestialObject
    {
        public int AmmoId { get; set; } = 101;
        public new long OwnerId { get; set; }
        public float Damage { get; set; } = 30;
        public float ExplosionRadius { get; set; } = 80;

        public InfernoLightMissile()
        {
            Id = RandomGenerator.GetId();
            Speed = 30;
            Classification = (int) CelestialObjectTypes.Missile;
            Name = "Inferno Light Missile";
        }
    }
}
