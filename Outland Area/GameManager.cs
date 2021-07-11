using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Engine.DAL;
using Engine.Tools;
using Engine.UI;
using EngineCore;
using EngineCore.Events;
using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Model;
using log4net;

namespace Engine
{
    public class GameManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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

        private int activeCelestialObjectId;
        private int selectedCelestialObjectId;

        public OuterSpace OuterSpaceTracker = new OuterSpace();

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

        public GameManager(LocalGameServer gameServer)
        {
            _gameServer = gameServer;
            _gameSession = new GameSession( _gameServer.RefreshGameSession(gameServer.SessionId) );
        }

        public Form ShowScreen(string screenName)
        {
            return UiManager.GetScreen(screenName);
        }

        public void StartNewGameSession(string scenario)
        {
            _gameSession = _gameServer.Initialization(scenario);

            UiManager.UiInitialization();

            OnStartGameSession?.Invoke(_gameSession);

            OuterSpaceTracker.OnChangeSelectedObject += Event_ChangeSelectedObject;
            OuterSpaceTracker.OnChangeActiveObject += Event_ChangeActiveObject;

            Scheduler.Instance.ScheduleTask(50, 50, GetDataFromServer, null);
        }

        private void Event_ChangeActiveObject(int celestialObjectId)
        {
            activeCelestialObjectId = celestialObjectId;
        }

        private void Event_ChangeSelectedObject(int celestialObjectId)
        {
            selectedCelestialObjectId = celestialObjectId;
        }

        public ICelestialObject GetSelectedObject()
        {
            return _gameSession.GetCelestialObject(selectedCelestialObjectId);
        }

        public ICelestialObject GetActiveObject()
        {
            return _gameSession.GetCelestialObject(activeCelestialObjectId);
        }

        public void GetDataFromServer()
        {
            var sessionData= new GameSessionRefresh().RequestGameSession(_gameServer, _gameSession.Id);

            if (sessionData == null || sessionData.IsPause) return;

            // Send to server all commands from previous turn.
            CommandsSending();

            _gameSession = new GameSession(sessionData);

            ExecuteGameEvents(_gameSession);

            OnEndTurn?.Invoke(_gameSession);
        }

        private void ExecuteGameEvents(GameSession gameSession)
        {
            var turnEvents = GetCurrentTurnEvents(gameSession);

            Logger.Debug($"[Client][{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] Loaded game events ({turnEvents.Count}) for turn N{gameSession.Turn}.");

            foreach (var message in turnEvents)
            {
                if (AcceptedEvents.Contains(message.Id))
                {
                    Logger.Debug($"[Client][{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] Event ({message.Id}) already exist in cach.");
                    continue;
                }

                Logger.Debug($"[Client][{GetType().Name}][{MethodBase.GetCurrentMethod().Name}] Event ({message.Id}) addad to cach.");
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
            }
        }

        private List<GameEvent> GetCurrentTurnEvents(GameSession gameSession)
        {
            return gameSession.Data.GameEvents.Where(_ => _.Turn + 5 > gameSession.Turn).Map(message => message).ToList();
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