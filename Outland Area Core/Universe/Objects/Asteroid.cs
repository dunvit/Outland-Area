using System;
using EngineCore.Universe.Model;

namespace EngineCore.Universe.Objects
{
    [Serializable]
    public class Asteroid: BaseCelestialObject, ICelestialObject
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public double Direction { get; set; }
        public int Signature { get; set; }
        public int Speed { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public int Classification { get; set; }
        public string ImageSmall { get; set; }
        public bool IsScanned { get; set; }
    }
}
