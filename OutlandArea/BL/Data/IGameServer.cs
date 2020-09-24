using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandArea.BL.Data
{
    public interface IGameServer
    {
        GameSession Initialization();

        GameSession RefreshGameSession(int id);

        void ResumeSession(int id);

        void PauseSession(int id);

        /// <summary>
        /// gameSessionID, spaceshipID, moduleID, personID
        /// </summary>
        /// <param name="id"></param>
        void Command(int id, int spaceshipId, int moduleId, int personId);
    }
}
