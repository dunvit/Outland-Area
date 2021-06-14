using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Engine.UI;
using EngineCore;
using EngineCore.Events;
using EngineCore.Session;
using EngineCore.Tools;
using log4net;

namespace Engine
{
    public class GameManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IGameServer _gameServer;
        private GameSession _gameSession;
        public UiManager UiManager { get; set; }

        public event Action<GameSession> OnEndTurn;
        public event Action<GameSession> OnStartGameSession;
        public event Action<int> OnSelectModule;
        public event Action<int> OnCancelModule;
        public event Action<GameSession> OnInitializationFinish;

        public List<string> AcceptedEvents = new List<string>();

        public List<Command> Commands { get; set; } = new List<Command>();

        public GameManager()
        {
            switch (Global.ApplicationSettings.ServerType)
            {
                case 1:
                    //_gameServer = new ScalaGameServer(_applicationSettings, null);
                    break;
                case 2:
                    //_gameServer = new LocalStaticGameServer();
                    break;

                case 3:
                    _gameServer = new LocalGameServer();
                    break;
            }
        }

        public Form ShowScreen(string screenName)
        {
            return UiManager.GetScreen(screenName);
        }

        public void StartNewGameSession(string scenario)
        {
            _gameSession = _gameServer.Initialization(scenario);

            UiManager.UiInitialization();

            OnStartGameSession?.Invoke(_gameSession.DeepClone());

            Scheduler.Instance.ScheduleTask(50, 50, GetDataFromServer, null);
        }

        private void GetDataFromServer()
        {
            var timeMetricGetGameSession = Stopwatch.StartNew();

            var gameSession = _gameServer.RefreshGameSession(_gameSession.Id);

            if(gameSession.IsPause)
            {
                Logger.Debug($"[Client][{GetType().Name}][GetDataFromServer] Pause game. Turn is ({gameSession.Turn}).");
                return;
            }

            // Send to server all commands from previous turn.
            CommandsSending();

            if (gameSession != null)
            {
                _gameSession = gameSession;

                var turnEvents = gameSession.GetCurrentTurnEvents();

                Logger.Debug($"[Client][{GetType().Name}][GetDataFromServer] Loaded game events ({turnEvents.Count}) for turn N{_gameSession.Turn}.");

                foreach (var message in turnEvents)
                {
                    if (AcceptedEvents.Contains(message.Id))
                    {
                        Logger.Debug($"[Client][{GetType().Name}][GetDataFromServer] Event ({message.Id}) already exist in cach.");
                        continue;
                    }

                    Logger.Debug($"[Client][{GetType().Name}][GetDataFromServer] Event ({message.Id}) addad to cach.");
                    AcceptedEvents.Add(message.Id);

                    if (message.IsPause) SessionPause();

                    if (message.Type == GameEventTypes.AnomalyFound)
                    {
                        //OnAnomalyFound?.Invoke(message, gameSession);
                    }

                    if (message.Type == GameEventTypes.OpenDialog)
                    {
                        //OnOpenDialog?.Invoke(message, gameSession);
                    }

                    // TODO: LAST - ADD NpcSpaceShipFound logic to Container and open window with message
                    if (message.Type == GameEventTypes.NpcSpaceShipFound)
                    {
                        //OnFoundSpaceship?.Invoke(message, gameSession);
                        UiManager.OpenGameEventScreen(message, gameSession);
                    }
                }

                OnEndTurn?.Invoke(_gameSession.DeepClone());
            }
            else
            {
                Logger.Error($"[Client][{GetType().Name}][GetDataFromServer] Critical error on refresh game id={_gameSession.Id}.");
                return;
            }

            timeMetricGetGameSession.Stop();

            Logger.Debug($"[Client][{GetType().Name}][GetDataFromServer] Turn [{_gameSession.Turn}] Get data from server is finished {timeMetricGetGameSession.Elapsed.TotalMilliseconds} ms.");
        }

        public void SessionResume()
        {
            Logger.Info($"[Client][{GetType().Name}][SessionResume] Game resumed. Turn is {_gameSession.Turn}");
            _gameServer.ResumeSession(_gameSession.Id);
        }

        public void SessionPause()
        {
            Logger.Info($"[Client][{GetType().Name}][SessionPause] Game paused. Turn is {_gameSession.Turn}");
            _gameServer.PauseSession(_gameSession.Id);
        }

        public void InitializationFinish()
        {
            UiManager.StartNewGameSession(_gameSession);
            OnInitializationFinish?.Invoke(_gameSession);

            SessionResume();
        }

        public void EventActivateModule(int id)
        {
            OnSelectModule?.Invoke(id);
        }

        public void EventCancelModule(int id)
        {
            OnCancelModule?.Invoke(id);
        }

        public void ExecuteCommand(Command command)
        {
            Logger.Debug($"[Client][{GetType().Name}][ExecuteCommand] Command ({command.Type}) received.");

            try
            {
                lock (commandsLock)
                {
                    Commands.Add(command);
                }
            }
            catch (Exception)
            {
                Logger.Error($"[Client][{GetType().Name}][ExecuteCommand] Command ({command.Type}) failed.");
            }
            
        }

        object commandsLock = new object();

        private void CommandsSending()
        {
            lock (commandsLock)
            {
                foreach (var command in Commands)
                {
                    Logger.Debug($"[Client][{GetType().Name}][CommandsSending] Send command ({command.Type}) for turn '{_gameSession.Turn}' to server.");
                    _gameServer.Command(_gameSession.Id, command.Body);
                }

                Commands = new List<Command>();
            }
        }
    }
}