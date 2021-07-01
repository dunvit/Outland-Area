
namespace EngineCore.Session
{
    public class StatusController : IStatus
    {
        public bool IsPause { get; private set; }

        public void Pause() => IsPause = true;

        public void Resume() => IsPause = false;
    }
}
