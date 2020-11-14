using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OutlandAreaCommon
{
    public static class ExtensionMethods
    {
        // Deep clone
        public static T DeepClone<T>(this T a)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }

        public static int NextInt(this Random random)
        {
            return random.Next(1000000000, int.MaxValue);
        }
    }
}
