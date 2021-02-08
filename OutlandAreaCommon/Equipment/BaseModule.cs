using System;

namespace OutlandAreaCommon.Equipment
{
    [Serializable]
    public class BaseModule
    {
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
    }
}
