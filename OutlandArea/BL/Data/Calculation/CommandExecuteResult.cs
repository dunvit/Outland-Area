
namespace OutlandArea.BL.Data.Calculation
{
    public struct CommandExecuteResult
    {
        public bool IsResume { get; set; }

        public GameCommand Command { get; set; }
    }
}
