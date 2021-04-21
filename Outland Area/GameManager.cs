using System;
using System.Diagnostics;
using System.Windows.Forms;
using Engine.UI;
using Engine.UI.Screens;
using EngineCore;
using EngineCore.Tools;
using log4net;
using log4net.Repository.Hierarchy;

namespace Engine
{
    public class GameManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IGameServer _gameServer;
        private GameSession _gameSession;
        public static UiManager UiManager;

        public event Action<GameSession> OnEndTurn;

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

            UiManager = new UiManager();

            
        }

        public Form ShowScreen(string screenName)
        {
            return UiManager.GetScreen(screenName);
        }

        public void StartNewGameSession()
        {
            _gameSession = _gameServer.Initialization("");

            UiManager.StartNewGameSession();

            //_gameSession = Initialization();

            //OnBattleInitialization?.Invoke(_gameSession.DeepClone());
            OnEndTurn?.Invoke(_gameSession.DeepClone());

            Scheduler.Instance.ScheduleTask(50, 50, GetDataFromServer, null);

            _gameServer.ResumeSession(0);
        }

        private void GetDataFromServer()
        {
            var timeMetricGetGameSession = Stopwatch.StartNew();

            var gameSession = _gameServer.RefreshGameSession(_gameSession.Id);

            if (gameSession != null)
            {
                _gameSession = gameSession;
            }
            else
            {
                Logger.Error($"Critical error on refresh game id={_gameSession.Id}.");
                return;
            }

            timeMetricGetGameSession.Stop();

            Logger.Info($"Turn [{_gameSession.Turn}] Get data from server is finished {timeMetricGetGameSession.Elapsed.TotalMilliseconds} ms.");

            //Logger.Debug($"GetInteger game session parsing finished for {timeMetricGetGameSession.Elapsed.TotalMilliseconds}. " +
            //             $"Game session id = {_gameSession.Id}." +
            //             $" Turn = {_gameSession.Turn}." +
            //             $" SpaceMap objects count is {_gameSession.SpaceMap.CelestialObjects.Count}.");
        }
    }
}