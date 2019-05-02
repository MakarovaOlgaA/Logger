namespace SomeWebApplication.Logging
{
    using Infrastructure.Logging;
    using System;
    using System.Configuration;

    public class LoggingSettings: ConfigurationSection
    {
        public static LoggingSettings Settings {
            get {
                return ConfigurationManager.GetSection("LoggingSettings") as LoggingSettings;
            }
        }

        [ConfigurationProperty("EnabledLoggingLevels", DefaultValue = "All", IsRequired = false)]
        public string EnabledLoggingLevels {
            get { return (string)this["EnabledLoggingLevels"]; }
            set { this["EnabledLoggingLevels"] = value; }
        }

        [ConfigurationProperty("EnableEncryption", DefaultValue = "false", IsRequired = false)]
        public bool EnableEncryption {
            get { return (bool)this["EnableEncryption"]; }
            set { this["EnableEncryption"] = value; }
        }

        [ConfigurationProperty("LoggerType", IsRequired = true)]
        public string LoggerType {
            get { return (string)this["LoggerType"]; }
            set { this["LoggerType"] = value; }
        }

        [ConfigurationProperty("FileName", IsRequired = false)]
        public string FileName {
            get { return (string)this["FileName"]; }
            set { this["FileName"] = value; }
        }

        [ConfigurationProperty("ConnectionString", IsRequired = false)]
        public string ConnectionString {
            get { return (string)this["ConnectionString"]; }
            set { this["ConnectionString"] = value; }
        }

        [ConfigurationProperty("Command", IsRequired = false)]
        public string Command {
            get { return (string)this["Command"]; }
            set { this["Command"] = value; }
        }

        [ConfigurationProperty("Target", IsRequired = false, DefaultValue = LoggingTarget.FileSystem)]
        public LoggingTarget Target {
            get { return (LoggingTarget)Enum.Parse(typeof(LoggingTarget), (string)this["Target"]); }
            set { this["Target"] = value; }
        }
    }
}
