
using System;

namespace OutlandAreaCommon.Universe.Objects
{
    [Serializable]
    public class BaseCelestialObject
    {
        public float PreviousPositionX { get; set; }
        public float PreviousPositionY { get; set; }

        public float PositionX { get; set; }
        public float PositionY { get; set; }

        public bool IsScanned { get; set; }

        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public double Direction { get; set; }
        public int Signature { get; set; }
        public int Speed { get; set; }

        public int Classification { get; set; }
        public string ImageSmall { get; set; }
    }
}
