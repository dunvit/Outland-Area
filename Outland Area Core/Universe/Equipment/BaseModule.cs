using log4net;
using Newtonsoft.Json.Linq;
using System;

namespace EngineCore.Universe.Equipment
{
    [Serializable]
    public class BaseModule
    {
        [NonSerialized()]
        protected static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public int Id { get; set; }
        public long OwnerId { get; set; }

        /// <summary>
        /// Property for automatic execute module after finish it work.
        /// </summary>
        public bool IsAutoRun { get; set; } = false;
        public string Name { get; set; }

        /// <summary>
        /// Fitting - Compartment number
        /// </summary>
        public int Compartment { get; set; }
        /// <summary>
        /// Fitting - Slot position
        /// </summary>
        public int Slot { get; set; }

        public double ReloadTime { get; set; }
        public double Reloading { get; set; }

        public dynamic CreateServerCommand()
        {
            dynamic serverCommand = new JObject();

            serverCommand.ModuleId = Id;
            serverCommand.Date = DateTime.Now;
            serverCommand.OwnerId = OwnerId;

            return serverCommand;
        }

        public void Reload()
        {
            Reloading = 0;
        }
    }
}
