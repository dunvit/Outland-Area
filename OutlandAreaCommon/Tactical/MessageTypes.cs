namespace OutlandAreaCommon.Tactical
{

    public enum MessageTypes
    {
        AnomalyFound = 200
    }

    public static class MessageTypesExtensions
    {
        public static int ToInt(this MessageTypes command)
        {
            return (int)command;
        }
    }
}