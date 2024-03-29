﻿using EngineCore.Session;
using System;

namespace EngineCore.Universe.Equipment.Weapon
{
    [Serializable]
    public class RailGun : AbstractModule, IModule, IWeaponModule
    {
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public CategoryAmmo UsedWith { get; set; } = CategoryAmmo.SmallHybridCharge;
        public int AmmoId { get; set; } = 501;

        public dynamic Shot(int objectId, int targetId)
        {
            throw new NotImplementedException();
        }

        public dynamic Shot(int objectId, int targetId, int moduleId, int actionId)
        {
            throw new NotImplementedException();
        }

        public int BaseAccuracy { get; set; }
    }
}
