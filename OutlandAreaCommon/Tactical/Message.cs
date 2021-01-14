
using System;

namespace OutlandAreaCommon.Tactical
{
    [Serializable]
    public class Message
    {
        public MessageTypes Type { get; set; }

        public int Turn { get; set; }

        public long CelestialObjectId { get; set; }
    }
}
