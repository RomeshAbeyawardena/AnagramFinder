using AnagramFinder.Services;
using DotNetInsights.Shared.Services;
using System.Collections.Generic;
using System.Reflection;
using DataServiceRegistration = AnagramFinder.Data.ServiceRegistration;

namespace AnagramFinder.Broker
{
    public class ServiceBroker : DefaultServiceBroker
    {
        public override IEnumerable<Assembly> GetAssemblies => new [] { 
            DefaultAssembly, Assembly.GetAssembly(typeof(ServiceRegistration)), 
            Assembly.GetAssembly(typeof(DataServiceRegistration)) };
    }
}
