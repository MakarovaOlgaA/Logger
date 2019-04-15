namespace SomeWebApplication.Logging
{
    using Infrastructure.Logging;

    public interface ILoggerFactory
    {
        ILogger GetLogger();
    }
}
