namespace OutlandAreaCommon.Universe
{
    public enum CommandTypes
    {
        MoveForward = 200,
        Fire = 300,
        AlignTo = 100,
        Orbit = 110,
        Explosion = 800,
        ReloadWeapon = 900
    }

    public static class CommandTypesExtensions
    {
        public static int ToInt(this CommandTypes command)
        {
            return (int)command;
        }
    }
}