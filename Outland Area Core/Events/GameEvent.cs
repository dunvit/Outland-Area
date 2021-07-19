using System;
using System.Collections.Generic;

namespace EngineCore.Events
{
    [Serializable]
    public class GameEvent
    {
        public string Id { get; set; } = Tools.RandomGenerator.GenerateGameEventId();

        public GameEventTypes Type { get; set; }

        public List<GameEventDecision> Decisions { get; set; } = new List<GameEventDecision>();

        public int Turn { get; set; }

        public bool IsPause { get; set; }

        public bool IsOpenWindow { get; set; }

        public long CelestialObjectId { get; set; }

        public long DialogId { get; set; }

        public List<GameEventParameter> GenericObjects { get; set; } = new List<GameEventParameter>();
    }

    public static class GameEventExtensions
    {
        public static string GetParameter(this GameEvent gameEvent, GameEventParameterTypes parameter)
        {
            foreach (var gameEventGenericObject in gameEvent.GenericObjects)
            {
                if (gameEventGenericObject.Type == parameter)
                {
                    return gameEventGenericObject.Value;
                }
            }

            return string.Empty;
        }
    }
}
