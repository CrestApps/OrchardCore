using AutoMapper;
using CrestApps.Data.Models;
using CrestApps.Mappings;
using CrestApps.Orchard.PointOfSale.Drivers;
using CrestApps.Orchard.PointOfSale.Navigations;
using CrestApps.Orchard.PointOfSale.Permissions;
using CrestApps.Orchard.PointOfSale.WebPresentation.Factories;
using CrestApps.Orchard.PointOfSale.WebPresentation.Factories.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Navigation;
using OrchardCore.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CrestApps.Orchard.PointOfSale
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDisplayManager<Location>, DisplayManager<Location>>();
            services.AddScoped<IDisplayDriver<Location>, LocationDisplayDriver>();

            services.AddScoped<IPermissionProvider, LocationPermission>();
            services.AddScoped<INavigationProvider, LocationAdminMenu>();
            services.AddScoped<ILocationShapeFactory, LocationShapeFactory>();

            List<string> autoMappingAssemblyNames = new List<string>()
            {
                "CrestApps.Orchard.PointOfSale",
                "CrestApps.Orchard.PointOfSale.WebPresentation",
            };

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies()
                                             .Where(x => autoMappingAssemblyNames.Contains(x.GetName().Name))
                                              .ToArray();

            services.AddAutoMapper((expression) =>
            {
                Type[] types = assemblies.SelectMany(x => x.GetTypes().Where(x => x.IsClass && !x.IsInterface))
                                         .ToArray();

                expression.UseMapFrom(types);
            }, assemblies);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "PointOfSale_default",
                    areaName: "Crestapps.Orchard.PointOfSale",
                    pattern: "pos/{controller}/{action}/{id?}",
                    defaults: new { Controller = "Home", Action = "Index" });
            });
        }
    }
}
