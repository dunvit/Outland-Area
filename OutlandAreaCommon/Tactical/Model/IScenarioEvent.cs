
namespace OutlandAreaCommon.Tactical.Model
{
    public interface IScenarioEvent
    {
        int Id { get; set; }
        int Scene { get; set; }

        int Turn { get; set; }

        bool IsEnabled { get; set; }

        GameEventTypes Type { get; set; }

        void Execute(GameSession session);
    }
}
