using System;
using System.Globalization;

namespace EngineCore.Events
{
    [Serializable]
    public class GameEventParameter
    {
        public GameEventParameterTypes Type { get; }

        public string Value { get; }

        public GameEventParameter(GameEventParameterTypes type, string value)
        {
            Type = type;
            Value = value;
        }

        public GameEventParameter(GameEventParameterTypes type, int value): this(type, value.ToString()){}

        public GameEventParameter(GameEventParameterTypes type, float value) : this(type, value.ToString(CultureInfo.InvariantCulture)) { }

        public GameEventParameter(GameEventParameterTypes type, double value) : this(type, value.ToString(CultureInfo.InvariantCulture)) { }
    }
}
