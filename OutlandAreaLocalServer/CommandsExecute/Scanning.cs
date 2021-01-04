using log4net;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class Scanning
    {
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CommandExecuteResult Execute(GameSession gameSession, Command command)
        {
            Logger.Info($"[{GetType().Name}]\t Execute.");

            if (gameSession.Turn == 5)
            {
                var a = "";
            }


            return new CommandExecuteResult { Command = command, IsResume = false };
        }
    }
}
