using AnagramFinder.Contracts;
using DotNetInsights.Shared.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace AnagramFinder.Data
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            services
                .AddSingleton(SqlClientFactory.Instance)
                .AddTransient<IAnagramDataContext, AnagramDataContext>()
                .AddTransient<IDataLayer, DataAccess>();
        }
    }
}
