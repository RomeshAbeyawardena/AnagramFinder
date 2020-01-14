using Anagram.Contracts;
using DotNetInsights.Shared.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFinder.Data
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            services
                .AddTransient<IAnagramDataContext, AnagramDataContext>()
                .AddTransient<IDataAccess, DataAccess>();
        }
    }
}
