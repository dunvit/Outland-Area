﻿using System.Collections.Generic;
using LanguageExt;

namespace EngineCore.Universe.Equipment.Weapon
{
    public interface IWeaponModule
    {
        CategoryAmmo UsedWith { get; set; }
        int AmmoId { get; set; }

        dynamic Shot(int objectId, int targetId, int moduleId, int actionId);

        int BaseAccuracy { get; set; }

        
    }
}
