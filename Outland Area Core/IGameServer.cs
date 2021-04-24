﻿using EngineCore.Session;

namespace EngineCore
{
    public interface IGameServer
    {
        GameSession Initialization(string scenario);

        GameSession RefreshGameSession(int id);

        void ResumeSession(int id);

        void PauseSession(int id);

        void Command(int sessionId, int objectId, int targetCelestialObjectId, int memberId, int targetCell, int typeId);

    }
}
