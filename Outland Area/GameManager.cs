using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Engine.DAL;
using Engine.Layers.Tactical;
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
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IGameServer _gameServer;

        public UiManager UiManager { get; set; }

        public TacticalEnvironment Environment { get;}

        public event Action<TacticalEnvironment> OnEndTurn;
        public event Action<TacticalEnvironment> OnStartGameSession;
        public event Action<int> OnSelectModule;
        public event Action<int, int> OnCancelModuleAction;
        public event Action<TacticalEnvironment> OnInitializationFinish;

        public List<string> AcceptedEvents = new List<string>();
        public List<Command> Commands { get; set; } = new List<Command>();

        public GameManager()
        {
            Environment = new TacticalEnvironment();

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

        public GameManager(LocalGameServer gameServer)
        {
            Environment = new TacticalEnvironment();

            _gameServer = gameServer;
            var gameSession = new GameSession( _gameServer.RefreshGameSession(gameServer.SessionId) );

            Environment.RefreshGameSession(gameSession);
        }

        public void ShowScreen(string screenName)
        {
            UiManager.OpenScreen(screenName, Environment);
        }

        public Form GetScreen(string screenName)
        {
            return UiManager.GetScreen(screenName);
        }

        public void StartNewGameSession(string scenario)
        {
            var _gameSession = _gameServer.Initialization(scenario);

            Environment.RefreshGameSession(_gameSession);

            UiManager.UiInitialization();

            OnStartGameSession?.Invoke(Environment);

            Scheduler.Instance.ScheduleTask(50, 50, GetDataFromServer, null);
        }

        private bool _inProgress;

        public void GetDataFromServer()
        {
            if (_inProgress) return;

            _inProgress = true;

            var sessionData= new GameSessionRefresh().RequestGameSession(_gameServer, Environment.Session.Id);

            Logger.Info($"sessionData {sessionData.Turn} = {sessionData.CelestialObjects.Count} - {sessionData.GameEvents.Count}.");

            var gameSession = new GameSession(sessionData);

            Environment.RefreshGameSession(gameSession);

            OnEndTurn?.Invoke(Environment);

            if (sessionData.IsPause)
            {
                _inProgress = false;
                return;
            }

            // Send to server all commands from previous turn.
            CommandsSending();

            Logger.Info($"sessionData {Environment.Session.Turn} = {Environment.Session.CelestialObjects.Count} - {Environment.Session.GameEvents.Count}.");

            ExecuteGameEvents(Environment.Session);

            _inProgress = false;
        }

        private void ExecuteGameEvents(GameSession gameSession)
        {
            var turnEvents = GetCurrentTurnEvents(gameSession);

            Logger.Debug($"Loaded game events ({turnEvents.Count}) for turn N{gameSession.Turn}.");

            foreach (var message in turnEvents)
            {
                if (AcceptedEvents.Contains(message.Id))
                {
                    Logger.Debug($"Event ({message.Id}) already exist in cach.");
                    continue;
                }

                Logger.Debug($"Event ({message.Id}) addad to cach.");
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

                if (message.Type == GameEventTypes.WreckSpaceShipFound)
                {
                    //OnFoundSpaceship?.Invoke(message, gameSession);
                    UiManager.OpenGameGenericEventScreen(message, gameSession);
                }

                if (message.Type == GameEventTypes.ExplosionResult)
                {
                    //OnFoundSpaceship?.Invoke(message, gameSession);
                    UiManager.OpenExplosionResultScreen(message, gameSession);
                }
            }
        }

        private List<GameEvent> GetCurrentTurnEvents(GameSession gameSession)
        {
            return gameSession.GameEvents.Where(_ => _.Turn + 5 > gameSession.Turn).Map(message => message).ToList();
        }

        public void SessionResume()
        {
            Logger.Info($"Game resumed. Turn is {Environment.Session.Turn}");
            _gameServer.ResumeSession(Environment.Session.Id);
        }

        public void SessionPause()
        {
            Logger.Info($"Game paused. Turn is {Environment.Session.Turn}");
            _gameServer.PauseSession(Environment.Session.Id);
        }

        public void InitializationFinish()
        {
            UiManager.StartNewGameSession(Environment.Session);
            OnInitializationFinish?.Invoke(Environment);

            SessionResume();
        }

        public void EventActivateModule(int id)
        {
            OnSelectModule?.Invoke(id);
        }

        public void EventCancelModuleAction()
        {
            OnCancelModuleAction?.Invoke(Environment.Action.ModuleId, Environment.Action.ActionId);
            Environment.CancelAction();
        }

        public void ExecuteCommand(Command command)
        {
            Logger.Debug($"Command ({command.Type}) received.");

            try
            {
                lock (_commandsLock)
                {
                    Commands.Add(command);
                }
            }
            catch (Exception)
            {
                Logger.Error($"Command ({command.Type}) failed.");
            }
        }


        readonly object _commandsLock = new object();

        private void CommandsSending()
        {
            lock (_commandsLock)
            {
                foreach (var command in Commands)
                {
                    Logger.Debug($"Send command ({command.Type}) for turn '{Environment.Session.Turn}' to server.");
                    _gameServer.Command(Environment.Session.Id, command.Body);
                }

                Commands = new List<Command>();
            }
        }
    }
}