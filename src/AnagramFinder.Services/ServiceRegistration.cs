using AnagramFinder.Contracts.Services;
using AnagramFinder.Domains;
using AnagramFinder.Domains.Requests;
using AnagramFinder.Services.Validators;
using AutoMapper;
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
                .AddSingleton<IJsonService, JsonService>()
                .AddSingleton<IHttpRequestService, HttpRequestService>()
                .AddTransient<FluentValidation.IValidator<FindAnagramRequest>, FindAnagramValidator>()
                .AddTransient<IMediatorService, MediatorService>()
                .AddMediatR(Assembly.GetAssembly(typeof(ServiceRegistration)))
                .AddTransient<IAnagramService, AnagramService>();

            services.AddAutoMapper(Assembly.GetAssembly(typeof(DomainProfile)));
        }
    }
}
