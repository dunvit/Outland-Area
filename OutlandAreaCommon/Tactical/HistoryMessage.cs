
using System;

namespace OutlandAreaCommon.Tactical
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
