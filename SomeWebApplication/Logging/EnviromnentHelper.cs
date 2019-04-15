using System;

namespace SomeWebApplication.Logging
{
    public class EnviromnentHelper : IEnvironmentHelper
    {
        public bool IsLoggingEnabled(LoggingLevel level)
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
