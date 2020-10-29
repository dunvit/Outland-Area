using System;

namespace Engine.Layers.Tactical.Objects
{
    [Serializable]
    public class Asteroid: ICelestialObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Direction { get; set; }
        public int Signature { get; set; }
        public int Speed { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Classification { get; set; }
        public string ImageSmall { get; set; }
        public bool IsScanned { get; set; }
    }
}
