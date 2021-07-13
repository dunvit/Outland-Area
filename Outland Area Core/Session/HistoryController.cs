using System.Reflection;
using log4net;

namespace EngineCore.Session
{
    public class HistoryController : IHistory
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public void AddHistoryMessage(GameSession session, string message, string className = "", bool isTechnicalLog = false)
        {
            Logger.Debug($"[HistoryMessage]\t [{className}]\t {message} ");

            session.TurnHistory.Add(new HistoryMessage
            {
                Turn = session.Turn,
                Class = className,
                Message = message,
                IsTechnicalLog = isTechnicalLog
            });
        }
    }
}
