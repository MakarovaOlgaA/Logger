namespace SomeWebApplication.Logging
{
    using System.Configuration;

    public class LoggingSettings: ConfigurationSection
    {
        public static LoggingSettings Settings {
            get {
                return ConfigurationManager.GetSection("BlogSettings") as LoggingSettings;
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
    }
}
