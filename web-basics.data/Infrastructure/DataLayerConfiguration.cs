using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using web_basics.data.Repositories;

namespace web_basics.data.Infrastructure
{
    public static class DataLayerConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(CatRepository));
            services.AddTransient(typeof(DogRepository));

            services.AddDbContext<WebBasicsDBContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
