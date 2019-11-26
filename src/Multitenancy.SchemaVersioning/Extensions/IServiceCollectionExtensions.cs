using Database.DoFactory;
using Database.DoFactoryV2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkConfiguraton(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DoFactoryContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("dofactory")));
            services.AddDbContext<DoFactoryNewContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("dofactoryv11")));

            return services;
        }
    }
}
