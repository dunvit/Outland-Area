using System;

namespace Engine.Layers.Tactical
{
    [Serializable]
    public class Command
    {
        public CommandsTypes Type { get; set; }
        public int CelestialObjectId { get; set; }
        public int MemberId { get; set; }
        public int TargetCelestialObjectId { get; set; }
        public int TargetCellId { get; set; }
    }
}
