using OutlandAreaCommon.Tactical.Model;

namespace OutlandAreaCommon.Tactical
{
    public static class ScenarioEventExtension
    {

        public static ScenarioEventDialog ToScenarioEventDialog(this IScenarioEvent scenarioEvent)
        {
            return (ScenarioEventDialog)scenarioEvent;
        }
    }
}