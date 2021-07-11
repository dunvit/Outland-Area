using System;
using System.Collections.Generic;
using System.Text;

namespace EngineCore.Events
{
    public enum GameEventDecisionResult
    {
        TargetEvasionManeuver,
        ManeuverToApproachTarget
    }

    public static class GameEventDecisionResultExtensions
    {
        public static int ToInt(this GameEventTypes command)
        {
            return (int)command;
        }
    }
}
