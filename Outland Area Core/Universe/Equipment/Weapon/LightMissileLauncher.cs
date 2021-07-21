using System;

namespace EngineCore.Universe.Equipment.Weapon
{
    [Serializable]
    public class LightMissileLauncher : AbstractWeaponModule, IModule
    {
        public Category Category { get; set; }
        public double ActivationCost { get; set; }

        public LightMissileLauncher()
        {
            Skills = SkillFactory.GetLightMissileSkills();
            Range = 500;
            Efficiency = 0.7;
        }
    }
}
