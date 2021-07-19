using System;
using EngineCore.Tools;
using EngineCore.Universe.Model;

namespace EngineCore.Universe.Objects
{
    [Serializable]
    public class Explosion : BaseCelestialObject, ICelestialObject
    {
        public float Damage { get; set; }
        public float Radius { get; set; } = 50;
        public int RemoveTurn { get; private set; }
        public int TargetId { get; private set; }

        public Explosion(int currentTurn, int targetId)
        {
            Id = RandomGenerator.GetId();
            TargetId = targetId;
            RemoveTurn = currentTurn + 20;
        }
    }
}
