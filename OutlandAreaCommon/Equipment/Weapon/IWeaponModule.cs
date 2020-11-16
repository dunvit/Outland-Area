namespace OutlandAreaCommon.Equipment.Weapon
{
    public interface IWeaponModule
    {
        double ReloadTime { get; set; }
        double ShieldDamage { get; set; }

        double CriticalHit { get; set; }
    }
}
