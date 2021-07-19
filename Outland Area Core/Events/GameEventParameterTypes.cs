
namespace EngineCore.Events
{
    public enum GameEventParameterTypes
    {
        TargetId = 1,
        ModuleId = 2,
        ActionId = 3,
        Dice = 4,
        Damage = 5,
        Chance = 6,
        OwnerId = 7,
        Result = 8,
        CelestialObjectId = 9
    }

    public static class ParameterTypesExtensions
    {
        public static int ToInt(this GameEventParameterTypes parameter)
        {
            return (int)parameter;
        }
    }
}
