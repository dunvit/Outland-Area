using OutlandAreaCommon.Equipment;

namespace Engine.Gui
{
    public interface IUiManager
    {
        void StartNewGameSession();

        void Initialization();

        void ConnectClosestObjects(IModule module);
    }
}