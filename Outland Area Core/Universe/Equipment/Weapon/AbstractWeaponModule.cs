using System;

namespace EngineCore.Universe.Equipment.Weapon
{
    [Serializable]
    public class AbstractWeaponModule : AbstractModule, IRange, IWeaponModule
    {
        public int Range { get; set; }
        public double Efficiency { get; set; }
        public CategoryAmmo UsedWith { get; set; }
        public int AmmoId { get; set; }
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
