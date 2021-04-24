
using System;

namespace EngineCore.Session
{
    [Serializable]
    public class HistoryMessage
    {
        public int Turn { get; set; }

        public bool IsTechnicalLog { get; set; } = false;

        public string Message { get; set; }

        public string Class { get; set; }
    }
}
