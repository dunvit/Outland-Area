
namespace OutlandArea.TacticalBattleLayer
{
    public interface ICommand
    {
        long PilotID { get; }
        string Image { get; }
        string Description { get;}

        long SpacecraftId { get; set; }
        int TimePointCost { get; }
        int SuccessChance { get; }
    }
}
