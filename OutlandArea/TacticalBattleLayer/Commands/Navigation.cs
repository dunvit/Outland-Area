
namespace OutlandArea.TacticalBattleLayer.Commands
{
    class Navigation: ICommand
    {
        public long PilotID { get; }
        public string Image { get; }
        public string Description { get; }
        public long SpacecraftId { get; set; }
        public int TimePointCost { get; }
        public int SuccessChance { get; }

        public NavigationChanges Request { get; }

        public Navigation(long spacecraftId, long pilotId, string description, int timePointCost, int successChance, string image, NavigationChanges request)
        {
            SpacecraftId = spacecraftId;
            TimePointCost = timePointCost;
            Description = description;
            SuccessChance = successChance;
            PilotID = pilotId;
            Image = image;

            Request = request;
        }
    }
}
