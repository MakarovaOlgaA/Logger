namespace SomeWebApplication.Logging
{
    public interface IEnvironmentHelper
    {
        bool IsLoggingEnabled(LoggingLevel level);
    }
}
