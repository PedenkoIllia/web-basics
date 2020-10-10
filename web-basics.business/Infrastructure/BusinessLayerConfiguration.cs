using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using web_basics.business.Domains;
using web_basics.data.Infrastructure;

namespace web_basics.business.Infrastructure
{
    public class BusinessLayerConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(CatService));
            services.AddTransient(typeof(DogService));

            DataLayerConfiguration.ConfigureServices(services, configuration);
        }
    }
}
