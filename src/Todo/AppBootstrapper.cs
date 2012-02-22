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
    }
}
