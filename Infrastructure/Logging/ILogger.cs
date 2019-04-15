namespace Infrastructure.Logging
{
    using System;

    public interface ILogger
    {
        void Debug(string value, object context = null);

        void Info(string value, object context = null);

        void Trace(string value, object context = null);

        void Error(string value, object context = null);
        void Error(Exception ex, object context = null);

        void Critical(string value, object context = null);
        void Critical(Exception ex, object context = null);
    }
}
