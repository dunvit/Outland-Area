using System;
using System.Collections.Generic;
using System.Linq;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.General.Scanner;
using OutlandAreaCommon.Equipment.Shield;
using OutlandAreaCommon.Equipment.Weapon;

namespace OutlandAreaCommon.Universe.Objects.Spaceships
{
    [Serializable]
    public class Spaceship : BaseCelestialObject, ICelestialObject
    {
        public int MaxSpeed { get; set; }

        public float Shields { get; private set; }

        public int TargetId { get; set; }

        public bool IsDestroyed => Shields < 0;

        public void Initialization()
        {
            Shields = ShieldsMax;
        }

        public void Damage(float hits)
        {
            Shields -= hits;
        }

        public float ShieldsMax
        {
            get
            {
                float result = 0;

                foreach (var shield in Modules.Where(module => module.Category == Category.Shield).Cast<ShieldModule>())
                {
                    result =+ (float) shield.Power;
                }

                return result;
            }
        }

        public List<IWeaponModule> GetWeaponModules()
        {
            var result = new List<IWeaponModule>();

            foreach (var weapon in Modules.Where(module => module.Category == Category.Weapon).Cast<IWeaponModule>())
            {
                result.Add(weapon);
            }

            return result;
        }

        public List<SpaceScanner> GetScanningModules()
        {
            return Modules.Where(module => module.Category == Category.Scanner).Cast<SpaceScanner>().ToList();
        }


        public List<IModule> Modules { get; set; } = new List<IModule>();
    }
}
