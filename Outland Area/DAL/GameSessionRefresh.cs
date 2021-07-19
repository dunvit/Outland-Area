using EngineCore;
using System.Diagnostics;
using System.Reflection;
using EngineCore.DTO;
using log4net;

namespace Engine.DAL
{
    public class GameSessionRefresh
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public SessionDataDto RequestGameSession(IGameServer gameServer, int id)
        {
            var timeMetricGetGameSession = Stopwatch.StartNew();

            var gameSession = gameServer.RefreshGameSession(id);            

            timeMetricGetGameSession.Stop();

            Logger.Debug($"Turn [{gameSession.Turn}] Get data from server is finished {timeMetricGetGameSession.Elapsed.TotalMilliseconds} ms.");

            return gameSession;
        }
    }
}
