using Infrastructure.Logging;
using Logger;

namespace SomeWebApplication.Logging.LoggerFactories
{
    public class FileLoggerFactory : ILoggerFactory
    {
        public ILogger GetLogger()
        {
            var fileName = LoggingSettings.Settings.FileName;

            return new FileLogger(fileName, EnviromnentHelper.IsLoggingEnabled);
        }
    }
}