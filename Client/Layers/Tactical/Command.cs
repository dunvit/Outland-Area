using System;

namespace Engine.Layers.Tactical
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
