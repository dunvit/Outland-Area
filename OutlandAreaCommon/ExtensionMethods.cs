﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using LanguageExt;
using OutlandAreaCommon.Universe;

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

        

        
    }
}
