﻿namespace Logger
{
    using Infrastructure.Logging;
    using log4net;
    using log4net.Appender;
    using log4net.Repository.Hierarchy;
    using System;
    using System.Linq;

    public class Log4NetAdapter: BaseLogger, ILogger
    {
        private readonly ILog logger;
        private const string LOGGER_NAME = "Log4NetLogger";

        public Log4NetAdapter(Func<LoggingLevel, bool> isLoggingLevelEnabled) : base(isLoggingLevelEnabled)
        {
            logger = LogManager.GetLogger(LOGGER_NAME);
        }

        public Log4NetAdapter(Func<LoggingLevel, bool> isLoggingLevelEnabled, string fileName) : this(isLoggingLevelEnabled)
        {
            var fileAppender = ((Hierarchy)LogManager.GetRepository()).Root.Appenders.OfType<FileAppender>().FirstOrDefault();

            fileAppender.File = fileName;

            fileAppender.ActivateOptions();
        }

        public Log4NetAdapter(Func<LoggingLevel, bool> isLoggingLevelEnabled, string connectionString, string command) : this(isLoggingLevelEnabled)
        {
            var dbAppender = ((Hierarchy)LogManager.GetRepository()).Root.Appenders.OfType<AdoNetAppender>().FirstOrDefault();

            dbAppender.ConnectionString = connectionString;
            dbAppender.CommandText = command;

            dbAppender.ActivateOptions();
        }

        public void Critical(string value, object context = null)
        {
            if (IsLoggingEnabled(LoggingLevel.Critical))
            {
                logger.Fatal(value + StringifyObject(context));
            }
        }

        public void Critical(Exception ex, object context = null)
        {
            Critical(FormatException(ex), context);
        }

        public void Debug(string value, object context = null)
        {
            if (IsLoggingEnabled(LoggingLevel.Debug))
            {
                logger.Debug(value + StringifyObject(context));
            }
        }

        public void Error(string value, object context = null)
        {
            if (IsLoggingEnabled(LoggingLevel.Error))
            {
                logger.Error(value + StringifyObject(context));
            }
        }

        public void Error(Exception ex, object context = null)
        {
            Error(FormatException(ex), context);
        }

        public void Info(string value, object context = null)
        {
            if (IsLoggingEnabled(LoggingLevel.Info))
            {
                logger.Info(value + StringifyObject(context));
            }
        }

        public void Trace(string value, object context = null)
        {
            Debug(value, context);
        }
    }
}