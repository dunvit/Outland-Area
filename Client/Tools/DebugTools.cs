using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Engine.Tools
{
    class DebugTools
    {
        public static bool xxIsInDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime);

            //if (Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1)
            //{
            //    return true;
            //}
            //return false;
        }

        public static bool IsInDesignMode()
        {
            if (Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1)
            {
                return true;
            }
            return false;
        }
    }
}
