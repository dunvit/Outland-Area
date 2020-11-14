using OutlandAreaCommon.Tactical;

namespace OutlandAreaCommon.Server.DataProcessing
{
    public struct CommandExecuteResult
    {
        public bool IsResume { get; set; }

        public Command Command { get; set; }
    }
}
