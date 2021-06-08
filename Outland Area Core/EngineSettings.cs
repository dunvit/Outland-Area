
namespace EngineCore
{
    public class EngineSettings
    {
        public int UnitsPerSecond { get; set; } = 20;

        public int HistoryPeriodInSeconds { get; set; } = 20;

        public IDebugProperties DebugProperties { get; set; } = new EmptyDebugProperties();
    }
}
