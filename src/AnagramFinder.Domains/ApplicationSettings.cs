using Microsoft.Extensions.Configuration;

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
    }
}
