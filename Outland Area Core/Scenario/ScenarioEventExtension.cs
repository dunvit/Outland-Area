using EngineCore.Universe.Model;

namespace EngineCore.Scenario
{
    public static class ScenarioEventExtension
    {

        public static ScenarioEventDialog ToScenarioEventDialog(this IScenarioEvent scenarioEvent)
        {
            return (ScenarioEventDialog)scenarioEvent;
        }
    }
}