namespace OutlandAreaCommon.Tactical
{

    public enum GameEventTypes
    {
        AnomalyFound = 200
    }

    public static class GameEventTypesExtensions
    {
        public static int ToInt(this GameEventTypes command)
        {
            return (int)command;
        }
    }
}