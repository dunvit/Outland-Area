using Newtonsoft.Json.Linq;
using System;

namespace EngineCore.Universe.Equipment.Propulsion
{
    [Serializable]
    public class MicroWarpDrive: BaseModule, IModule, IPropulsionModule
    {
        public Category Category { get; set; }
        public double ActivationCost { get; set; }
        public double Power { get; set; }

        public dynamic Braking()
        {
            Logger.Debug($"[{GetType().Name}]\t Execute command 'Braking'");

            var serverCommand = CreateServerCommand();

            serverCommand.TypeId = CommandTypes.StopShip;

            return serverCommand;
        }
    }
}
