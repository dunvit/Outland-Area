using System;
using OutlandAreaCommon.Universe;

namespace OutlandAreaCommon.Tactical
{
    [Serializable]
    public class Command
    {
        public CommandTypes Type { get; set; }
        public long CelestialObjectId { get; set; }
        public int MemberId { get; set; }
        public long TargetCelestialObjectId { get; set; }
        public int TargetCellId { get; set; }
    }
}
