using System.Collections;
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

        public Hashtable Commands { get; set; } = new Hashtable();
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

            Logger.Info($"[Server][{GetType().Name}] Initialization finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

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

            turnGameSession.Commands = GetCommands();

            //-------------------------------------------------------------------------------------------------- Start calculations

            turnGameSession = new Commands().Execute(turnGameSession, _turnSettings);

            turnGameSession.SpaceMap = new Coordinates().Recalculate(turnGameSession.SpaceMap, _turnSettings);

            turnGameSession.SpaceMap = new Reloading().Recalculate(turnGameSession, _turnSettings);

            turnGameSession = new SessionEvents().Execute(turnGameSession);

            //--------------------------------------------------------------------------------------------------- End calculations

            DebugPlayerShipParameters(turnGameSession.DeepClone());

            _gameSession = GameSessionTransfer(turnGameSession, _gameSession);

            Logger.Debug($"[Server][{GetType().Name}][TurnCalculation] Calculation finished {stopwatch.Elapsed.TotalMilliseconds} ms.");
        }

        private void DebugPlayerShipParameters(GameSession turnGameSession)
        {
            var spacecraft = turnGameSession.GetPlayerSpaceShip();

            Logger.Debug($"[Server][{GetType().Name}][DebugPlayerShipParameters] " +
                $"Speed {spacecraft.Speed}/{spacecraft.MaxSpeed} ms. " +
                $"Location ({spacecraft.PositionX};{spacecraft.PositionY}) " +
                $"Direction {spacecraft.Direction} degree.");
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
            Logger.Info($"[Server][{GetType().Name}][ResumeSession] Successed.");
        }

        public void PauseSession(int id)
        {
            _gameSession.IsPause = true;
            Logger.Info($"[Server][{GetType().Name}][PauseSession] Successed.");
        }

        public void Command(int sessionId, string commandBody)
        {
            var typeId = (int)JObject.Parse(commandBody)["TypeId"];

            Logger.Debug($"[Server][{GetType().Name}][Command] Add command sessionId={sessionId} typeId={typeId} body={commandBody}");

            var command = new Command(commandBody);

            var commandKey = sessionId + "_" + command.CelestialObjectId + "_" + command.Type;

            if (Commands.ContainsKey(commandKey))
            {
                Logger.Debug($"[Server][{GetType().Name}][Command] Command sessionId={sessionId} typeId={typeId} already added to turn commands.");
                return;
            }

            lock (Commands)
            {
                 Commands.Add(commandKey,  command);
            }                
        }

        private Hashtable GetCommands()
        {
            Hashtable result;

            lock (Commands)
            {
                result = Commands.DeepClone();

                foreach (Command command in Commands.Values)
                {
                    CommandsHistory.Add(command.DeepClone());
                }

                Commands = new Hashtable();

                Logger.Debug($"[Server][{GetType().Name}][GetCommands]\t Finished clear turn commands. Cpunt is {result.Count}");
            }

            return result;
        }

        public List<Command> GetHistoryCommands(int sessionId, long Id)
        {
            return CommandsHistory.Where(_ => _.CelestialObjectId == Id).ToList();
        }
    }
}