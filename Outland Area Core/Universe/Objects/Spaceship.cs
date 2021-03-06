﻿using System;
using System.Collections.Generic;
using System.Linq;
using EngineCore.Universe.Equipment;
using EngineCore.Universe.Equipment.General.Scanner;
using EngineCore.Universe.Equipment.Propulsion;
using EngineCore.Universe.Equipment.Shield;
using EngineCore.Universe.Equipment.Weapon;
using EngineCore.Universe.Model;


namespace EngineCore.Universe.Objects
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

                foreach (var shield in Modules.
                    Where(module => module != null).
                    Where(module => module.Category == Category.Shield).
                    Cast<ShieldModule>())
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

        public IWeaponModule GetWeaponModule(int moduleId)
        {
            foreach (var weapon in Modules.Where(module => module.Category == Category.Weapon && module.Id == moduleId).Cast<IWeaponModule>())
            {
                return weapon;
            }

            throw new Exception($"Critical error. Module {moduleId} for spaceship {Id} not found.");
        }

        public List<SpaceScanner> GetScanningModules()
        {
            return Modules.Where(module => module.Category == Category.SpaceScanner).Cast<SpaceScanner>().ToList();
        }

        public List<MicroWarpDrive> GetPropulsionModules()
        {
            return Modules.Where(module => module.Category == Category.Propulsion).Cast<MicroWarpDrive>().ToList();
        }

        public List<IModule> GetModules(Category modulesCategory)
        {
            return Modules.Where(module => module.Category == modulesCategory).ToList();
        }

        public List<IModule> GetModules(int compartment)
        {
            return Modules.Where(module => module.Compartment == compartment).ToList();
        }

        public List<IModule> Modules { get; set; } = new List<IModule>();

        public IModule GetModule(int moduleId)
        {
            return Modules.FirstOrDefault(module => module.Id == moduleId);
        }
    }
}
