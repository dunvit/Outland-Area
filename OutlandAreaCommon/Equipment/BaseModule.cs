using System;

namespace OutlandAreaCommon.Equipment
{
    [Serializable]
    public class BaseModule
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }

        public string Name { get; set; }
    }
}
