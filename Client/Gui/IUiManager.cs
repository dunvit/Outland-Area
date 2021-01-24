using System.Collections.Generic;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;

namespace Engine.Gui
{
    public interface IUiManager
    {
        void StartNewGameSession();

        void Initialization();

        void ConnectClosestObjects(GameSession gameSession, IModule module, IEnumerable<ICelestialObject> objects,
            bool show);
    }
}