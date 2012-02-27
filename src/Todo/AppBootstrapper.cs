namespace Todo
{
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    public class AppBootstrapper : Bootstrapper<IShell>
    {
        private IUnityContainer container;

        /// <summary>
        /// Configure to use Unity. 
        /// </summary>
        protected override void Configure()
        {
            this.container = new UnityContainer()
                .LoadConfiguration();

            ILog logger = new ConsoleLogger();
            ILog errorLogger = new ErrorLogger();
            LogManager.GetLog = type => type == typeof(ActionMessage) ? logger : errorLogger;
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return this.container.Resolve(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return this.container.ResolveAll(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            this.container.BuildUp(instance);
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
                Console.WriteLine(string.Format("Error: {0}", exception.ToString()));
            }
        }

        private class ErrorLogger : ConsoleLogger
        {
            public override void Info(string format, params object[] args) { }
        }

        private class NullLogger : ILog
        {
            public void Info(string format, params object[] args) { }
            public void Warn(string format, params object[] args) { }
            public void Error(Exception exception) { }
        }
    }
}
