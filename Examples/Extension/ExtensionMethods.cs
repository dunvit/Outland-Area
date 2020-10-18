
namespace Engine.Examples.Extension
{
    public static class ExtensionMethods
    {
        public static bool ReturnSuccess<TInput>(this TInput o) where TInput : class
        {
            return o != null;
        }
    }

    public class Car
    {
        public InternalEngine Engine { get; set; }
    }

    public class InternalEngine
    {
        public int Power { get; set; }

        public string Name { get; set; }
    }
}
