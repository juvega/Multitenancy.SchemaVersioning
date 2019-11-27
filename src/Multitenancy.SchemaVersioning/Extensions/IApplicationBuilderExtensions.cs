using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Builder;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseMultitenantSetup(this IApplicationBuilder app)
        {
            app.UseMultiTenant();
            ConfigureInMemoryTenantStore(app.ApplicationServices);
        }

        private static void ConfigureInMemoryTenantStore(IServiceProvider serviceProvider)
        {
            var scopeServices = serviceProvider.CreateScope().ServiceProvider;
            var store = scopeServices.GetRequiredService<IMultiTenantStore>();

            store.TryAddAsync(new TenantInfo("tenant-a-demo", "tenant-a", "Chaza Vea", "Data Source=.\\sqlexpress01;Initial Catalog=DoFactory;Integrated Security=True;", null)).Wait();
            store.TryAddAsync(new TenantInfo("tenant-b-demo", "tenant-b", "Hay Toy", "Data Source=.\\sqlexpress01;Initial Catalog=DoFactoryNew;Integrated Security=True;", null)).Wait();
        }
    }
}
