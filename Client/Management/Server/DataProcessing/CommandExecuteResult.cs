using Engine.Layers.Tactical;

namespace Engine.Management.Server.DataProcessing
{
    public struct CommandExecuteResult
    {
        public bool IsResume { get; set; }

        public Command Command { get; set; }
    }
}
