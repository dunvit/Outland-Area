

namespace OutlandArea.TacticalBattleLayer
{
    public interface IBattleManager
    {
        Manager Manager { get; }

        void Activate(Manager manager);
    }
}
