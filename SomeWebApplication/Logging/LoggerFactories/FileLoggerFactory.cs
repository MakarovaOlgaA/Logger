using Infrastructure.Logging;

namespace SomeWebApplication.Logging
{
    public class FileLoggerFactory : ILoggerFactory
    {
        public ILogger GetLogger()
        {
            var fileName = LoggingSettings.Settings.FileName;

            return new FileLogger(fileName, new EnviromnentHelper());
        }
    }
}
