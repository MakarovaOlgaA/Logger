namespace SomeWebApplication.Logging.LoggerFactories
{
    using Infrastructure.Logging;

    public interface ILoggerFactory
    {
        ILogger GetLogger();
    }
}
