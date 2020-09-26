using System;

namespace OutlandArea.BL
{
    [Serializable]
    public class GameCommand
    {
        public int CommandTypeId { get; set; }
        public int CelestialObjectId { get; set; }
        public int MemberId { get; set; }
        public int TargetCelestialObjectId { get; set; }
        public int TargetCellId { get; set; }
    }
}
