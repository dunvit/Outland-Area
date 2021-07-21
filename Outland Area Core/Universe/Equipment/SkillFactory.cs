using System.Collections.Generic;
using EngineCore.Universe.Equipment.Weapon;

namespace EngineCore.Universe.Equipment
{
    public class SkillFactory
    {
        public static List<ISkill> GetLightMissileSkills()
        {
            return new List<ISkill> {LightMissileQuickShot(), LightMissileAimedShot()};
        }

        private static ISkill LightMissileQuickShot()
        {
            ISkill result = new WeaponSkill {ImageFile = "Quick_Shot", ChanceToHit = 0, Energy = 20, ChanceToHitPerUnitOfDistance = 4};

            return result;
        }

        public static ISkill LightMissileAimedShot()
        {
            ISkill result = new WeaponSkill { ImageFile = "Aimed_Shot", ChanceToHit = 20, Energy = 40, ChanceToHitPerUnitOfDistance = 2};

            return result;
        }
    }
}
