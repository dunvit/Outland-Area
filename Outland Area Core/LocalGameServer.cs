using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using EngineCore.DataProcessing;
using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Objects;
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

        private EngineSettings _turnSettings = new EngineSettings();

        public int SessionId { get; private set; }

        private readonly ReaderWriterLockSlim dictionaryLock = new ReaderWriterLockSlim();

        public GameSession Initialization(string scenario, EngineSettings turnSettings, bool isActive = true)
        {
            _turnSettings = turnSettings;

            return Initialization(scenario, isActive);
        }

        public GameSession Initialization(string scenario, bool isActive = true)
        {
            var stopwatch = Stopwatch.StartNew();

            _gameSession = ScenarioConvertor.LoadGameSession(scenario);

            _gameSession.Pause();

            if(isActive)
                Scheduler.Instance.ScheduleTask(50, 50, ExecuteTurnCalculation, null);

            Logger.Info($"[Server][{GetType().Name}] Initialization finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return _gameSession;
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

        public void Wait(int seconds)
        {
            TurnCalculation(seconds * _turnSettings.UnitsPerSecond);
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
            dictionaryLock.EnterWriteLock();
            
            var stopwatch = Stopwatch.StartNew();

            //_gameSession.NextTurn();

            var turnGameSession = new GameSession(_gameSession.Data.DeepClone());
            // TODO: Refactor it
            turnGameSession.Id = _gameSession.Id;
            turnGameSession.ScenarioEvents = _gameSession.ScenarioEvents.DeepClone();

            

            turnGameSession.Commands = GetCommands(_gameSession);

            //-------------------------------------------------------------------------------------------------- Start calculations

            turnGameSession = new Commands().Execute(turnGameSession, _turnSettings);

            turnGameSession = new Coordinates().Recalculate(turnGameSession, _turnSettings);

            turnGameSession = new Reloading().Recalculate(turnGameSession, _turnSettings);

            turnGameSession = new SessionEvents().Execute(turnGameSession);

            turnGameSession.NextTurn();

            //--------------------------------------------------------------------------------------------------- End calculations

            DebugPlayerShipParameters(turnGameSession);

            _gameSession = GameSessionTransfer(turnGameSession, _gameSession);

            Logger.Info($"[Server][{GetType().Name}][TurnCalculation] Turn {_gameSession.Turn}/{turnGameSession.Turn} Calculation finished {stopwatch.Elapsed.TotalMilliseconds} ms.");            

            dictionaryLock.ExitWriteLock();
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
            if (gameSessionBeforeChanges.IsPause)
                calculatedGameSession.Pause();
            else
                calculatedGameSession.Resume();

            calculatedGameSession.Data.IsPause = gameSessionBeforeChanges.IsPause;
            calculatedGameSession.Data.ScenarioName = gameSessionBeforeChanges.Data.ScenarioName;

            return calculatedGameSession;
        }

        public SessionDTO RefreshGameSession(int id)
        {
            return Convert.ToClient(_gameSession);
        }

        public GameSession RefreshGameSessionServerSide(int id)
        {
            return _gameSession;
        }

        public void ResumeSession(int id)
        {
            _gameSession.Resume();
            Logger.Info($"[Server][{GetType().Name}][ResumeSession] Successed.");
        }

        public void PauseSession(int id)
        {
            _gameSession.Pause();
            Logger.Info($"[Server][{GetType().Name}][PauseSession] Successed.");
        }

        /// <summary>
        /// Only for integration tests
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="commandBody"></param>
        /// <param name="isAlwaysSuccessful"></param>
        public void Command(int sessionId, string commandBody)
        {
            var typeId = (int)JObject.Parse(commandBody)["TypeId"];

            Logger.Debug($"[Server][{GetType().Name}][Command] Add command sessionId={sessionId} typeId={typeId} body={commandBody}");

            var command = new Command(commandBody);

            var jObject = JObject.Parse(command.Body);
            var moduleId = int.Parse(jObject["ModuleId"].ToString());
            var module = _gameSession.GetCelestialObject(command.CelestialObjectId).ToSpaceship().GetModule(moduleId);

            if (module.Reloading < module.ReloadTime && debugSettings.IsIgnoreReload == false)
            {
                Logger.Info($"[{GetType().Name}][Execution] Module {module.Name} still on reloading. " +
                            $"Progress {module.Reloading}/{module.ReloadTime} .");

                return;
            }

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

        private Hashtable GetCommands(GameSession gameSession)
        {
            // TODO: Split for two functions 1. - Get commands from API 2. Get unfinished commands
            Hashtable result;

            Logger.Info($"[Server][{GetType().Name}][GetCommands]\t Turn {gameSession.Turn}. Commands count is {gameSession.Commands.Count}");


            lock (Commands)
            {
                result = Commands.DeepClone();

                foreach (Command command in Commands.Values)
                {
                    CommandsHistory.Add(command.DeepClone());
                }

                Commands = new Hashtable();

                foreach (Command command in gameSession.Commands.Values)
                {
                    if (command.UntilTurnId <= gameSession.Turn) continue;

                    var commandKey = gameSession.Id + "_" + command.CelestialObjectId + "_" + command.Type;

                    Logger.Info($"[Server][{GetType().Name}][GetCommands]\t Turn {gameSession.Turn} resume command execution. {command.Type}");

                    result.Add(commandKey, command);
                }

                Logger.Debug($"[Server][{GetType().Name}][GetCommands]\t Finished clear turn commands. Count is {result.Count}");
            }

            return result;
        }

        public List<Command> GetHistoryCommands(int sessionId, long Id)
        {
            return CommandsHistory.Where(_ => _.CelestialObjectId == Id).ToList();
        }

        private IDebugProperties debugSettings = new EmptyDebugProperties();
        public void EnableDebugMode()
        {
            debugSettings = new DebugProperties(true, true);
        }
    }
}