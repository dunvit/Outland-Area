using System.Diagnostics;
using EngineCore.DataProcessing;
using EngineCore.Session;
using EngineCore.Tools;
using log4net;

namespace EngineCore
{
    public class LocalGameServer : IGameServer
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private GameSession _gameSession;
        private TurnSettings _turnSettings;

        public GameSession Initialization(string scenario)
        {
            var stopwatch = Stopwatch.StartNew();

            _turnSettings = new TurnSettings();

            _gameSession = ScenarioConvertor.LoadGameSession(scenario);

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

        public void TurnCalculation()
        {
            var stopwatch = Stopwatch.StartNew();

            _gameSession.Turn++;

            var turnGameSession = _gameSession.DeepClone();

            //-------------------------------------------------------------------------------------------------- Start calculations

            turnGameSession.SpaceMap = new Coordinates().Recalculate(turnGameSession.SpaceMap, _turnSettings);

            turnGameSession.SpaceMap = new Reloading().Recalculate(turnGameSession);

            turnGameSession = new SessionEvents().Execute(turnGameSession);

            //--------------------------------------------------------------------------------------------------- End calculations

            _gameSession = GameSessionTransfer(turnGameSession, _gameSession);

            Logger.Debug($"[Server] Calculation finished {stopwatch.Elapsed.TotalMilliseconds} ms.");
        }

        private GameSession GameSessionTransfer(GameSession calculatedGameSession, GameSession gameSessionBeforeChanges)
        {
            calculatedGameSession.IsPause = gameSessionBeforeChanges.IsPause;

            return calculatedGameSession.DeepClone();
        }

        public GameSession RefreshGameSession(int id)
        {
            return _gameSession.DeepClone();
        }

        public void ResumeSession(int id)
        {
            _gameSession.IsPause = false;
            Logger.Info($"[Server][ResumeSession] Successed.");
        }

        public void PauseSession(int id)
        {
            _gameSession.IsPause = true;
            Logger.Info($"[Server][PauseSession] Successed.");
        }

        public void Command(int sessionId, int objectId, int targetCelestialObjectId, int memberId, int targetCell, int typeId)
        {
            throw new System.NotImplementedException();
        }
    }
}