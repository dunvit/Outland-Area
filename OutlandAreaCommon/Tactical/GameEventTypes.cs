namespace OutlandAreaCommon.Tactical
{

    public enum GameEventTypes
    {
        AnomalyFound = 200,
        OpenDialog = 300
    }

    public static class GameEventTypesExtensions
    {
        public static int ToInt(this GameEventTypes command)
        {
            return (int)command;
        }
    }
}