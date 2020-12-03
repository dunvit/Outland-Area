using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace OutlandAreaCommon.Common
{
    public class FixedSizedQueue<T>
    {
        ConcurrentQueue<T> q = new ConcurrentQueue<T>();
        private object lockObject = new object();

        public int Limit { get; set; }

        public FixedSizedQueue(int limit)
        {
            Limit = limit;
        }

        public void Enqueue(T obj)
        {
            q.Enqueue(obj);
            lock (lockObject)
            {
                T overflow;
                while (q.Count > Limit && q.TryDequeue(out overflow)) ;
            }
        }

        public List<T> GetData()
        {
            return q.ToList().DeepClone();
        }
    }
}
