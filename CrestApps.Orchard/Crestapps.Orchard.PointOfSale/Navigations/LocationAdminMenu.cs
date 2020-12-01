using CrestApps.Orchard.PointOfSale.Controllers;
using CrestApps.Orchard.PointOfSale.Permissions;
using Microsoft.Extensions.Localization;
using OrchardCore.Mvc.Core.Utilities;
using OrchardCore.Navigation;
using System.Threading.Tasks;

namespace CrestApps.Orchard.PointOfSale.Navigations
{
    public class LocationAdminMenu : INavigationProvider
    {
        private readonly IStringLocalizer T;


        public LocationAdminMenu(IStringLocalizer<LocationAdminMenu> stringLocalizer)
        {
            T = stringLocalizer;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!AdminMenuHelpers.IsAdminMenu(name))
            {
                return Task.CompletedTask;
            }

            string controllerName = typeof(LocationsController).ControllerName();

            builder.AddPointOfSaleMenu(T, mainMenu =>
            {
                mainMenu.Add(T["Locations"], "1", locationMenu =>
                        {
                            // Views/NavigationItemText-location.Id.cshtml the view
                            locationMenu.AddClass("Locations")
                                        .Id("Locations")
                                        .LinkToFirstChild(true)
                                        .Permission(LocationPermission.ManageLocations)
                                        .Add(T["List Locations"], listLocationMenu =>
                                        {
                                            listLocationMenu.LinkToFirstChild(true)
                                               .PosAction(nameof(LocationsController.Index), controllerName)
                                               .Permission(LocationPermission.ListLocations)
                                               .LocalNav();
                                        }).Add(T["Create Location"], createLocationMenu =>
                                        {
                                            createLocationMenu.PosAction(nameof(LocationsController.Create), controllerName)
                                            .Permission(LocationPermission.CreateLocation)
                                            .LocalNav();
                                        });
                        });
            });

            return Task.CompletedTask;
        }
    }
}