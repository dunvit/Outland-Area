using System.Diagnostics;
using EngineCore.Session;
using EngineCore.Tools;
using log4net;

namespace EngineCore
{
    public class LocalGameServer : IGameServer
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private GameSession _gameSession;

        public GameSession Initialization(string scenario)
        {
            var stopwatch = Stopwatch.StartNew();

            _gameSession = ScenarioConvertor.LoadGameSession("Map_OneShip");

            _gameSession.IsPause = true;

            Scheduler.Instance.ScheduleTask(50, 50, ExecuteTurnCalculation, null);

            Logger.Info($"Initialization finished {stopwatch.Elapsed.TotalMilliseconds} ms.");
            return _gameSession.DeepClone();
        }

        private bool isDebug;

        // 20 times on second - calculation
        private void ExecuteTurnCalculation()
        {
            if (_gameSession.IsPause) return;

            if (isDebug) return;

            isDebug = true;

            TurnCalculation();

            isDebug = false;
        }

        private void TurnCalculation()
        {
            var stopwatch = Stopwatch.StartNew();

            _gameSession.Turn++;

            Logger.Debug($"[Server] Calculation finished {stopwatch.Elapsed.TotalMilliseconds} ms.");
        }

        public GameSession RefreshGameSession(int id)
        {
            return _gameSession.DeepClone();
        }

        public void ResumeSession(int id)
        {
            _gameSession.IsPause = false;
        }

        public void PauseSession(int id)
        {
            _gameSession.IsPause = true;
        }

        public void Command(int sessionId, int objectId, int targetCelestialObjectId, int memberId, int targetCell, int typeId)
        {
            throw new System.NotImplementedException();
        }
    }
}