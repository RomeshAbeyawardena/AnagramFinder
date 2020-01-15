using Microsoft.Extensions.Configuration;
using System;

namespace AnagramFinder.Domains
{
    public class ApplicationSettings
    {
        
        public ApplicationSettings(IConfiguration configuration)
        {
            configuration.Bind(this);
            ConnectionString = configuration.GetConnectionString("default");
        }

        public string ConnectionString { get; set; }
        public Uri AnangramFinderUrl { get; set; }
    }
}
