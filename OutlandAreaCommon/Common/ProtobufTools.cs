using System;
using System.IO;
using System.Reflection;
using log4net;
using ProtoBuf;

namespace OutlandAreaCommon.Common
{
    /// <summary>
    /// Using:
    /// Class or collection of ProtoContract objects
    /// var dataAfterSerialize      = ProtobufTools.Serialize(data);
    /// var stringAfterDeserialize  = ProtobufTools.Deserialize<List<ObjectType>>(dataAfterSerialize);
    /// </summary>

    public class ProtobufTools
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static byte[] Serialize<T>(T record) where T : class
        {
            if (null == record) return null;


            try
            {
                using var stream = new MemoryStream();
                Serializer.Serialize(stream, record);

                return stream.ToArray();
            }
            catch (Exception e)
            {
                Logger.Error($"[ProtobufTools.Serialize] Critical error. GameEvent is {e.Message}");
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
            catch (Exception e)
            {
                Logger.Error($"[ProtobufTools.Deserialize] Critical error. GameEvent is {e.Message}");
                throw;
            }
        }
    }
}
