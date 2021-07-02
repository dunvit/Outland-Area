
namespace EngineCore.Session
{
    interface IHistory
    {
        void AddHistoryMessage(GameSession session, string message, string className = "", bool isTechnicalLog = false);
    }
}
