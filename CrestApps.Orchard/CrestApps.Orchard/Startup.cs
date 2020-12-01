using CrestApps.Data.Abstraction;
using CrestApps.Data.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CrestApps.Orchard
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOrchardCms();

            services.AddEntityDbContext();
            /*
            services.AddDbContext<ApplicationContext>((serviceProvider, options) =>
            {
                IDbConnectionAccessor accessor = serviceProvider.GetRequiredService<IDbConnectionAccessor>();
                var store = serviceProvider.GetRequiredService<IStore>();

                var configurar = new DefaultDatabaseContextBuilderConfigurator(accessor);
                configurar.Configure(options, store.Dialect.Name);
            });
            */


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IDatabaseContextBuilderConfigurator, DefaultDatabaseContextBuilderConfigurator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOrchardCore();
        }
    }
}
