namespace Todo
{
    using System;

    using Caliburn.Micro;

    internal class Logging
    {
        public static void Configure()
        {
            ILog logger = new ConsoleLogger();
            ILog errorLogger = new ErrorLogger();

            LogManager.GetLog = type => type == typeof(ActionMessage) ? logger : errorLogger;
        }

        private class ConsoleLogger : ILog
        {
            public virtual void Info(string format, params object[] args)
            {
                Console.WriteLine("Info: " + format, args);
            }

            public virtual void Warn(string format, params object[] args)
            {
                Console.WriteLine("Warning: " + format, args);
            }

            public virtual void Error(Exception exception)
            {
                Console.WriteLine(string.Format("Error: {0}", exception));
            }
        }

        private class ErrorLogger : ConsoleLogger
        {
            public override void Info(string format, params object[] args)
            {
            }
        }

        private class NullLogger : ILog
        {
            public void Info(string format, params object[] args)
            {
            }

            public void Warn(string format, params object[] args)
            {
            }

            public void Error(Exception exception)
            {
            }
        }
    }
}
