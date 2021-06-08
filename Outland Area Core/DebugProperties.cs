
namespace EngineCore
{
    public interface IDebugProperties
    {
        bool IsAlwaysSuccessful { get; set; }
        bool IsIgnoreReload { get; set; }

    }

    public class DebugProperties: IDebugProperties
    {
        public bool IsAlwaysSuccessful { get; set; }
        public bool IsIgnoreReload { get; set; }

        public DebugProperties(bool isAlwaysSuccessful, bool isIgnoreReload)
        {
            IsAlwaysSuccessful = isAlwaysSuccessful;
            IsIgnoreReload = isIgnoreReload;
        }
    }

    public class EmptyDebugProperties : IDebugProperties
    {
        public bool IsAlwaysSuccessful { get; set; }
        public bool IsIgnoreReload { get; set; }
    }
}
