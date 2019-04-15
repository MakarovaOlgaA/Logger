namespace SomeWebApplication.Logging
{
    using System;

    public class LoggerFactoryResolver
    {
        public ILoggerFactory GetLoggerFactory()
        {
            var loggerType = LoggingSettings.Settings.LoggerType;
            var loggerFactoryType = TypeResolver.GetType(loggerType);

            return (ILoggerFactory)Activator.CreateInstance(loggerFactoryType);
        }
    }
}
