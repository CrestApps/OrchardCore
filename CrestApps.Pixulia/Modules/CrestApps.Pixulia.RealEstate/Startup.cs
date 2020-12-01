using CrestApps.Core.Data.Abstraction;
using CrestApps.Pixulia.RealEstate.Data.Entity;
using CrestApps.Pixulia.RealEstate.Drivers;
using CrestApps.Pixulia.RealEstate.Fields;
using CrestApps.Pixulia.RealEstate.Models;
using CrestApps.Pixulia.RealEstate.Service;
using CrestApps.Pixulia.RealEstate.Service.Implementations;
using CrestApps.Pixulia.RealEstate.Shapes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.Data;
using OrchardCore.Data.Migration;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.Handlers;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;

namespace CrestApps.Pixulia.RealEstate
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
           {
               IDbConnectionAccessor accessor = serviceProvider.GetRequiredService<IDbConnectionAccessor>();
               options.UseMySql(accessor.CreateConnection(), mySqlOptions =>
               {
                   mySqlOptions.ServerVersion(new ServerVersion(new Version(8, 0, 16), ServerType.MySql));
                   mySqlOptions.EnableRetryOnFailure(2);
               });
           });

            services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));
            services.AddScoped<IPropertyStore, PropertyStore>();

            services.AddScoped<IDisplayDriver<CardShape>, CardShapeDriver>();
            services.AddScoped<IDisplayManager<CardShape>, DisplayManager<CardShape>>();
            //services.AddContentPart<FeaturedPropertyPart>();
            //services.AddContentField<FeaturedPropertyField>();
            services.AddScoped<IDataMigration, Migrations>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "RealEstate_default",
                    areaName: "CrestApps.Pixulia.RealEstate",
                    pattern: "r/{controller}/{action}/{id?}",
                    defaults: new { Controller = "Home", Action = "Index" });
            });
        }
    }
}
