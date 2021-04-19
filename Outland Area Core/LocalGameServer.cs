namespace EngineCore
{
    public class LocalGameServer : IGameServer
    {
        public GameSession Initialization(string scenario)
        {
            throw new System.NotImplementedException();
        }

        public GameSession RefreshGameSession(int id)
        {
            throw new System.NotImplementedException();
        }

        public void ResumeSession(int id)
        {
            throw new System.NotImplementedException();
        }

        public void PauseSession(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Command(int sessionId, int objectId, int targetCelestialObjectId, int memberId, int targetCell, int typeId)
        {
            throw new System.NotImplementedException();
        }
    }
}