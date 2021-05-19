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
        public event Action<GameSession> OnInitializationFinish;
        public event Action<GameEvent, GameSession> OnFoundSpaceship;

        public List<string> AcceptedEvents = new List<string>();

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

            UiManager.StartNewGameSession();

            //_gameSession = Initialization();

            //OnBattleInitialization?.Invoke(_gameSession.DeepClone());
            OnStartGameSession?.Invoke(_gameSession.DeepClone());

            Scheduler.Instance.ScheduleTask(50, 50, GetDataFromServer, null);

            //_gameServer.ResumeSession(_gameSession.Id);
        }

        private void GetDataFromServer()
        {
            var timeMetricGetGameSession = Stopwatch.StartNew();

            var gameSession = _gameServer.RefreshGameSession(_gameSession.Id);

            if (gameSession != null)
            {
                _gameSession = gameSession;

                var turnEvents = gameSession.GetCurrentTurnEvents();

                Logger.Info($"Loaded game events ({turnEvents.Count}) for turn N{_gameSession.Turn}.");

                if(turnEvents.Count > 0)
                {
                    var a = "";
                }

                foreach (var message in turnEvents)
                {
                    if (AcceptedEvents.Contains(message.Id))
                    {
                        Logger.Info($"Event ({message.Id}) already exist in cach.");
                        continue;
                    }

                    Logger.Info($"Event ({message.Id}) addad to cach.");
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
                        OnFoundSpaceship?.Invoke(message, gameSession);
                    }

                    
                }

                OnEndTurn?.Invoke(_gameSession.DeepClone());
            }
            else
            {
                Logger.Error($"Critical error on refresh game id={_gameSession.Id}.");
                return;
            }

            timeMetricGetGameSession.Stop();

            Logger.Debug($"Turn [{_gameSession.Turn}] Get data from server is finished {timeMetricGetGameSession.Elapsed.TotalMilliseconds} ms.");

            //Logger.Debug($"GetInteger game session parsing finished for {timeMetricGetGameSession.Elapsed.TotalMilliseconds}. " +
            //             $"Game session id = {_gameSession.Id}." +
            //             $" Turn = {_gameSession.Turn}." +
            //             $" SpaceMap objects count is {_gameSession.SpaceMap.CelestialObjects.Count}.");
        }

        public void SessionResume()
        {
            Logger.Info($"Game resumed. Turn is {_gameSession.Turn}");
            _gameServer.ResumeSession(_gameSession.Id);
        }

        public void SessionPause()
        {
            Logger.Info($"Game paused. Turn is {_gameSession.Turn}");
            _gameServer.PauseSession(_gameSession.Id);
        }

        public void InitializationFinish()
        {
            OnInitializationFinish?.Invoke(_gameSession);
        }

        public void EventActivateModule(int id)
        {
            OnSelectModule?.Invoke(id);
        }
    }
}