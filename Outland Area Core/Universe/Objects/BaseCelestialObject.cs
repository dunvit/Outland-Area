using System;

namespace EngineCore.Universe.Objects
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
        public float Speed { get; set; }

        public int Classification { get; set; }
        public string ImageSmall { get; set; }

        public void SetDirection(double direction) => Direction = direction;

        public void SetSpeed(float speed) => Speed = speed;
    }
}
