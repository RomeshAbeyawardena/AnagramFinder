using Anagram.Contracts.Services;
using DotNetInsights.Shared.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace AnagramFinder.Services
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IAnagramService, AnagramService>();
        }
    }
}
