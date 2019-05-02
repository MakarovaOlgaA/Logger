using Infrastructure.Logging;
using System;

namespace SomeWebApplication.Logging
{
    public static class EnviromnentHelper
    {
        public static bool IsLoggingEnabled(LoggingLevel level)
        {
            var loggingLevels = LoggingSettings.Settings.EnabledLoggingLevels;

            if (loggingLevels.IndexOf("All", StringComparison.OrdinalIgnoreCase) >= 0
               || loggingLevels.IndexOf(level.ToString(), StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return true;
            }

            return false;
        }
    }
}
