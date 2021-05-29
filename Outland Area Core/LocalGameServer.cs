using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EngineCore.DataProcessing;
using EngineCore.Session;
using EngineCore.Tools;
using log4net;
using Newtonsoft.Json.Linq;

namespace EngineCore
{
    public class LocalGameServer : IGameServer
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private GameSession _gameSession;

        public List<Command> Commands { get; set; } = new List<Command>();
        public List<Command> CommandsHistory { get; set; } = new List<Command>();

        private TurnSettings _turnSettings;

        public int SessionId { get; private set; }

        public GameSession Initialization(string scenario)
        {
            var stopwatch = Stopwatch.StartNew();

            _turnSettings = new TurnSettings();

            _gameSession = ScenarioConvertor.LoadGameSession(scenario);

            _gameSession.IsPause = true;

            Scheduler.Instance.ScheduleTask(50, 50, ExecuteTurnCalculation, null);

            Logger.Info($"Initialization finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            // TODO: Get session ID in scenarion file
            SessionId = 0;

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

        public void TurnCalculation(int turnsCount)
        {
            for(var i = 0; i< turnsCount; i++)
            {
                TurnCalculation();
            }
        }

        public void TurnCalculation()
        {
            var stopwatch = Stopwatch.StartNew();

            _gameSession.Turn++;

            var turnGameSession = _gameSession.DeepClone();

            lock(Commands)
            {
                turnGameSession.Commands = Commands.DeepClone();

                foreach (var command in Commands)
                {
                    CommandsHistory.Add(command.DeepClone());
                }

                Commands = new List<Command>();
            }            

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
            return Convert.ToClient(_gameSession.DeepClone());
        }

        public GameSession GetCurrentGameSession(int id)
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

        public void Command(int sessionId, string command)
        {
            var typeId = (int)JObject.Parse(command)["TypeId"];

            Logger.Debug($"[{GetType().Name}]\t Add command sessionId={sessionId} typeId={typeId} body={command}");

            Commands.Add(new Command(command));
        }

        public List<Command> GetCommands(long Id)
        {
            var a = CommandsHistory.Where(_ => _.CelestialObjectId == Id).ToList();

            return CommandsHistory.Where(_ => _.CelestialObjectId == Id).ToList();
        }
    }
}