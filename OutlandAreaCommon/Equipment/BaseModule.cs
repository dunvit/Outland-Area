using System;

namespace OutlandAreaCommon.Equipment
{
    [Serializable]
    public class BaseModule
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }

        /// <summary>
        /// Property for automatic execute module after finish it work.
        /// </summary>
        public bool IsAutoRun { get; set; } = false;
        public string Name { get; set; }
    }
}
