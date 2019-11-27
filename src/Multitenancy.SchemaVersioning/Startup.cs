using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Multitenancy.SchemaVersioning
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
                
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning();
            services.AddEntityFrameworkConfiguraton();

            services.AddMultitenantConfiguration(ConfigRoutes);

            services.AddMvcCore()                
                .AddJsonFormatters();
        }
                
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMultitenantSetup();

            app.UseHttpsRedirection();
            app.UseApiVersioning();
            app.UseMvc(ConfigRoutes);
        }

        private void ConfigRoutes(IRouteBuilder routes)
        {
            routes.MapRoute("Defaut", "{__tenant__=}/api/{version:apiVersion}/{controller}/{action}");
        }
    }
}
