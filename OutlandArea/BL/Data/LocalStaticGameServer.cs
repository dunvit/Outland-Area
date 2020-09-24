using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutlandAreaLogic.Configuration;

namespace OutlandArea.BL.Data
{
    public class LocalStaticGameServer: IGameServer
    {
        private GameSession _gameSession;

        public GameSession Initialization()
        {
            _gameSession = Convertor.ToGameSession(Convertor.GetSavedMap("Map_003"));

            return _gameSession;
        }

        public GameSession RefreshGameSession(int id)
        {
            return _gameSession;
        }

        public void ResumeSession(int id)
        {
            _gameSession.Map.IsEnabled = true;
        }

        public void PauseSession(int id)
        {
            _gameSession.Map.IsEnabled = false;
        }

        public void Command(int id, int spaceshipId, int moduleId, int personId)
        {
            
        }
    }
}
