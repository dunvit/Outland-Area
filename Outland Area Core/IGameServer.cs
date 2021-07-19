using EngineCore.DTO;
using EngineCore.Session;

namespace EngineCore
{
    public interface IGameServer
    {
        GameSession Initialization(string scenario, bool isActive = true);

        SessionDataDto RefreshGameSession(int id);

        void ResumeSession(int id);

        void PauseSession(int id);

        void Command(int sessionId, string command);

    }
}
