using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class Scanning
    {
        public CommandExecuteResult Execute(GameSession gameSession, Command command)
        {
            gameSession.AddHistoryMessage($"started.", GetType().Name, true);

            if (gameSession.Turn == 10)
            {
                var a = "";
            }

            return new CommandExecuteResult { Command = command, IsResume = false };
        }
    }
}
