using AnagramFinder.Contracts.Services;
using AnagramFinder.Domains;
using AnagramFinder.Domains.Requests;
using AnagramFinder.Services.Validators;
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
                .AddTransient<FluentValidation.IValidator<FindAnagramRequest>, FindAnagramValidator>()
                .AddTransient<IMediatorService, MediatorService>()
                .AddMediatR(Assembly.GetAssembly(typeof(ServiceRegistration)))
                .AddTransient<IAnagramService, AnagramService>();
        }
    }
}
