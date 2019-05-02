namespace Logger
{
    using Infrastructure.Logging;
    using System;
    using System.IO;

    public class FileLogger : BaseLogger, ILogger
    {
        protected readonly string fileName;

        public FileLogger(string fileName, Func<LoggingLevel, bool> isLoggingEnabled): base (isLoggingEnabled)
        {
            this.fileName = fileName;
        }

        protected void WriteLog(LoggingLevel level, string log, object context = null)
        {
            if (IsLoggingEnabled(level))
            {
                using (StreamWriter file = new StreamWriter(fileName, true))
                {
                    var contextStr = context == null ? "Unknown" : StringifyObject(context);
                    var message = String.Format("Level: {0}\tLog: {1}\tContext: {2}", level.ToString(), log, contextStr);

                    file.WriteLine(message);
                }
            }
        }

        public void Critical(string value, object context = null)
        {
            WriteLog(LoggingLevel.Critical, value, context);
        }

        public void Critical(Exception ex, object context = null)
        {
            Critical(FormatException(ex), context);
        }

        public void Debug(string value, object context = null)
        {
            WriteLog(LoggingLevel.Debug, value, context);
        }

        public void Info(string value, object context = null)
        {
            WriteLog(LoggingLevel.Info, value, context);
        }

        public void Trace(string value, object context = null)
        {
            WriteLog(LoggingLevel.Trace, value, context);
        }

        public void Error(string value, object context = null)
        {
            WriteLog(LoggingLevel.Error, value, context);
        }

        public void Error(Exception ex, object context = null)
        {
            Error(FormatException(ex), context);
        }
    }
}
