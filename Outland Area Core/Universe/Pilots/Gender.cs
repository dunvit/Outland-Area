
namespace EngineCore.Universe.Pilots
{
    public enum Gender
    {
        Male = 1, 
        Female = 0,
        NotDetermined = 2
    }

    public static class GenderExtensions
    {
        public static Gender ToGender(this int value)
        {
            return (Gender)value;
        }
    }
}
