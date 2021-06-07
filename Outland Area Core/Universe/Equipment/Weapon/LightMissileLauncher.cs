﻿using EngineCore.Session;
using System;

namespace EngineCore.Universe.Equipment.Weapon
{
    [Serializable]
    public class LightMissileLauncher : BaseModule, IModule, IWeaponModule
    {
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public CategoryAmmo UsedWith { get; set; } = CategoryAmmo.LightMissile;
        public int AmmoId { get; set; }

        public dynamic Shot(int objectId, int targetId, int moduleId)
        {
            Logger.Debug($"[{GetType().Name}]\t Execute command 'Shot'");

            var serverCommand = CreateServerCommand();

            serverCommand.TypeId = CommandTypes.Shot;
            serverCommand.ObjectId = objectId;
            serverCommand.TargetId = targetId;
            serverCommand.ModuleId = moduleId;

            



            return serverCommand;
        }

        
    }
}
