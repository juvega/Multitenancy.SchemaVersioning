using Database.DoFactory;
using Database.DoFactoryV2;
using Microsoft.AspNetCore.Routing;
using Multitenancy.SchemaVersioning;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkConfiguraton(this IServiceCollection services)
        {
            services.AddDbContext<DoFactoryContext>();
            services.AddDbContext<DoFactoryNewContext>();

            return services;
        }

        public static IServiceCollection AddMultitenantConfiguration(this IServiceCollection services, Action<IRouteBuilder> routes)
        {
            services.AddMultiTenant()
                    .WithRouteStrategy(routes)
                    .WithEFCoreStore<TenantDbContext, AppTenantInfo>();

            return services;
        }
    }
}
