namespace SomeWebApplication.Logging.LoggerFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Infrastructure.Logging;
    using Logger;

    public class Log4NetFactory : ILoggerFactory
    {
        public ILogger GetLogger()
        {
            Log4NetAdapter adapter = null;

            switch (LoggingSettings.Settings.Target)
            {
                case LoggingTarget.FileSystem:
                {
                    adapter = new Log4NetAdapter(EnviromnentHelper.IsLoggingEnabled,
                        LoggingSettings.Settings.FileName);
                    break;
                }
                case LoggingTarget.Database:
                {
                    adapter = new Log4NetAdapter(EnviromnentHelper.IsLoggingEnabled,
                        LoggingSettings.Settings.ConnectionString, LoggingSettings.Settings.Command);

                    break;
                }
            }

            return adapter;
        }
    }
}