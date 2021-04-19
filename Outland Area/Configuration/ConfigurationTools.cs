using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Engine.Configuration
{
    public static class Tools
    {
        public static string GetConfigOptionalStringValue(string keyName, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(keyName)) return defaultValue;

            if (ConfigurationManager.AppSettings.Get(keyName) != null)
                return ConfigurationManager.AppSettings[keyName];

            return defaultValue;
        }

        public static int GetConfigOptionalIntValue(string keyName, string section, int defaultValue = 0)
        {
            if (string.IsNullOrWhiteSpace(keyName)) return defaultValue;

            if (!(ConfigurationManager.GetSection(section) is NameValueCollection sectionCollection))
                return defaultValue;

            return Convert.ToInt32(sectionCollection[keyName]);
        }

        public static bool GetConfigOptionalBoolValue(string keyName, bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(keyName)) return defaultValue;

            if (ConfigurationManager.AppSettings.Get(keyName) != null)
                return Convert.ToBoolean(ConfigurationManager.AppSettings[keyName]);

            return defaultValue;
        }

        public static string GetConfigFromSectionOptionalStringValue(string keyName, string section, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(keyName)) return defaultValue;

            if (!(ConfigurationManager.GetSection(section) is NameValueCollection sectionCollection))
                return defaultValue;

            return sectionCollection[keyName] ?? defaultValue;
        }
    }
}
