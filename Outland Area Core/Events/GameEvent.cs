using System;
using System.Collections.Generic;

namespace EngineCore.Events
{
    [Serializable]
    public class GameEvent
    {
        public string Id { get; set; } = Tools.RandomGenerator.GenerateGameEventId();

        public GameEventTypes Type { get; set; }

        public int Turn { get; set; }

        public bool IsPause { get; set; }

        public bool IsOpenWindow { get; set; }

        public long CelestialObjectId { get; set; }

        public long DialogId { get; set; }

        public List<string> GenericObjects { get; set; } = new List<string>();


    }
}
