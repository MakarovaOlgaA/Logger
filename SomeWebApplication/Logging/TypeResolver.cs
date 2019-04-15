namespace SomeWebApplication.Logging
{
    using System;
    using System.Collections.Generic;

    public static class TypeResolver
    {
        private static Dictionary<string, Type> typeMappings;

        public static void Initialize()
        {
            RegisterMappings();
        }

        public static void RegisterMappings()
        {
            typeMappings = new Dictionary<string, Type>();

            typeMappings.Add("FileLogger", typeof(FileLoggerFactory));
        }

        public static Type GetType(string key)
        {
            return typeMappings[key];
        }
    }
}
