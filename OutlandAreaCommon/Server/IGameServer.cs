﻿using OutlandAreaCommon.Tactical;

namespace OutlandAreaCommon.Server
{
    public interface IGameServer
    {
        GameSession Initialization();

        GameSession RefreshGameSession(int id);

        void ResumeSession(int id);

        void PauseSession(int id);

        void Command(int sessionId, int objectId, int targetCelestialObjectId, int memberId, int targetCell, int typeId);

        void AddCelestialObject(int sessionId, int objectId, float positionX, float positionY, int direction, int speed,
            int classification, string name);

        void AddCelestialObject(int sessionId, int objectId, float positionX, float positionY, int direction, int speed,
            int classification, string name, int ammoId, int moduleId, int shipOwnerId);
    }
}
