
namespace EngineCore.Universe.Equipment.Ammunition.Missiles
{
    public interface IMissile
    {
        int AmmoId { get; set; }
        long OwnerId { get; set; }
        float Damage { get; set; }
        float ExplosionRadius { get; set; }
    }
}
