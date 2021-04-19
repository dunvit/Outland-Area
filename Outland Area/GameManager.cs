using System.Windows.Forms;
using Engine.UI;
using Engine.UI.Screens;
using EngineCore;

namespace Engine
{
    public class GameManager
    {
        private readonly IGameServer _gameServer;

        public static UiManager UiManager;

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
            UiManager.StartNewGameSession();

            //_gameSession = Initialization();

            //OnBattleInitialization?.Invoke(_gameSession.DeepClone());
            //OnEndTurn?.Invoke(_gameSession.DeepClone());
        }
    }
}