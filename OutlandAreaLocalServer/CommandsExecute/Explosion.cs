using log4net;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class Explosion
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CommandExecuteResult Execute(GameSession gameSession, Command command)
        {
            var isResume = false;

            Logger.Info($"[{GetType().Name}]\t Execute.");

            return new CommandExecuteResult { Command = command, IsResume = isResume };
        }
    }
}
