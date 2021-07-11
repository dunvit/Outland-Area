using EngineCore;
using EngineCore.Session;
using System.Diagnostics;
using System.Reflection;
using log4net;

namespace Engine.DAL
{
    public class GameSessionRefresh
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public SessionDTO RequestGameSession(IGameServer gameServer, int id)
        {
            var timeMetricGetGameSession = Stopwatch.StartNew();

            var gameSession = gameServer.RefreshGameSession(id);            

            if(gameSession == null)
            {
                Logger.Error($"Critical error on refresh game id={id}.");
                return null;
            }

            timeMetricGetGameSession.Stop();

            Logger.Debug($"Turn [{gameSession.Turn}] Get data from server is finished {timeMetricGetGameSession.Elapsed.TotalMilliseconds} ms.");

            return gameSession;
        }
    }
}
