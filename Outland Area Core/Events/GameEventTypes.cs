namespace EngineCore.Events
{

    public enum GameEventTypes
    {
        AnomalyFound = 200,
        OpenDialog = 300,
        NpcSpaceShipFound = 210
    }

    public static class GameEventTypesExtensions
    {
        public static int ToInt(this GameEventTypes command)
        {
            return (int)command;
        }
    }
}