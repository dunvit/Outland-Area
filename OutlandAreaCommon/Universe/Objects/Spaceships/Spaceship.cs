using System;
using System.Collections.Generic;
using System.Linq;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.Shield;
using OutlandAreaCommon.Equipment.Weapon;

namespace OutlandAreaCommon.Universe.Objects.Spaceships
{
    [Serializable]
    public class Spaceship : BaseCelestialObject, ICelestialObject
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public double Direction { get; set; }
        public int Signature { get; set; }
        public int Speed { get; set; }
        public int MaxSpeed { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public int Classification { get; set; }
        public string ImageSmall { get; set; }

        public float Shields { get; private set; }

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


        public List<IModule> Modules { get; set; } = new List<IModule>();
    }
}
