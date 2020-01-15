using AnagramFinder.Contracts.Services;
using AnagramFinder.Domains;
using DotNetInsights.Shared.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AnagramFinder.Services
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            services
                .AddSingleton<ApplicationSettings>()
                .AddMediatR(Assembly.GetAssembly(typeof(ServiceRegistration)))
                .AddTransient<IAnagramService, AnagramService>();
        }
    }
}
