using System.IO;
using ProtoBuf;

namespace OutlandAreaCommon.Common
{
    /// <summary>
    /// Using:
    /// Class or collection of ProtoContract objects
    /// var dataAfterSerialize      = ProtobufTools.Serialize(data);
    /// var stringAfterDeserialize  = ProtobufTools.Deserialize<List<Pilot>>(dataAfterSerialize);
    /// </summary>

    public class ProtobufTools
    {
        public static byte[] Serialize<T>(T record) where T : class
        {
            if (null == record) return null;

            try
            {
                using var stream = new MemoryStream();
                Serializer.Serialize(stream, record);

                return stream.ToArray();
            }
            catch
            {
                // Log error
                throw;
            }


        }

        public static T Deserialize<T>(byte[] data) where T : class
        {
            if (null == data) return null;

            try
            {
                using var stream = new MemoryStream(data);

                return Serializer.Deserialize<T>(stream);
            }
            catch
            {
                // Log error
                throw;
            }
        }
    }
}
