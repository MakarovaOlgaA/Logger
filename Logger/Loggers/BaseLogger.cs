namespace Logger
{
    using Infrastructure.Logging;
    using Newtonsoft.Json;
    using System;

    public abstract class BaseLogger
    {
        public Func<LoggingLevel, bool> IsLoggingEnabled;

        public BaseLogger(Func<LoggingLevel, bool> isLoggingEnabled)
        {
            IsLoggingEnabled = isLoggingEnabled;
        }

        public virtual string FormatException(Exception ex)
        {
            return String.Format("{0} occured at {1}: {2}", ex.GetType().Name, ex.StackTrace, ex.Message);
        }

        public virtual string StringifyObject(object obj)
        {
            var result = obj == null ? String.Empty : JsonConvert.SerializeObject(obj);
            return result;
        }
    }
}
