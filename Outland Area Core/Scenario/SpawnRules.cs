using System;

namespace EngineCore.Scenario
{
    [Serializable]
    public class SpawnRules
    {
        public bool IsRandomObjectsGeneration { get; set; } = true;

        public double AsteroidSmallSize { get; set; } = 20;
    }
}
