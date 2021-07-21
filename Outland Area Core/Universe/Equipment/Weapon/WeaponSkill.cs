using System;
using System.Collections.Generic;
using System.Text;
using EngineCore.Tools;

namespace EngineCore.Universe.Equipment.Weapon
{
    [Serializable]
    public class WeaponSkill : ISkill
    {
        public int Energy { get; set; }

        public int ChanceToHit { get; set; }

        public int ChanceToHitPerUnitOfDistance { get; set; }

        public int IgnoreShieldPercent { get; set; }
        public int Id { get; set; }

        public WeaponSkill()
        {
            Id = RandomGenerator.GetId();
        }

        public string ImageFile { get; set; }

        public void Execute(int ownerId, int moduleId, int targetId, int targetModuleId)
        {
            var a = "";
        }
    }
}
