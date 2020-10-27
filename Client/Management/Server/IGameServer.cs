using Engine.Layers.Tactical;

namespace Engine.Management.Server
{
    public interface IGameServer
    {
        GameSession Initialization();

        GameSession RefreshGameSession(int id);

        void ResumeSession(int id);

        void PauseSession(int id);

        void Command(int sessionId, int objectId, int targetCelestialObjectId, int memberId, int targetCell, int typeId);

        void AddCelestialObject(int sessionId, int objectId, int positionX, int positionY, int direction, int speed,
            int classification);
    }
}
