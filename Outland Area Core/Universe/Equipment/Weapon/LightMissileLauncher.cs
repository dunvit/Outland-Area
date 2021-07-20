using EngineCore.Session;
using System;
using System.Collections.Generic;

namespace EngineCore.Universe.Equipment.Weapon
{
    [Serializable]
    public class LightMissileLauncher : AbstractModule, IModule, IWeaponModule
    {
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public CategoryAmmo UsedWith { get; set; } = CategoryAmmo.LightMissile;
        public int AmmoId { get; set; }

        public LightMissileLauncher()
        {
            Skills = SkillFactory.GetLightMissileSkills();
        }

        public dynamic Shot(int objectId, int targetId, int moduleId, int actionId)
        {
            Logger.Debug($"[{GetType().Name}]\t Execute command 'Shot'");

            var serverCommand = CreateServerCommand();

            serverCommand.TypeId = CommandTypes.Shot;
            serverCommand.ObjectId = objectId;
            serverCommand.TargetId = targetId;
            serverCommand.ModuleId = moduleId;
            serverCommand.ActionId = actionId;

            return serverCommand;
        }

        public int BaseAccuracy { get; set; }
        
    }
}
