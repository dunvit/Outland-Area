﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace EngineCore.Tools
{
    //[DebuggerDisplay("Count = {Count}")]
    //[DebuggerDisplay("{DebuggerDisplay(),nq}")]
    [DebuggerDisplay("{dictionary.value}", Name = "{dictionary.key}")]
    public class DictionaryWithReaderWriterLock<TKey, TValue>
    {
        private readonly ReaderWriterLockSlim dictionaryLock = new ReaderWriterLockSlim();
        private readonly Dictionary<TKey, TValue> dictionary;

        public int Count => dictionary.Count;

        public DictionaryWithReaderWriterLock()
        {
            dictionary = new Dictionary<TKey, TValue>();
        }

        public TValue this[TKey key]
        {
            get
            {
                dictionaryLock.EnterReadLock();
                try
                {
                    return dictionary[key];
                }
                finally
                {
                    dictionaryLock.ExitReadLock();
                }
            }
            set
            {
                dictionaryLock.EnterWriteLock();
                try
                {
                    dictionary[key] = value;
                }
                finally
                {
                    dictionaryLock.ExitWriteLock();
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            dictionaryLock.EnterWriteLock();
            try
            {
                dictionary.Add(key, value);
            }
            finally
            {
                dictionaryLock.ExitWriteLock();
            }
        }

        #if DEBUG
        private string DebuggerDisplay()
        {
            return
                $"ObjectId:{dictionary.Count}, StringProperty:{dictionary.Count}, Type:{GetType()}";
        }
        #endif
    }
}
