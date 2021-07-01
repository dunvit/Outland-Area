using EngineCore;
using EngineCore.Session;
using log4net;
using System.Diagnostics;
using System.Reflection;

namespace Engine.DAL
{
    public class GameSessionRefresh
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public SessionDTO RequestGameSession(IGameServer _gameServer, int id)
        {
            var timeMetricGetGameSession = Stopwatch.StartNew();

            var gameSession = _gameServer.RefreshGameSession(id);            

            if(gameSession == null)
            {
                Logger.Error($"[Client][{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] Critical error on refresh game id={id}.");
                return null;
            }

            timeMetricGetGameSession.Stop();

            Logger.Debug($"[Client][{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] Turn [{gameSession.Turn}] Get data from server is finished {timeMetricGetGameSession.Elapsed.TotalMilliseconds} ms.");

            return gameSession;
        }
    }
}
