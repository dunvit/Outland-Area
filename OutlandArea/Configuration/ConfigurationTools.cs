using System;
using System.Collections.Specialized;
using System.Configuration;

namespace OutlandArea.Configuration
{
    public static class ConfigurationTools
    {
        public static string GetConfigOptionalStringValue(string keyName, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(keyName)) return defaultValue;

            if (ConfigurationManager.AppSettings.Get(keyName) != null)
                return ConfigurationManager.AppSettings[keyName];

            return defaultValue;
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
