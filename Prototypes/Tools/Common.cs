using System.ComponentModel;


namespace Engine.Tools
{
    public class Common
    {
        public static bool IsApplicationModeRuntime()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Runtime;
        }
    }
}
