
namespace OutlandArea.TacticalBattleLayer.Commands
{
    class Navigation: ICommand
    {
        public string Description { get; }
        public long SpacecraftId { get; set; }
        public int TimePointCost { get; }
        public int SuccessChance { get; }

        public Navigation(long spacecraftId, string description, int timePointCost, int successChance)
        {
            SpacecraftId = spacecraftId;
            TimePointCost = timePointCost;
            Description = description;
            SuccessChance = successChance;
        }
    }
}
