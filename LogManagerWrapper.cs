using System;
using System.IO;
using log4net;
using log4net.Config;

namespace PayPal
{
    //// TODO: Implement the additional GetLogger method signatures and log4net.LogManager methods that are not seen below.
    public static class LogManagerWrapper
    {
        public static ILog GetLogger(Type type)
        {
            // If no loggers have been created, load our own.
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