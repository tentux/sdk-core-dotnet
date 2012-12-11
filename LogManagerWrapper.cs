using System;
using log4net;

namespace PayPal
{
    public static class LogManagerWrapper
    {
        public static ILog GetLogger(Type type)
        {
            if (LogManager.GetCurrentLoggers().Length == 0)
            {
                LoadConfig();
            }
            return LogManager.GetLogger(type);
        }

        private static void LoadConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}