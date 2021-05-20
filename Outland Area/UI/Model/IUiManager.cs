using EngineCore.Session;

namespace Engine.UI.Model
{
    public interface IUiManager
    {
        void StartNewGameSession(GameSession gameSession);

        void UiInitialization();

        void Initialization();

    }
}